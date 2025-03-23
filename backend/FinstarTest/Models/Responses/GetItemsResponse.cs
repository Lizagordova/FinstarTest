using System.Collections.Generic;
using Finstar.Domain.Models;

namespace FinstarTest.Models.Responses
{
    public class GetItemsResponse
    {
        public List<Item> Items { get; set; }
    }
}