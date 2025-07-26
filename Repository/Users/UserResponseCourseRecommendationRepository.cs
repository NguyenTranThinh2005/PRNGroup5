using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Users
{
    public class UserResponseCourseRecommendationRepository : IUserResponseCourseRecommendationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserResponseCourseRecommendationRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<UserResponseCourseRecommendation> AddUserResponseAsync(UserResponseCourseRecommendation userResponseCourseRecommendation)
        {
            await _context.UserResponseCourseRecommendations.AddAsync(userResponseCourseRecommendation);
            await _context.SaveChangesAsync();
            return userResponseCourseRecommendation;
        }

        public async Task<UserResponseCourseRecommendation> DeleteUserResponseAsync(Guid userRecId)
        {
            var userResponse = await _context.UserResponseCourseRecommendations.FindAsync(userRecId);
            if(userResponse != null)
            {
                _context.UserResponseCourseRecommendations.Remove(userResponse);
                await _context.SaveChangesAsync();
                return userResponse;
            }
            return null;
        }

        public async Task<UserResponseCourseRecommendation> GetRecommendationsByUserRecIdAsync(Guid userRecId)
        {
            var userResponse = await _context.UserResponseCourseRecommendations
                .FirstOrDefaultAsync(ur => ur.UserRecId == userRecId);
            if (userResponse != null)
            {
                return userResponse;
            }
            return null;
        }

        public async Task<IEnumerable<UserResponseCourseRecommendation>> GetUsersResponseByResponseIdAsync(Guid responseId)
        {
            return await _context.UserResponseCourseRecommendations
                .Where(ur => ur.ResponseId == responseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserResponseCourseRecommendation>> GetUsersResponseByResponseIdWithCoursesAsync(Guid responseId)
        {
            return await _context.UserResponseCourseRecommendations
                .Include(ur => ur.Course) 
                .Where(ur => ur.ResponseId == responseId)
                .ToListAsync();
        }

        public async Task<UserResponseCourseRecommendation> UpdateUserResponseAsync(UserResponseCourseRecommendation userResponseCourseRecommendation)
        {
            _context.UserResponseCourseRecommendations.Update(userResponseCourseRecommendation);
            await _context.SaveChangesAsync();
            return userResponseCourseRecommendation;
        }
    }
}
