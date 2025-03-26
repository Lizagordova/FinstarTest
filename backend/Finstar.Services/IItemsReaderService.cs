using System.Threading.Tasks;
using Finstar.Domain.Models;

namespace Finstar.Services
{
    public interface IItemsReaderService
    {
        Task<PagingModel<Item>>GetItemsAsync(ItemQueryOptions options);
    }
}