using ecommerceAPI.Application.DTOs.Order;
using ecommerceAPI.Application.Interfaces.Services;
using ecommerceAPI.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//using System.Web.Http;

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
        public async Task<ActionResult<OrderDto>> OrderById(int OrderId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await service.GetOrderByIdAsync(OrderId, userId);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder(CreateOrderDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await service.CreateOrderAsync(userId, dto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<IEnumerable<OrderDto>>> UpdateOrderStatus(int orderId, UpdateOrderStatusDto dto)
        {
            var result = service.UpdateOrderStatus(orderId, dto);
            return Ok(result);
        }
        
        [Authorize]
        [HttpPost("CancelOrder")]
        public async Task<ActionResult> CancelOrder(int orderId)
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = service.CancelOrder(orderId);
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteOrder")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            await service.DeleteOrder(orderId);
            return NoContent();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet("GetOrdersByStatus")]
        public async Task<ActionResult> GetOrdersByStatus(OrderStatus status)
        {
            var result = await service.GetOrderByStatusAsync(status);
            return Ok(result);
        }
        
    }
}
