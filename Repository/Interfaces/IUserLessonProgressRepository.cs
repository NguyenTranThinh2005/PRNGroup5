using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IUserLessonProgressRepository
    {
        Task<IEnumerable<UserLessonProgress>> GetUserLessonProgressesAsync();
        Task<UserLessonProgress?> GetUserLessonProgressByIdAsync(Guid progressId);
        Task<IEnumerable<UserLessonProgress>> GetUserLessonProgressByUserIdAsync(Guid userId);
        Task<IEnumerable<UserLessonProgress>> GetUserLessonProgressByLessonIdAsync(Guid lessonId);
        Task<UserLessonProgress> AddUserLessonProgressAsync(UserLessonProgress userLessonProgress);
        Task<UserLessonProgress> UpdateUserLessonProgressAsync(UserLessonProgress userLessonProgress);
        Task<UserLessonProgress> DeleteUserLessonProgressAsync(Guid progressId);
        Task<List<UserLessonProgress>> GetUserLessonProgressByUserIdAndCourseIdAsync(Guid userId, Guid courseId);
        Task<List<UserLessonProgress>> GetAllUserLessonProgressesByUserIdAsync(Guid userId);
        Task<UserLessonProgress?> GetUserLessonProgressByUserIdAndLessonIdAsync(Guid userId, Guid lessonId);

        Task<int> CountCompletedLessonsForUserInCourseAsync(Guid userId, Guid courseId);

    }
}

