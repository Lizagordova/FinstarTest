namespace Finstar.Domain.Models
{
    public class ItemQueryOptions
    {
        public int? CodeFilter { get; set; }
        public string? ValueFilter { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}