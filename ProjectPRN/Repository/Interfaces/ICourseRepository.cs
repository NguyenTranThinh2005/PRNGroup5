using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id);
        Task<IEnumerable<Course>> GetAllActiveCoursesWithInstructorsAsync(string? ageGroup = null);
        Task<Course?> GetCourseContentForEditAsync(Guid courseId);
    }
}
