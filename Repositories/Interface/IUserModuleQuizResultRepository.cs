using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;
using Models.Users;

namespace Repositories.Interface.UserRepo
{
    public interface IUserModuleQuizResultRepository
    {
        Task<IEnumerable<UserModuleQuizResult>> GetUserModuleQuizResultsAsync();
        Task<UserModuleQuizResult?> GetUserModuleQuizResultByIdAsync(Guid resultId);
        Task<IEnumerable<UserModuleQuizResult>> GetUserModuleQuizResultsByUserIdAsync(Guid userId);
        Task<IEnumerable<UserModuleQuizResult>> GetUserModuleQuizResultsByLessonIdAsync(Guid lessonId);
        Task<UserModuleQuizResult> AddUserModuleQuizResultAsync(UserModuleQuizResult userModuleQuizResult);
        Task<UserModuleQuizResult> UpdateUserModuleQuizResultAsync(UserModuleQuizResult userModuleQuizResult);
        Task<UserModuleQuizResult> DeleteUserModuleQuizResultAsync(Guid resultId);
        Task<UserModuleQuizResult?> GetLatestUserModuleQuizResultForLessonAsync(Guid userId, Guid lessonId);
    }
}
