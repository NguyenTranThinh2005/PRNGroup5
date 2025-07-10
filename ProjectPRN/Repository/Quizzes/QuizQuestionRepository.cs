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
    public class QuizQuestionRepository :IQuizQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public QuizQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<QuizQuestion>> GetAllAsync()
        {
            return await _context.QuizQuestions.ToListAsync();
        }
        public async Task<QuizQuestion?> GetByIdAsync(Guid id)
        {
            return await _context.QuizQuestions.FirstOrDefaultAsync(q => q.QuestionId == id);
        }
        public async Task<QuizQuestion> CreateAsync(QuizQuestion question)
        {
            await _context.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }
        public async Task UpdateAsync(QuizQuestion question)
        {
            _context.QuizQuestions.Update(question);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var question = _context.QuizQuestions.FirstOrDefault(q => q.QuestionId == id);
            if (question != null)
            {
                _context.QuizQuestions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

    }
}
