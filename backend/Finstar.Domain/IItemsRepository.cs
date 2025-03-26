using System.Collections.Generic;
using System.Threading.Tasks;
using Finstar.Domain.Models;

namespace Finstar.Domain
{
    public interface IItemsRepository
    {
        public Task SaveItemsAsync(IEnumerable<Item> items);
        public Task<PagingModel<Item>> GetItemsAsync(ItemQueryOptions options);
    }
}