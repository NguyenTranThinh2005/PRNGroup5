using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ICourseCertificateRepository
    {
        Task<CourseCertificate> AddAsync(CourseCertificate entity);
        Task<IEnumerable<CourseCertificate>> GetAllAsync();
        Task<CourseCertificate?> GetByIdAsync(Guid id);
        Task UpdateAsync(CourseCertificate entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<CourseCertificate>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<CourseCertificate>> GetByCourseIdAsync(Guid courseId);
        Task<CourseCertificate?> GetByUserIdAndCourseIdAsync(Guid userId, Guid courseId);
    }
} 