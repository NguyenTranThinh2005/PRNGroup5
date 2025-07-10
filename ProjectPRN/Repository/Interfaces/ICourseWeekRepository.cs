using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ICourseWeekRepository
    {
        Task<CourseWeek> AddNewCourseWeek(CourseWeek courseWeek);
        Task<IEnumerable<CourseWeek>> GetAllCourseWeeksAsync();
        Task<CourseWeek?> GetCourseWeekByIdAsync(Guid id);
        Task DeleteCourseWeekByIdAsync(Guid id);
        Task UpdateCourseWeekAsync(CourseWeek courseWeek);
        Task<IEnumerable<CourseWeek>> GetCourseWeeksByCourseIdWithLessonsAsync(Guid courseId);
    }
} 