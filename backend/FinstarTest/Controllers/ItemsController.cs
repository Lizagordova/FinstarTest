using System.Linq;
using AutoMapper;
using Finstar.Domain.Models;
using Finstar.Services;
using FinstarTest.Models.Requests;
using FinstarTest.Models.Responses;
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
        private readonly IMapper _mapper;

        public ItemsController(ILogger<ItemsController> logger, IItemsEditorService itemsEditor,
            IItemsReaderService itemsReader, IMapper mapper)
        {
            _logger = logger;
            _itemsEditor = itemsEditor;
            _itemsReader = itemsReader;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveItems([FromBody] SaveItemsRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _itemsEditor.SaveItems(request.Data);
            return Ok();
        }

        [HttpGet(Name = "get")]
        public ActionResult<GetItemsResponse> Get([FromQuery]GetListRequest request)
        {
            var options = _mapper.Map<ItemQueryOptions>(request);
            return new GetItemsResponse {Items = _itemsReader.GetItems(options).ToList()};
            //todo: добавить обработку ошибку
            //todo: добавит проверку входных данных
        }
    }
}