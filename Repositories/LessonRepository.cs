using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> AddNewLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            return await _context.Lessons.Include(l => l.LessonResources).ToListAsync();
        }

        public async Task<Lesson?> GetLessonByIdAsync(Guid id)
        {
            return await _context.Lessons.Include(l => l.LessonResources)
                .Include(l => l.CourseWeek) 
                .ThenInclude(cw => cw.Course) 
                    .ThenInclude(c => c.CourseWeeks) 
                        .ThenInclude(cw => cw.Lessons) 
            .Include(l => l.UserLessonProgresses)
                .FirstOrDefaultAsync(l => l.LessonId == id);
        }

        public async Task DeleteLessonByIdAsync(Guid id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }
    }
} 