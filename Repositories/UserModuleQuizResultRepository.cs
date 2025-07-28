using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Users;

namespace DataAccess.User
{
    public class UserModuleQuizResultRepository : IUserModuleQuizResultRepository
    {
        private readonly ApplicationDbContext _context;

        public UserModuleQuizResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserModuleQuizResult> AddUserModuleQuizResultAsync(UserModuleQuizResult userModuleQuizResult)
        {
            await _context.UserModuleQuizResults.AddAsync(userModuleQuizResult);
            await _context.SaveChangesAsync();
            return userModuleQuizResult;
        }

        public async Task<UserModuleQuizResult> DeleteUserModuleQuizResultAsync(Guid resultId)
        {
            var result = await _context.UserModuleQuizResults.FindAsync(resultId);
            if(result != null)
            {
                _context.UserModuleQuizResults.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<UserModuleQuizResult?> GetLatestUserModuleQuizResultForLessonAsync(Guid userId, Guid lessonId)
        {
            return await _context.UserModuleQuizResults
                                 .Where(r => r.UserId == userId && r.LessonId == lessonId)
                                 .OrderByDescending(r => r.TakenAt) 
                                 .FirstOrDefaultAsync();
        }

        public async Task<UserModuleQuizResult?> GetUserModuleQuizResultByIdAsync(Guid resultId)
        {
            return await _context.UserModuleQuizResults.FirstOrDefaultAsync(umqr => umqr.ResultId == resultId);
        }

        public async Task<IEnumerable<UserModuleQuizResult>> GetUserModuleQuizResultsAsync()
        {
            return await _context.UserModuleQuizResults.ToListAsync();
        }

        public async Task<IEnumerable<UserModuleQuizResult>> GetUserModuleQuizResultsByLessonIdAsync(Guid lessonId)
        {
            return await _context.UserModuleQuizResults
                .Where(umqr => umqr.LessonId == lessonId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserModuleQuizResult>> GetUserModuleQuizResultsByUserIdAsync(Guid userId)
        {
            return await _context.UserModuleQuizResults
                .Where(umqr => umqr.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserModuleQuizResult> UpdateUserModuleQuizResultAsync(UserModuleQuizResult userModuleQuizResult)
        {
            _context.Update(userModuleQuizResult);
            await _context.SaveChangesAsync();
            return userModuleQuizResult;
        }
    }
}
