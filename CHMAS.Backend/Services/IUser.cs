using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHMAS.Backend.DTO;
using CHMAS.Backend.Models;

namespace CHMAS.Backend.Services
{
    public interface IUser
    {
        Task<List<DisplayUserDto>> CreateUserAsync(CreateUserDto user);
        Task<List<DisplayUserDto>> UpdateUserAsync(int Id, CreateUserDto user);
        Task<List<DisplayUserDto>> DeleteUserAsync(int id);
        Task<List<DisplayUserDto>> GetAllUsersAsync();
        Task<DisplayUserDto> GetUserByIdAsync(int id);
    }
}