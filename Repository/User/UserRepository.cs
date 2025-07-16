using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

        public async Task<IEnumerable<Role>> GetSpecificRolesAsync(params string[] roleNames)
        {
            return await _context.Roles
                                .Where(r => roleNames.Contains(r.RoleName))
                                .ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Checklogin(string email, string password)
        {

            User exitingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (exitingUser == null)
            {
                return null;
            }
           // check the password user input and the hashpassword in the database are the same ??
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, exitingUser.PasswordHash);

            if (isPasswordValid)
            {

                return exitingUser;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> RegisterNewUser(User newUser, string confirmPassword)
        {
            if (newUser == null)
            {
                return null;
            }

            bool checkEmail = await _context.Users.AnyAsync(u => u.Email == newUser.Email);

            if (checkEmail) {
                throw new ArgumentException("Email already exists.");
            }

            if (newUser.PasswordHash != confirmPassword)
            {
                throw new ArgumentException("Passwords do not match.");
            }
            // after checking confirm password , then hash the password
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);

            await _context.Users.Add(newUser);
            _context.SaveChangesAsync();
            return newUser;
        }
    }
}
