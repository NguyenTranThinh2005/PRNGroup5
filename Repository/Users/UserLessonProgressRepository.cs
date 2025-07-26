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

namespace DataAccess.Users
{
    public class UserLessonProgressRepository : IUserLessonProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public UserLessonProgressRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<UserLessonProgress> AddUserLessonProgressAsync(UserLessonProgress userLessonProgress)
        {
            await _context.UserLessonProgresses.AddAsync(userLessonProgress);
            await _context.SaveChangesAsync();
            return userLessonProgress;
        }

        public async Task<int> CountCompletedLessonsForUserInCourseAsync(Guid userId, Guid courseId)
        {
            return await _context.UserLessonProgresses
                .CountAsync(ulp => ulp.UserId == userId && ulp.Passed && ulp.Lesson.CourseWeek.CourseId == courseId);
        }

        public async Task<UserLessonProgress> DeleteUserLessonProgressAsync(Guid progressId)
        {
            var userLessonProgress = await _context.UserLessonProgresses.FirstOrDefaultAsync(ulp => ulp.ProgressId == progressId);
            if(userLessonProgress != null)
            {
                _context.Remove(userLessonProgress);
                await _context.SaveChangesAsync();
                return userLessonProgress;
            }
            return null;
        }

        public async Task<List<UserLessonProgress>> GetAllUserLessonProgressesByUserIdAsync(Guid userId)
        {
            return await _context.UserLessonProgresses
           .Where(ulp => ulp.UserId == userId)
           .Include(ulp => ulp.Lesson)
               .ThenInclude(l => l.CourseWeek)
           .ToListAsync();
        }

        public async Task<UserLessonProgress?> GetUserLessonProgressByIdAsync(Guid progressId)
        {
            return await _context.UserLessonProgresses.FirstOrDefaultAsync(ulp => ulp.ProgressId == progressId);
        }

        public async Task<IEnumerable<UserLessonProgress>> GetUserLessonProgressByLessonIdAsync(Guid lessonId)
        {
            return await _context.UserLessonProgresses.Where(ulp => ulp.LessonId == lessonId).ToListAsync();
            
        }

        public async Task<List<UserLessonProgress>> GetUserLessonProgressByUserIdAndCourseIdAsync(Guid userId, Guid courseId)
        {
            return await _context.UserLessonProgresses
            .Where(ulp => ulp.UserId == userId && ulp.Lesson.CourseWeek.CourseId == courseId)
            .ToListAsync();
        }

        public async Task<UserLessonProgress?> GetUserLessonProgressByUserIdAndLessonIdAsync(Guid userId, Guid lessonId)
        {
            return await _context.UserLessonProgresses
                        .FirstOrDefaultAsync(ulp => ulp.UserId == userId && ulp.LessonId == lessonId);
        }

        public async Task<IEnumerable<UserLessonProgress>> GetUserLessonProgressByUserIdAsync(Guid userId)
        {
            return await _context.UserLessonProgresses.Where(ulp => ulp.UserId == userId)
                .ToListAsync();
        }

        public  async Task<IEnumerable<UserLessonProgress>> GetUserLessonProgressesAsync()
        {
            return await _context.UserLessonProgresses.ToListAsync();
        }

        public async Task<UserLessonProgress> UpdateUserLessonProgressAsync(UserLessonProgress userLessonProgress)
        {
            _context.UserLessonProgresses.Update(userLessonProgress);
            await _context.SaveChangesAsync();
            return userLessonProgress;
        }
    }
}
