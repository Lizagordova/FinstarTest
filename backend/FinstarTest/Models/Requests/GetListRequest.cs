namespace FinstarTest.Models.Requests
{
    public class GetListRequest
    {
        public int? CodeFilter { get; set; }
        public string? ValueFilter { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}