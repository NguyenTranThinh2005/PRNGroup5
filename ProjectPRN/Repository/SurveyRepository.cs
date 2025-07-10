using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Surveys;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly ApplicationDbContext _context;

        public SurveyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Survey> AddNewSurvey(Survey survey)
        {
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task DeleteSurveyByIdAsync(Guid id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Survey>> GetAllSurveyAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<Survey?> GetSurveyByIdAsync(Guid id)
        {
            return await _context.Surveys.FirstOrDefaultAsync(s => s.SurveyId == id);
        }

        public async Task<Survey?> GetSurveyByNameAsync(string surveyName)
        {
            return await _context.Surveys.FirstOrDefaultAsync(s => s.Name == surveyName);
        }

        public async Task UpdateSurveyAsync(Survey survey)
        {
            _context.Surveys.Update(survey);
            await _context.SaveChangesAsync();
        }
    }
}
