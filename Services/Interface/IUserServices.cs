using DrugPreventionSystem.DataAccess.Models;
using Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<Role?> GetRoleByIdAsync(int roleId);
        Task<Role?> GetRoleByNameAsync(string roleName);
        Task<IEnumerable<Role>> GetSpecificRolesAsync(params string[] roleNames);
        Task<User> Login(string email, string password);
        Task Register(User newUser);
    }
}
