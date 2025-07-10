using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IUserSurveyResponseRepository
    {
        Task<UserSurveyResponse> CreateAsync(UserSurveyResponse response);
        Task<IEnumerable<UserSurveyResponse>> GetAllAsync();
        Task<UserSurveyResponse?> GetByIdAsync(Guid id);
        Task UpdateAsync(UserSurveyResponse response);
        Task DeleteAsync(Guid id);
        Task<UserSurveyResponse?> GetByIdWithAnswersAsync(Guid id);
        Task<UserSurveyResponse?> GetByIdWithAnswersAndSurveyAsync(Guid responseId);
        Task<IEnumerable<UserSurveyResponse>> GetByUserIdWithSurveyAsync(Guid userId);
    }
}
