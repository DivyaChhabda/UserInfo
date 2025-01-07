using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserInfo.Models;

namespace UserInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserData : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserData(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.UserInfos.ToListAsync();
            return Ok(users);
        }
        [HttpGet("GetUserByID/{id}")]
        public async Task<IActionResult> GetUserByID(int id)
        {
            var user = await _context.UserInfos.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInfo.Models.UserInfo updatedUser)
        {
            var user = await _context.UserInfos.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            // Update user properties
            user.UserType = updatedUser.UserType;
            user.UserEmail = updatedUser.UserEmail;
            user.DateLastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(new { Message = "User updated successfully", UpdatedUser = user });
        }
    }
}
