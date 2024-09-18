﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using FridgeBE.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace FridgeBE.Infrastructure.Utils
{
    public class FileUtils
    {
        private static readonly List<string> _imageExtensions = new List<string>
        {
            ".apng",
            ".avif",
            ".gif",
            ".jpg",
            ".jpeg",
            ".jfif",
            ".pjpeg",
            ".pjp",
            ".png",
            ".svg",
            ".webp",
            ".bmp",
            ".ico",
            ".cur",
            ".tif",
            ".tiff"
        };
        private static readonly long _fileSizeLimit = 128000000; // 128MB
        public static List<string> ImageExtensions = _imageExtensions;

        public static bool ValidateFileExtension(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return _imageExtensions.Contains(extension);
        }

        public static bool ValidateFileExtension(string extension)
        {
            return _imageExtensions.Contains(extension.ToLowerInvariant());
        }

        /// <summary>
        ///     Upload file to a specific folder, create the folder if it is not exist
        /// </summary>
        /// <returns>Return path to the uploaded file</returns>
        public static async Task<string> UploadFile(IFormFile? file, string folder = "Files")
        {
            if (file == null)
                return string.Empty;

            string imageFolderPath = Path.Combine(Environment.CurrentDirectory, folder);
            // actually, CreateDirectory() returns DirectoryInfo if folder is existed
            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            string extension = Path.GetExtension(file.FileName);
            if (!ValidateFileExtension(extension))
               throw new RequestException(HttpStatusCode.BadRequest, string.Format(ErrorMessages.UnsupportFile, extension));

            if (file.Length > _fileSizeLimit)
                throw new RequestException(HttpStatusCode.BadRequest, $"File is too large, limit in 128MB (current ${_fileSizeLimit/Math.Pow(10, 6)})");

            string fileName = Path.GetRandomFileName();
            fileName = Path.ChangeExtension(fileName, extension);
            string filePath = Path.Combine(imageFolderPath, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
            {
                await file.CopyToAsync(fileStream);

                return Path.GetFullPath(filePath);
            }
        }

        // <category id, [ingredient]>
        public static Dictionary<string, List<string>> ReadIngredientsExcelFile()
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            string filePath = @"..\..\..\..\Food.xlsx";
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = spreadsheet.WorkbookPart ?? spreadsheet.AddWorkbookPart();
                IEnumerable<Sheet> sheets = workbookPart.Workbook.GetFirstChild<Sheets>()!.Elements<Sheet>();
                OpenXmlElementList childElements = workbookPart.SharedStringTablePart!.SharedStringTable.ChildElements;

                for (int i = 1; i < sheets.Count(); i++)
                {
                    Sheet sheet = sheets.ElementAt(i);
                    string sheetName = sheet.Name!.Value!;

                    string sheetId = sheet.Id!.Value!;
                    SheetData sheetData = ((WorksheetPart) workbookPart.GetPartById(sheetId)).Worksheet.GetFirstChild<SheetData>()!;
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();

                    List<string> ingredients = new();
                    for (int j = 0; j < rows.Count(); j++)
                    {
                        Row row = rows.ElementAt(j);
                        Cell cell = row.Descendants<Cell>().ElementAt(0);
                        if (cell.CellValue?.InnerXml == null)
                            break;

                        string value = childElements[int.Parse(cell.CellValue!.InnerXml)].InnerText;
                        ingredients.Add(value);
                    }
                    dic.Add(sheetName, ingredients);
                }
            }
            return dic;
        }
    }
}