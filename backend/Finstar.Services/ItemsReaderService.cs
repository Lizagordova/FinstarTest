using System.Collections.Generic;
using System.Threading.Tasks;
using Finstar.Domain;
using Finstar.Domain.Models;

namespace Finstar.Services
{
    public class ItemsReaderService : IItemsReaderService
    {
        private IItemsRepository _itemsRepository;
        public ItemsReaderService(
            IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public async Task<PagingModel<Item>> GetItemsAsync(ItemQueryOptions options)
        {
            return await _itemsRepository.GetItemsAsync(options);
        }
    }
}