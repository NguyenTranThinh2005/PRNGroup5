using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class LessonResourceRepository : ILessonResourceRepository
    {
        private readonly ApplicationDbContext _context;

        public LessonResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LessonResource> AddNewLessonResource(LessonResource lessonResource)
        {
            await _context.LessonResources.AddAsync(lessonResource);
            await _context.SaveChangesAsync();
            return lessonResource;
        }

        public async Task<IEnumerable<LessonResource>> GetAllLessonResourcesAsync()
        {
            return await _context.LessonResources.Include(lr => lr.Lesson).ToListAsync();
        }

        public async Task<LessonResource?> GetLessonResourceByIdAsync(Guid id)
        {
            return await _context.LessonResources.Include(lr => lr.Lesson).FirstOrDefaultAsync(lr => lr.ResourceId == id);
        }

        public async Task DeleteLessonResourceByIdAsync(Guid id)
        {
            var lessonResource = await _context.LessonResources.FindAsync(id);
            if (lessonResource != null)
            {
                _context.LessonResources.Remove(lessonResource);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateLessonResourceAsync(LessonResource lessonResource)
        {
            _context.LessonResources.Update(lessonResource);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LessonResource>> GetResourcesByLessonIdAsync(Guid lessonId)
        {
            return await _context.LessonResources
                            .Where(lr => lr.LessonId == lessonId)
                            .ToListAsync();
        }
    }
} 