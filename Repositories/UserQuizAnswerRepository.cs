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
    public class UserQuizAnswerRepository : IUserQuizAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public UserQuizAnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserQuizAnswer> AddUserQuizAnswerAsync(UserQuizAnswer userQuizAnswer)
        {
            await _context.UserQuizAnswers.AddAsync(userQuizAnswer);
            await _context.SaveChangesAsync();
            return userQuizAnswer;
        }

        public async Task<UserQuizAnswer> DeleteUserQuizAnswerAsync(Guid userQuizAnswerId)
        {
            var tmp = await _context.UserQuizAnswers.FirstOrDefaultAsync(qa => qa.UserQuizAnswerId == userQuizAnswerId);
            _context.UserQuizAnswers.Remove(tmp);
            return tmp;
        }

        public async Task<UserQuizAnswer?> GetUserQuizAnswerByIdAsync(Guid userQuizAnswerId)
        {
            return await _context.UserQuizAnswers
                .FirstOrDefaultAsync(tmp => tmp.UserQuizAnswerId == userQuizAnswerId);
        }

        public async Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersAsync()
        {
            return await _context.UserQuizAnswers.ToListAsync();
        }

        public async Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersByQuestionIdAsync(Guid questionId)
        {
            return await _context.UserQuizAnswers
                .Where(qa => qa.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersByUserIdAndQuizIdAsync(Guid userId, Guid quizId)
        {
            return await _context.UserQuizAnswers
                                 .Where(ua => ua.UserId == userId &&
                                              ua.QuizQuestion.QuizId == quizId) 
                                 .ToListAsync();
        }

        public async Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersByUserIdAsync(Guid userId)
        {
            return await _context.UserQuizAnswers
                .Where(qa => qa.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersForQuizAttemptAsync(Guid userId, Guid quizId, DateTime takenAt)
        {
            return await _context.UserQuizAnswers
                                 .Include(ua => ua.QuizQuestion) 
                                 .Where(ua => ua.UserId == userId &&
                                              ua.QuizQuestion.QuizId == quizId && 
                                              ua.AnsweredAt == takenAt)          
                                 .ToListAsync();
        }

        public async Task<UserQuizAnswer> UpdateUserQuizAnswerAsync(UserQuizAnswer userQuizAnswer)
        {
            _context.UserQuizAnswers.Update(userQuizAnswer);
            await _context.SaveChangesAsync();
            return userQuizAnswer;
        }
    }
}
