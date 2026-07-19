using ecommerceAPI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet("Users")]
        public async Task<IActionResult> GetTotalUsers()
        {
            var users = await service.GetTotalUsers();
            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Products")]
        public async Task<IActionResult> GetTotalProducts()
        {
            var Products = await service.GetTotalProducts();
            return Ok(Products);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Orders")]
        public async Task<IActionResult> GetTotalOrders()
        {
            var Orders = await service.GetTotalOrders();
            return Ok(Orders);
        }

       
    }
}
