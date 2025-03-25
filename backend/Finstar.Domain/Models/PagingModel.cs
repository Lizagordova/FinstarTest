using System.Collections.Generic;

namespace Finstar.Domain.Models
{
    public class PagingModel<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => TotalCount / PageSize;
    }
}