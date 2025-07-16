using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.User
{
    public class UserSurveyResponseRepository : IUserSurveyResponseRepository
    {
        private readonly ApplicationDbContext _context;
        public UserSurveyResponseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserSurveyResponse> CreateAsync(UserSurveyResponse response)
        {
            await _context.UserSurveyResponses.AddAsync(response);
            await _context.SaveChangesAsync();
            return response;
        }
        public async Task<IEnumerable<UserSurveyResponse>> GetAllAsync()
        {
            return await _context.UserSurveyResponses.ToListAsync();
        }
        public async Task<UserSurveyResponse?> GetByIdAsync(Guid id)
        {
            return await _context.UserSurveyResponses.FirstOrDefaultAsync(r=>r.ResponseId==id);
        }
        public async Task UpdateAsync(UserSurveyResponse response)
        {
            _context.UserSurveyResponses.Update(response);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var response = await _context.UserSurveyResponses.FindAsync(id);
            if (response != null)
            {
                _context.UserSurveyResponses.Remove(response);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserSurveyResponse?> GetByIdWithAnswersAsync(Guid id)
        {
            return await _context.UserSurveyResponses
                                 .Include(r => r.UserSurveyAnswers)
                                     .ThenInclude(a => a.SurveyOption) 
                                 .Include(r => r.UserSurveyAnswers)
                                     .ThenInclude(a => a.SurveyQuestion) 
                                 .FirstOrDefaultAsync(r => r.ResponseId == id);
        }

        public async Task<UserSurveyResponse?> GetByIdWithAnswersAndSurveyAsync(Guid responseId)
        {
            return await _context.UserSurveyResponses
                .Include(usr => usr.UserSurveyAnswers)
                    .ThenInclude(usa => usa.SurveyOption)
                .Include(usr => usr.UserSurveyAnswers)       
            .ThenInclude(usa => usa.SurveyQuestion)
                .Include(usr => usr.Survey) 
                .FirstOrDefaultAsync(usr => usr.ResponseId == responseId);
        }

        public async Task<IEnumerable<UserSurveyResponse>> GetByUserIdWithSurveyAsync(Guid userId)
        {
            return await _context.UserSurveyResponses
                 .Where(usr => usr.UserId == userId)
                 .Include(usr => usr.Survey) 
                 .Include(usr => usr.UserSurveyAnswers) 
                     .ThenInclude(usa => usa.SurveyOption) 
                 .OrderByDescending(usr => usr.TakenAt) 
                 .ToListAsync();
        }
    }
}
