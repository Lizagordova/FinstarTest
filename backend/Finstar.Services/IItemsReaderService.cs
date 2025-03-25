using Finstar.Domain.Models;

namespace Finstar.Services
{
    public interface IItemsReaderService
    {
        PagingModel<Item> GetItems(ItemQueryOptions options);
    }
}