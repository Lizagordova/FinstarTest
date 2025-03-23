using System;
using System.Collections.Generic;
using System.Linq;
using Finstar.Domain;
using Finstar.Domain.Models;

namespace Finstar.Services
{
    public class ItemsEditorService : IItemsEditorService
    {
        private IItemsRepository _itemsRepository;
        public ItemsEditorService(
            IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public void SaveItems(Dictionary<int, string> items)
        {
            var sortedDict = items.OrderBy(pair => pair.Key);
            var itemList = sortedDict.Select((pair, index) => new Item
            {
                Id = index + 1,
                Code = pair.Key,
                Value = pair.Value
            });
            _itemsRepository.SaveItems(itemList);
        }
    }
}