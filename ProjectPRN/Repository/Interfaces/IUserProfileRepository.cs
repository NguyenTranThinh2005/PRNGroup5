using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAllUsersProfileAsync();
        Task<UserProfile?> GetUserProfileByIdAsync(Guid id);
        Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId);
        Task<UserProfile?> GetUserProfileByEmailAsync(string email);
        Task<UserProfile?> GetUserProfileByUsernameAsync(string username);
        Task<UserProfile> AddUserProfileAsync(UserProfile userProfile);
        Task UpdateUserProfileAsync(UserProfile userProfile);
        Task DeleteUserProfileAsync(Guid id);
    }
}
