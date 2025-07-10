using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces.IQuizzes;
using Microsoft.EntityFrameworkCore;

namespace DrugPreventionSystem.DataAccess.Repository.Quizzes
{
    public class QuizOptionRepository : IQuizOptionRepository
    {               
            private readonly ApplicationDbContext _context;
            public QuizOptionRepository(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<QuizOption>> GetAllAsync()
            {
                return await _context.QuizOptions.ToListAsync();
            }
            public async Task<QuizOption?> GetByIdAsync(Guid id)
            {
                return await _context.QuizOptions.FirstOrDefaultAsync(q => q.OptionId == id);
            }
            public async Task<QuizOption> CreateAsync(QuizOption option)
            {
                await _context.AddAsync(option);
                await _context.SaveChangesAsync();
                return option;
            }
            public async Task UpdateAsync(QuizOption option)
            {
                _context.QuizOptions.Update(option);
                await _context.SaveChangesAsync();
            }
            public async Task DeleteAsync(Guid id)
            {
                var option = _context.QuizOptions.FirstOrDefault(q => q.OptionId == id);
                if (option != null)
                {
                    _context.QuizOptions.Remove(option);
                    await _context.SaveChangesAsync();
                }
            }
        
    }
}
