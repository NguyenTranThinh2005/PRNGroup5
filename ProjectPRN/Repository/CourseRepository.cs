using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Course> CreateAsync(Course response )
        {
            await _context.Courses.AddAsync(response);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
           return await _context.Courses
                .Include(c => c.Instructor)
                .Where(c => c.IsActive)
                .ToListAsync();
        }
        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses
                .Include(c => c.CourseWeeks)
                .ThenInclude(cw => cw.Lessons)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(c => c.CourseId == id);
        }
        public async Task UpdateAsync(Course response)
        {
            _context.Courses.Update(response);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var response = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
            if (response != null)
            {
                _context.Courses.Remove(response);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Course>> GetAllActiveCoursesWithInstructorsAsync(string? ageGroup = null)
        {
            var query = _context.Courses.Include(c => c.Instructor).Where(c => c.IsActive);
            if (!string.IsNullOrEmpty(ageGroup))
            {
                query = query.Where(c => c.AgeGroup != null &&
                                 EF.Functions.Like(c.AgeGroup, $"%{ageGroup}%"));
            }
            return await query.ToListAsync();
        }

        public async Task<Course?> GetCourseContentForEditAsync(Guid courseId)
        {
            return await _context.Courses
         .Include(c => c.Instructor)
         .Include(c => c.CourseWeeks.OrderBy(cw => cw.WeekNumber))
             .ThenInclude(cw => cw.Lessons.OrderBy(l => l.Sequence))
                 .ThenInclude(l => l.LessonResources)
         
         .FirstOrDefaultAsync(c => c.CourseId == courseId);
        }
    }
}
