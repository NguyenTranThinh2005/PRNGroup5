using DrugPreventionSystem.DataAccess.Models;
using Models.Surveys;

namespace Repositories.Interface.SurveyRepo
{
    public interface ISurveyOptionRepository
    {
        Task<IEnumerable<SurveyOption>> GetAllAsync();
        Task<SurveyOption?> GetByIdAsync(Guid id);
        Task<SurveyOption> CreateAsync(SurveyOption surveyOption);
        Task<SurveyOption> UpdateAsync(SurveyOption surveyOption);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<SurveyOption>> GetByQuestionIdAsync(Guid questionId);
    }
} 