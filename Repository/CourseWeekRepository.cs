using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class CourseWeekRepository : ICourseWeekRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseWeekRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CourseWeek> AddNewCourseWeek(CourseWeek courseWeek)
        {
            await _context.CourseWeeks.AddAsync(courseWeek);
            await _context.SaveChangesAsync();
            return courseWeek;
        }

        public async Task<IEnumerable<CourseWeek>> GetAllCourseWeeksAsync()
        {
            return await _context.CourseWeeks.Include(cw => cw.Lessons).ToListAsync();
        }

        public async Task<CourseWeek?> GetCourseWeekByIdAsync(Guid id)
        {
            return await _context.CourseWeeks.Include(cw => cw.Lessons).FirstOrDefaultAsync(cw => cw.WeekId == id);
        }

        public async Task DeleteCourseWeekByIdAsync(Guid id)
        {
            var courseWeek = await _context.CourseWeeks.FindAsync(id);
            if (courseWeek != null)
            {
                _context.CourseWeeks.Remove(courseWeek);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCourseWeekAsync(CourseWeek courseWeek)
        {
            _context.CourseWeeks.Update(courseWeek);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseWeek>> GetCourseWeeksByCourseIdWithLessonsAsync(Guid courseId)
        {
            return await _context.CourseWeeks
                             .Where(cw => cw.CourseId == courseId)
                             .OrderBy(cw => cw.WeekNumber)
                             .Include(cw => cw.Lessons.OrderBy(l => l.Sequence)) 
                             .ToListAsync();
        }
    }
} 