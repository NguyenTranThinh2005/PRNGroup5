using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Interface.LessonRepo
{
    public interface ILessonRepository
    {
        Task<Lesson> AddNewLesson(Lesson lesson);
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        Task<Lesson?> GetLessonByIdAsync(Guid id);
        Task DeleteLessonByIdAsync(Guid id);
        Task UpdateLessonAsync(Lesson lesson);
    }
} 