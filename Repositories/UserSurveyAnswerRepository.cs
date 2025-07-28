using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.User
{
    public class UserSurveyAnswerRepository : IUserSurveyAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public UserSurveyAnswerRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<UserSurveyAnswer> AddNewUserSurveyAnswer(UserSurveyAnswer userSurveyAnswer)
        {
            await _context.UserSurveyAnswers.AddAsync(userSurveyAnswer);
            await _context.SaveChangesAsync();
            return userSurveyAnswer;
        }

        public async Task DeleteUserSurveyAnswerByIdAsync(Guid id)
        {
            var userSurveyAnswer = await _context.UserSurveyAnswers.FindAsync(id);
            if (userSurveyAnswer == null)
            {
                throw new KeyNotFoundException($"UserSurveyAnswer with ID {id} not found.");
            }
            _context.UserSurveyAnswers.Remove(userSurveyAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserSurveyAnswer>> GetAllUserSurveyAnswersAsync()
        {
            var result = await _context.UserSurveyAnswers.ToListAsync();
            return result;
        }

        public async Task<UserSurveyAnswer?> GetUserSurveyAnswerByIdAsync(Guid id)
        {
            var result = await _context.UserSurveyAnswers.FirstOrDefaultAsync(usa => usa.AnswerId.Equals(id));
            return result;
        }

        public async Task<IEnumerable<UserSurveyAnswer>> GetUserSurveyAnswerByResponseIdAsync(Guid responseId)
        {
            return await _context.UserSurveyAnswers
                                 .Where(a => a.ResponseId == responseId)
                                 .Include(a => a.SurveyQuestion) 
                                 .Include(a => a.SurveyOption)   
                                 .ToListAsync();
        }

        public async Task<IEnumerable<UserSurveyAnswer>> GetUserSurveyAnswerByUserIdAsync(Guid userId)
        {
            var result = await _context.UserSurveyAnswers.Include(usa => usa.UserSurveyResponse)
                                                         .Where(usa => usa.UserSurveyResponse.UserId.Equals(userId)).ToListAsync();
            return result;
        }

        public async Task UpdateUserSurveyAnswerAsync(UserSurveyAnswer userSurveyAnswer)
        {
            _context.UserSurveyAnswers.Update(userSurveyAnswer);
            await _context.SaveChangesAsync();
        }
    }
}
