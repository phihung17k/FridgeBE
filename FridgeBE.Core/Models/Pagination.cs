using FridgeBE.Core.Models.ResponseModels;
using System.Net;

namespace FridgeBE.Core.Models
{
    // reference https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-6.0#create-the-paginatedlist-class
    public class Pagination<T> : ResponseModelBase
    {
        public Pagination()
        { }

        public Pagination(HttpStatusCode statusCode, string errorMessage) : base(statusCode, errorMessage)
        { }

        public int TotalItemsCount { get; set; }
        // number of items per a page
        public int PageSize { get; set; }
        public int PageCount => (int) Math.Ceiling((double) TotalItemsCount / PageSize);
        public int PageIndex { get; set; }

        // 1 2 3
        public bool HasNext => PageIndex < PageCount;
        public bool HasPrevious => PageIndex > 1;
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}