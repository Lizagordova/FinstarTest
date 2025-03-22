using System.Collections;
using System.Collections.Generic;
using Finstar.Domain.Models;

namespace Finstar.Domain
{
    public interface IItemsRepository
    {
        public void SaveItems(IList<Item> items);
        public IList<Item> GetItems();
    }
}