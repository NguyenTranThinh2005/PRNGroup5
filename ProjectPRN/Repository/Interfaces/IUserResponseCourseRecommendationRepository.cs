using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IUserResponseCourseRecommendationRepository
    {
        Task<UserResponseCourseRecommendation> AddUserResponseAsync(UserResponseCourseRecommendation userResponseCourseRecommendation);
        Task<UserResponseCourseRecommendation> DeleteUserResponseAsync(Guid userRecId);
        Task<UserResponseCourseRecommendation> GetRecommendationsByUserRecIdAsync(Guid userRecId);
        Task<IEnumerable<UserResponseCourseRecommendation>> GetUsersResponseByResponseIdAsync(Guid responseId);
        Task<IEnumerable<UserResponseCourseRecommendation>> GetUsersResponseByResponseIdWithCoursesAsync(Guid responseId);
        Task<UserResponseCourseRecommendation> UpdateUserResponseAsync(UserResponseCourseRecommendation userResponseCourseRecommendation);

    }
}
