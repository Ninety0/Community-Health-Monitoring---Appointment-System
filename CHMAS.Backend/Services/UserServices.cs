using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHMAS.Backend.Data;
using CHMAS.Backend.DTO;
using CHMAS.Backend.Models;

namespace CHMAS.Backend.Services
{
    public class UserServices : IUser
    {
        private readonly DataContext _context;

        private string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public UserServices(DataContext context)
        {
            _context = context;
        }

        private static DisplayUserDto ToUserDto(User user)
        {
            return new DisplayUserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                FullName = user.FullName,
                Phone = user.Phone,
                CreatedAt = user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

        public async Task<List<DisplayUserDto>> CreateUserAsync(CreateUserDto user)
        {
            var newUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (newUser != null)
                return null;

            await _context.Users.AddAsync(new User
            {
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                FullName = user.FullName,
                Phone = user.Phone,
                CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
            return (await _context.Users.ToListAsync()).Select(ToUserDto).ToList();
        }

        public async Task<List<DisplayUserDto>> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return (await _context.Users.ToListAsync()).Select(ToUserDto).ToList();
        }

        public async Task<List<DisplayUserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(ToUserDto).ToList();
        }

        public async Task<DisplayUserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return ToUserDto(user);
        }

        public async Task<List<DisplayUserDto>> UpdateUserAsync(int Id, CreateUserDto userDto)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null) return null;

            var existingEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email && u.Id != Id);
            
            if (existingEmail != null)
                return null; // Email already exists

            user.Email = userDto.Email;
            user.Role = userDto.Role;       
            user.FullName = userDto.FullName;
            user.Phone = userDto.Phone;

            // Only update password if it's provided    
            if (!string.IsNullOrWhiteSpace(userDto.Password))
                userDto.Password = userDto.Password; 

            await _context.SaveChangesAsync();
            return (await _context.Users.ToListAsync()).Select(ToUserDto).ToList();
        }
    }
}