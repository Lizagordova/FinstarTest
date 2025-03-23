using System.Collections.Generic;
using Finstar.Domain.Models;

namespace Finstar.Domain
{
    public interface IItemsRepository
    {
        public void SaveItems(IEnumerable<Item> items);
        public IList<Item> GetItems(ItemQueryOptions options);
    }
}