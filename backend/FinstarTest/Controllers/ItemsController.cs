using System.Collections.Generic;
using Finstar.Services;
using FinstarTest.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinstarTest.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemsEditorService _itemsEditor;
        private readonly IItemsReaderService _itemsReader;

        public ItemsController(ILogger<ItemsController> logger, IItemsEditorService itemsEditor,
            IItemsReaderService itemsReader)
        {
            _logger = logger;
            _itemsEditor = itemsEditor;
            _itemsReader = itemsReader;
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveItems([FromBody] Dictionary<int, string> request)
        {
            _itemsEditor.SaveItems();
            return Ok();
        }

        [HttpGet(Name = "get")]
        public IEnumerable<int> Get([FromQuery]GetListRequest request)
        {
            var items = _itemsReader.GetItems();
            return new List<int> {1, 2, 3};
        }
    }
}