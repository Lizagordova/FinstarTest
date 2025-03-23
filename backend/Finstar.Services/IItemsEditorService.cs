using System.Collections.Generic;

namespace Finstar.Services
{
    public interface IItemsEditorService
    {
        void SaveItems(Dictionary<int, string> items);
    }
}