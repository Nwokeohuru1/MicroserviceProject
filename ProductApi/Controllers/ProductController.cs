using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repository.Interface;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ProductController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost]
        [Route("CreateItem")]
        public async Task<IActionResult> CreateItem(Product createItem)
        {
            await _itemService.CreateItem(createItem);
            return Ok("Done!!");
        }

        [HttpGet]
        [Route("GetAllItems")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetItems();

            return Ok(items);
        }
        [HttpGet]
        [Route("GetItem")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _itemService.GetItem(id);
            if(item == null )
            {
                return BadRequest("item not found");
            }

            return Ok(item);
        }
        [HttpPost]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateItem(Product Nitem)
        {
            
            await _itemService.UpdateItem(Nitem);

            return Ok("Done");
        }
        [HttpPost]
        [Route("DeleteItem")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _itemService.GetItem(id);
            if (item == null)
            {
                return BadRequest("Item not found");
            };
            await _itemService.DeleteItem(id);

            return Ok("Done!!!");

        }
    }
}
