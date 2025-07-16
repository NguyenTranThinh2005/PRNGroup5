using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IPracticeExerciseRepository
    {
        Task<PracticeExercise> AddAsync(PracticeExercise entity);
        Task<IEnumerable<PracticeExercise>> GetAllAsync();
        Task<PracticeExercise?> GetByIdAsync(Guid id);
        Task UpdateAsync(PracticeExercise entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<PracticeExercise>> GetByLessonIdAsync(Guid lessonId);
    }
} 