using ecommerceAPI.Application.DTOs.Auth;
using ecommerceAPI.Application.Interfaces.Services;
using ecommerceAPI.Application.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
//using System.Web.Http;

//[Route], [HttpPost], [Authorize] → كلهم من Microsoft.AspNetCore.*

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService service;

        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponseDTO>> Register(RegisterDTO registerDTO)
        {
            var res = await service.Register(registerDTO);
            if (!res.Success)
                return BadRequest(res.Message);
            return Ok(res.Data);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(LoginDTO loginDTO)
        {
            var res = await service.Login(loginDTO);
            if (res==null)
                return NotFound();
            return Ok(res);
        }
        [Authorize]
        [HttpPost("Logout")]
        public async Task<ActionResult> Logout(LogoutRequestDTO requestDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(string.IsNullOrEmpty(userId))
                return Unauthorized(new {message="Invalid token or user not found"});

            var res = await service.LogoutAsync(userId, requestDTO);
            if (!res.Success)
                return BadRequest(new { message = res.Message });
            return Ok(new { message = res.Message });
        }
        [Authorize]
        [HttpPost("Logout-all")]
        public async Task<ActionResult> LogoutFromAllDevices()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(string.IsNullOrEmpty(userId))
                return Unauthorized(new {message = "Invalid token or user not found"});
            var result= await service.LogoutFromAllDevicesAsync(userId);
            if(!result.Success)
                return BadRequest(new {message=result.Message});
            return Ok(new {message = result.Message});

        }
        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = await service.ChangePassword(userId, dto);
            if(!res.Success)
                return BadRequest(res.Message);
            return Ok(res.Message);

        }
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto dto)
        {
            await service.ForgetPasswordAsync(dto.Email);
            return Ok(new { message = "If email exists, reset link sent" });
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            await service.ResetPasswordAsync(dto.Email, dto.Token, dto.NewPassword);
            return Ok(new { message = "Password reset successfully" });
        }
        [HttpGet("reset-password")]
        public IActionResult ResetPassword(string email, string token)
        {
            return Ok(new
            {
                Email = email,
                Token = token
            });
        }
        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmailOnDB(string email, string token)
        {
            var result = await service.VerifyEmail(email, token);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(new { message = "Email verified successfully." });
        }
        [Authorize]
        [HttpPost("ResendVerifyEmail")]
        public async Task<IActionResult> ResendVerificationMail(string email)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "Invalid token or user not found" });

            await service.ResendVerificationEmail(email,userId);

            return Ok(new { message = "Check your email." });
        }
        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshRequestDto dto)
        {
            try
            {
                var result = await service.RefreshTokenAsync(dto.RefreshToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
