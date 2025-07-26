using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> AddUserProfileAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public async Task DeleteUserProfileAsync(Guid id)
        {
            var user = await _context.UserProfiles.FindAsync(id);
            if (user != null)
            {
                _context.UserProfiles.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        //public async Task DeleteUserProfileAsync(Guid id)
        //{
        //    var userProfile = await _context.UserProfiles.FindAsync(id);
        //    if (userProfile != null)
        //    {
        //        _context.UserProfiles.Remove(userProfile);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task<IEnumerable<UserProfile>> GetAllUsersProfileAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        } //lấy toàn bộ user profile của các user

        public async Task<UserProfile?> GetUserProfileByEmailAsync(string email)
        {
            var user = await _context.Users.Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.Email == email);
            return user?.UserProfile;
        }

        public async Task<UserProfile?> GetUserProfileByIdAsync(Guid id)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(up => up.ProfileId.Equals(id));
            return userProfile;
        }
        public async Task<UserProfile?> GetUserProfileByUserIdAsync(Guid userId)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(up => up.UserId.Equals(userId));
            return userProfile;
        }

        public async Task<UserProfile?> GetUserProfileByUsernameAsync(string username)
        {
            var user = await _context.Users.Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.Username == username);
            return user?.UserProfile;
        }

        public async Task UpdateUserProfileAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();
        }
    }
}

