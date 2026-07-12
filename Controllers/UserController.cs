using ecommerceAPI.Application.DTOs.User;
using ecommerceAPI.Application.Interfaces.Services;
using ecommerceAPI.Domain.Entities;
using ecommerceAPI.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
//using System.Web.Http;

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly UserManager<User> userManager;

        public UserController(IUserService service,UserManager<User> user)
        {
            this.service = service;
            this.userManager = user;
        }
        [HttpGet("Profile")]
        [Authorize]
        public async Task<ActionResult> GetProfile()
        {
            //Free the Claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userProfile = await service.GetUserProfile(userId);
            if (userProfile == null)
                return NotFound();
            return Ok(userProfile);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> GetAllUsers()
        {
            var Users = service.GetAllUsersAsync();
            return Ok(Users);
        }
        [HttpPut("Profile")]
        [Authorize]
        public async Task<ActionResult> UpdateProfile(UpdateUserDto updateUserDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var updatedProfile = await service.UpdateUserProfile(userId, updateUserDto);
            if (updatedProfile == null) return NotFound();
            return Ok(updatedProfile);
        }

    }
}
