using ecommerceAPI.Application.DTOs.Order;
using ecommerceAPI.Application.Interfaces.Services;
using ecommerceAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AllOrdersForAdmin")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> ShowAllOrdersForAdmin()
        {

            var result = await service.GetAllOrdersForAdminAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("AllOrdersForUser")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> ShowAllOrdersForUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await service.GetAllUserOrdersAsync(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDto>> OrderById([FromRoute] int orderId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();
            var result = await service.GetOrderByIdAsync(orderId, userId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("GetOrdersByStatus")]
        public async Task<ActionResult> GetOrdersByStatus(OrderStatus status)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();
            var result = await service.GetOrderByStatusAsync(userId,status);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("CreateOrder")]
        public async Task<ActionResult> ConfirmedOrder()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await service.CreateOrderAsync(userId);
            if (!result)
                return BadRequest("Unable to create order.");

            return Ok("Order created successfully.");
        }

        [Authorize] 
        [HttpPatch("{orderId}/cancel")]
        public async Task<ActionResult> CancelOrder(int orderId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();
            await service.CancelOrder(userId, orderId);
            return Ok("Order cancelled successfully.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatus( UpdateOrderStatusDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();
            await service.UpdateOrderStatus( dto);
            return Ok("Order status updated successfully.");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            if (orderId <= 0)
                return BadRequest("Invalid order id.");

            await service.DeleteOrder(orderId);
            return Ok();
        }
        
    }
}
