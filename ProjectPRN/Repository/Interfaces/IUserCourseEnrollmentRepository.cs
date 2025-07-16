using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IUserCourseEnrollmentRepository
    {
        Task<UserCourseEnrollment> AddAsync(UserCourseEnrollment entity);
        Task<IEnumerable<UserCourseEnrollment>> GetAllAsync();
        Task<UserCourseEnrollment?> GetByIdAsync(Guid id);
        Task UpdateAsync(UserCourseEnrollment entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<UserCourseEnrollment>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<UserCourseEnrollment>> GetByCourseIdAsync(Guid courseId);
        Task<UserCourseEnrollment?> GetByUserIdAndCourseIdAsync(Guid userId, Guid courseId);
    }
} 