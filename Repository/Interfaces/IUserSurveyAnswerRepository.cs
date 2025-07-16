using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IUserSurveyAnswerRepository
    {
        Task<UserSurveyAnswer> AddNewUserSurveyAnswer(UserSurveyAnswer userSurveyAnswer);
        Task<IEnumerable<UserSurveyAnswer>> GetAllUserSurveyAnswersAsync();
        Task<UserSurveyAnswer?> GetUserSurveyAnswerByIdAsync(Guid id);
        Task<IEnumerable<UserSurveyAnswer>> GetUserSurveyAnswerByUserIdAsync(Guid userId);
        Task DeleteUserSurveyAnswerByIdAsync(Guid id);
        Task UpdateUserSurveyAnswerAsync(UserSurveyAnswer userSurveyAnswer);
        Task<IEnumerable<UserSurveyAnswer>> GetUserSurveyAnswerByResponseIdAsync(Guid responseId);
    }
}
