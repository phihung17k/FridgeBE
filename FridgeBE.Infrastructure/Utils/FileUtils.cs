using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using FridgeBE.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using Tuple = System.Tuple;

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

        // <category id, [ingredient name, ingredient description]>
        public static Dictionary<string, List<Tuple<string, string>>> ReadIngredientsExcelFile()
        {
            Dictionary<string, List<Tuple<string, string>>> dic = [];
            // AppDomain.CurrentDomain.BaseDirectory = ".\FridgeBE\FridgeBE.Api\bin\Debug\net8.0\"
            // Directory.GetCurrentDirectory() = ".\FridgeBE\FridgeBE.Api"

            //string directoryPath = Directory.GetCurrentDirectory();
            //Console.WriteLine($"Directory: {directoryPath}");
            //int fridgeBeApiDirectoryIndex = directoryPath.IndexOf("FridgeBE.Api");
            //directoryPath = directoryPath[..fridgeBeApiDirectoryIndex];

            //directoryPath = Directory.GetParent(Directory.GetCurrentDirectory())!.FullName;

            string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "Food.xlsx");
            if (!File.Exists(filePath))
            {
                Console.WriteLine("FileUtils.ReadIngredientsExcelFile(): The seeding file is not found");
                return dic;
            }
            Console.WriteLine("FileUtils.ReadIngredientsExcelFile(): The seeding file is Found");
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

                    List<Tuple<string, string>> ingredients = new();
                    for (int j = 0; j < rows.Count(); j++)
                    {
                        IEnumerable<Cell> cells = rows.ElementAt(j).Descendants<Cell>();
                        Cell ingredientCell = cells.ElementAt(3);
                        Cell descriptionCell = cells.ElementAt(4);

                        string ingredientName = ingredientCell.InnerText;
                        if (string.IsNullOrEmpty(ingredientName))
                            break;

                        string name = childElements[int.Parse(ingredientName)].InnerText;
                        string description = childElements[int.Parse(descriptionCell.InnerText)].InnerText;

                        ingredients.Add(Tuple.Create(name, description));
                    }
                    dic.Add(sheetName, ingredients);
                }
            }
            return dic;
        }
    }
}