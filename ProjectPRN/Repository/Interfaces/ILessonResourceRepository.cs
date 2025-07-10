using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ILessonResourceRepository
    {
        Task<LessonResource> AddNewLessonResource(LessonResource lessonResource);
        Task<IEnumerable<LessonResource>> GetAllLessonResourcesAsync();
        Task<LessonResource?> GetLessonResourceByIdAsync(Guid id);

        Task<IEnumerable<LessonResource>> GetResourcesByLessonIdAsync(Guid lessonId);

        Task DeleteLessonResourceByIdAsync(Guid id);
        Task UpdateLessonResourceAsync(LessonResource lessonResource);
    }
} 