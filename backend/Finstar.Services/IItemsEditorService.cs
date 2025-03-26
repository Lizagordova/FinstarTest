using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finstar.Services
{
    public interface IItemsEditorService
    {
        Task SaveItemsAsync(Dictionary<int, string> items);
    }
}