using System.Collections.Generic;
using Finstar.Domain.Models;

namespace Finstar.Services
{
    public interface IItemsReaderService
    {
        IList<Item> GetItems(ItemQueryOptions options);
    }
}