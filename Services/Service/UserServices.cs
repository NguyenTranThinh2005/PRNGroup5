
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;
using Models.Users;

namespace Services.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _repository.GetUserByEmailAsync(email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _repository.GetUserByUsernameAsync(username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _repository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _repository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _repository.DeleteUserAsync(id);
        }

        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _repository.GetRoleByIdAsync(roleId);
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _repository.GetRoleByNameAsync(roleName);
        }

        public async Task<IEnumerable<Role>> GetSpecificRolesAsync(params string[] roleNames)
        {
            return await _repository.GetSpecificRolesAsync(roleNames);
        }
    }
}
