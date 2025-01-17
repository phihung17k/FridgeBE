using System.Net;

namespace FridgeBE.Core.Models.ResponseModels
{
    public class CategoryResponseModel : ResponseModelBase
    {
        public CategoryResponseModel()
        { }

        public CategoryResponseModel(HttpStatusCode statusCode, string errorMessage) : base(statusCode, errorMessage)
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalName { get; set; }
        public string? Description { get; set; }
    }
}