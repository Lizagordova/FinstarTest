using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public async Task<IActionResult> SaveItems([FromBody] SaveItemsRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _itemsEditor.SaveItemsAsync(request.Data);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"Ошибка при сохранении данных. error: {e.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Внутренняя ошибка сервера");
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<GetItemsResponse>> Get([FromQuery]GetListRequest request)
        {
            try
            {
                var options = _mapper.Map<ItemQueryOptions>(request);
                var result = await _itemsReader.GetItemsAsync(options);
                var response = new GetItemsResponse {Items =  result.Items.ToList(), TotalCount = result.TotalCount };
                return new ActionResult<GetItemsResponse>(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Ошибка при получении данных. error: {e.Message}");
                 return StatusCode((int)HttpStatusCode.InternalServerError, "Внутренняя ошибка сервера");
            }
        }
    }
}