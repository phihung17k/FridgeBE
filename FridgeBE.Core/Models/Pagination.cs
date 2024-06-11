namespace FridgeBE.Core.Models
{
    public class Pagination<T>
    {
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