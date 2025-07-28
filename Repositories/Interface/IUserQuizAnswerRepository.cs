using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;
using Models.Users;

namespace Repositories.Interface.UserRepo
{
    public interface IUserQuizAnswerRepository
    {
        Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersAsync();
        Task<UserQuizAnswer?> GetUserQuizAnswerByIdAsync(Guid userQuizAnswerId);
        Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersByUserIdAsync(Guid userId);
        Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersByQuestionIdAsync(Guid questionId);
        Task<UserQuizAnswer> AddUserQuizAnswerAsync(UserQuizAnswer userQuizAnswer);
        Task<UserQuizAnswer> UpdateUserQuizAnswerAsync(UserQuizAnswer userQuizAnswer);
        Task<UserQuizAnswer> DeleteUserQuizAnswerAsync(Guid userQuizAnswerId);
        Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersByUserIdAndQuizIdAsync(Guid userId, Guid quizId);

        Task<IEnumerable<UserQuizAnswer>> GetUserQuizAnswersForQuizAttemptAsync(Guid userId, Guid quizId, DateTime takenAt);
    }
}
