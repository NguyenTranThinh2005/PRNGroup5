using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Migrations;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces.IQuizzes;
using Microsoft.EntityFrameworkCore;

namespace DrugPreventionSystem.DataAccess.Repository.Quizzes
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        public QuizRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }
        public async Task<Quiz?> GetByIdAsync(Guid id)
        {
            return await _context.Quizzes
                .Include(q => q.QuizQuestions.OrderBy(qq => qq.Sequence)) 
                 .ThenInclude(qq => qq.QuizOptions)
                .FirstOrDefaultAsync(q => q.QuizId == id);
        }
        public async Task<Quiz> CreateAsync(Quiz quiz)
        {
            await _context.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }
        public async Task UpdateAsync(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();          
        }
        public async Task DeleteAsync(Guid id)
        {
            var quiz = _context.Quizzes.FirstOrDefault(q=>q.QuizId == id);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Quiz?> GetQuizByLessonIdAsync(Guid lessonId)
        {
            return await _context.Quizzes
                                 .Where(q => q.LessonId == lessonId)
                                 .Include(q => q.QuizQuestions.OrderBy(qq => qq.Sequence))
                                     .ThenInclude(qq => qq.QuizOptions)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Quiz?> GetQuizWithQuestionsAndOptionsByLessonIdAsync(Guid lessonId)
        {
            return await _context.Quizzes
        .Include(q => q.QuizQuestions.OrderBy(qq => qq.Sequence))
            .ThenInclude(qq => qq.QuizOptions)
        .FirstOrDefaultAsync(q => q.LessonId == lessonId);
        }
    }
}
