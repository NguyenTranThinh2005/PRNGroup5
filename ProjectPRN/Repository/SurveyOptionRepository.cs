using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class SurveyOptionRepository : ISurveyOptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SurveyOptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SurveyOption>> GetAllAsync()
        {
            return await _context.SurveyOptions
                .Include(so => so.SurveyQuestion)
                .ToListAsync();
        }

        public async Task<SurveyOption?> GetByIdAsync(Guid id)
        {
            return await _context.SurveyOptions
                .Include(so => so.SurveyQuestion)
                .FirstOrDefaultAsync(so => so.OptionId == id);
        }

        public async Task<SurveyOption> CreateAsync(SurveyOption surveyOption)
        {
            _context.SurveyOptions.Add(surveyOption);
            await _context.SaveChangesAsync();
            return surveyOption;
        }

        public async Task<SurveyOption> UpdateAsync(SurveyOption surveyOption)
        {
            _context.Entry(surveyOption).State = EntityState.Modified;
            surveyOption.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return surveyOption;
        }

        public async Task DeleteAsync(Guid id)
        {
            var surveyOption = await _context.SurveyOptions.FindAsync(id);
            if (surveyOption != null)
            {
                _context.SurveyOptions.Remove(surveyOption);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SurveyOption>> GetByQuestionIdAsync(Guid questionId)
        {
            return await _context.SurveyOptions
                .Where(so => so.QuestionId == questionId)
                .ToListAsync();
        }
    }
} 