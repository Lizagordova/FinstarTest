using System.Collections.Generic;
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

        [HttpGet]
        [Route("get")]
        public ActionResult<GetItemsResponse> Get([FromQuery]GetListRequest request)
        {
            var options = _mapper.Map<ItemQueryOptions>(request);
            var response = new GetItemsResponse {Items = _itemsReader.GetItems(options).ToList()};
            return new ActionResult<GetItemsResponse>(response);
            //todo: добавить обработку ошибку
            //todo: добавит проверку входных данных
        }
        
        [HttpGet]
        [Route("get1")]
        public ActionResult<GetItemsResponse> Get([FromQuery]int? codeFilter, [FromQuery]string? valueFilter)
        {
            return new GetItemsResponse
            {
                Items = new List<Item>
                {
                    new Item {Id = 1, Code = 10, Value = "155"},
                    new Item {Id = 2, Code = 19, Value = "222"},
                    new Item {Id = 3, Code = 15, Value = "333"},
                }
            };
        }
    }
}