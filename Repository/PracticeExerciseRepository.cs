using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class PracticeExerciseRepository : IPracticeExerciseRepository
    {
        private readonly ApplicationDbContext _context;
        public PracticeExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PracticeExercise> AddAsync(PracticeExercise entity)
        {
            await _context.PracticeExercises.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<PracticeExercise>> GetAllAsync()
        {
            return await _context.PracticeExercises.ToListAsync();
        }
        public async Task<PracticeExercise?> GetByIdAsync(Guid id)
        {
            return await _context.PracticeExercises.FindAsync(id);
        }
        public async Task UpdateAsync(PracticeExercise entity)
        {
            _context.PracticeExercises.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.PracticeExercises.FindAsync(id);
            if (entity != null)
            {
                _context.PracticeExercises.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<PracticeExercise>> GetByLessonIdAsync(Guid lessonId)
        {
            return await _context.PracticeExercises.Where(x => x.LessonId == lessonId).ToListAsync();
        }
    }
} 