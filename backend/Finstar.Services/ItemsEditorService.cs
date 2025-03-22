using Finstar.Domain;

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
        public void SaveItems()
        {
            // сделать очистку базу
            // сохранение данные  в бд
        }
    }
}