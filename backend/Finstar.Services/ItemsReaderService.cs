using System.Collections.Generic;
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

        public IEnumerable<Item> GetItems()
        {
            throw new System.NotImplementedException();
        }
    }
}