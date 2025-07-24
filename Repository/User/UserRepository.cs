using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Users.User> AddUserAsync(Models.Users.User user)
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

        public async Task<IEnumerable<Models.Users.User>> GetAllUsersAsync()
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

        public async Task<Models.Users.User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Models.Users.User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<Models.Users.User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task UpdateUserAsync(Models.Users.User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Models.Users.User> Checklogin(string email, string password)
        {

            Models.Users.User exitingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

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

        public async Task<Models.Users.User> RegisterNewUser(Models.Users.User newUser, string confirmPassword)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "User data must not be null.");
            }

            // Trim and normalize input
            newUser.Email = newUser.Email?.Trim().ToLower();
            newUser.Username = newUser.Username?.Trim();

            // Basic validation
            if (string.IsNullOrWhiteSpace(newUser.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            if (!IsValidEmail(newUser.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (string.IsNullOrWhiteSpace(newUser.Username))
            {
                throw new ArgumentException("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(newUser.PasswordHash))
            {
                throw new ArgumentException("Password is required.");
            }

            if (newUser.PasswordHash != confirmPassword)
            {
                throw new ArgumentException("Passwords do not match.");
            }

            // Check email uniqueness
            bool emailExists = await _context.Users.AnyAsync(u => u.Email == newUser.Email);
            if (emailExists)
            {
                throw new ArgumentException("Email already exists.");
            }

            // Hash password
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);

            // Save user
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
