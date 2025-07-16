using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ISurveyQuestionRepository
    {
        Task<IEnumerable<SurveyQuestion>> GetAllSurveyQuestionsAsync();
        Task<SurveyQuestion?> GetSurveyQuestionByIdAsync(Guid id);
        Task<IEnumerable<SurveyQuestion>> GetSurveyQuestionsBySurveyIdAsync(Guid surveyId);
        Task<SurveyQuestion> AddSurveyQuestionAsync(SurveyQuestion question);
        Task UpdateSurveyQuestion(SurveyQuestion question);
        Task DeleteSurveyQuestionAsync(Guid id);
        Task<IEnumerable<SurveyQuestion>> GetSurveyQuestionsWithAllDetailsBySurveyIdAsync(Guid surveyId);
    }
}
