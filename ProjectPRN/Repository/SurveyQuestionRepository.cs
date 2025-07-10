using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class SurveyQuestionRepository :ISurveyQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public SurveyQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SurveyQuestion>> GetAllSurveyQuestionsAsync()
        {

            return await _context.SurveyQuestions.ToListAsync();
        }
        public async Task<SurveyQuestion?> GetSurveyQuestionByIdAsync(Guid id)
        {
            return await _context.SurveyQuestions.FirstOrDefaultAsync(s => s.QuestionId == id);
        }

        public async Task<IEnumerable<SurveyQuestion>> GetSurveyQuestionsBySurveyIdAsync(Guid surveyId)
        {
            return await _context.SurveyQuestions.Where(sq => sq.SurveyId == surveyId).ToListAsync();
        }
        public async Task UpdateSurveyQuestion(SurveyQuestion question)
        {
            _context.SurveyQuestions.Update(question);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSurveyQuestionAsync(Guid id)
        {
            var surveyQuestion = await _context.SurveyQuestions.FindAsync(id);
            if (surveyQuestion != null)
            {
                _context.SurveyQuestions.Remove(surveyQuestion);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<SurveyQuestion> AddSurveyQuestionAsync(SurveyQuestion question)
        {
            await _context.SurveyQuestions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<IEnumerable<SurveyQuestion>> GetSurveyQuestionsWithAllDetailsBySurveyIdAsync(Guid surveyId)
        {
            return await _context.SurveyQuestions
                .Where(q => q.SurveyId == surveyId)
                .Include(q => q.SurveyOptions.OrderBy(o => o.CreatedAt))
                .OrderBy(q => q.Sequence)
                .ToListAsync();
        }
    }
   
}

