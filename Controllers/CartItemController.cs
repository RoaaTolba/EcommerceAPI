using ecommerceAPI.Application.DTOs.Cart;
using ecommerceAPI.Application.Interfaces.Services;
using ecommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService service;

        public CartItemController(ICartItemService service )
        {
            this.service = service;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetAllItems()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var list = await service.GetAllItemsAsync(userId);
            if (!list.Any()) 
                return NotFound();
            return Ok(list);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CartItemDTO>> AddItem(AddToCartDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var newItem = await service.AddItem(userId,dto);
            if (newItem == null)
                return NotFound();
            return Ok(newItem);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<CartItemDTO>> UpdateItemQuantity(int productId, int newQuantity)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var newUpdatedItem = await service.UpdateItemQuantity(userId, productId, newQuantity);
            if (newUpdatedItem == null)
                return NotFound();
            return Ok(newUpdatedItem);
        }
        [HttpDelete]
        [Authorize]
        //how should i delete it whithout his cart item id?
        public async Task<IActionResult> DeleteItem(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var success = await service.RemoveItem(userId, productId);
            if (!success)
                return NotFound();
            return Ok();
        }

        [HttpDelete("ClearAll")]
        [Authorize]
        //how should i delete it whithout his cart item id?
        public async Task<IActionResult> ClearAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var success = await service.ClearAll(userId);
            if (!success)
                return NotFound();
            return Ok();
        }

        //[HttpPost("fromToOrder")]
        //[Authorize]
        //public async Task<IActionResult> AddToOrder()
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var newItem = await service.MoveToOrder(userId);
        //    if (!newItem)
        //        return BadRequest("Unable to create order.");

        //    return Ok("Order created successfully.");
        //}
    }
}
