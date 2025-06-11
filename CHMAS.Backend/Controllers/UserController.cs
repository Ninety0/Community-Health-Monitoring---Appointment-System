using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHMAS.Backend.DTO;
using CHMAS.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CHMAS.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DisplayUserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DisplayUserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<DisplayUserDto>>> CreateUser([FromBody] CreateUserDto user)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            var createdUsers = await _userService.CreateUserAsync(user);
            if (createdUsers == null || !createdUsers.Any())
            {
                return BadRequest("Failed to create user.");
            }
            return CreatedAtAction(nameof(GetAllUsers), createdUsers);
            // return createdUsers;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<DisplayUserDto>>> UpdateUser(int id, [FromBody] CreateUserDto user)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            var updatedUsers = await _userService.UpdateUserAsync(id, user);
            if (updatedUsers == null || !updatedUsers.Any())
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(updatedUsers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DisplayUserDto>>> DeleteUser(int id)
        {
            var deleteUser = await _userService.DeleteUserAsync(id);
            if (deleteUser == null || !deleteUser.Any())
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(deleteUser);
        }
    }
}