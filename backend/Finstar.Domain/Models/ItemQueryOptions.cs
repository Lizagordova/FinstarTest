namespace Finstar.Domain.Models
{
    public class ItemQueryOptions
    {
        public int? CodeFilter { get; set; }
        public string ValueFilter { get; set; }
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;
    }
}