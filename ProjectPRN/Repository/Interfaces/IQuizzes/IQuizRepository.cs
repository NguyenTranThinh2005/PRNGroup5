using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces.IQuizzes
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task<Quiz?> GetByIdAsync(Guid id);
        Task<Quiz> CreateAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(Guid id);
        Task<Quiz?> GetQuizByLessonIdAsync(Guid lessonId);
        Task<Quiz?> GetQuizWithQuestionsAndOptionsByLessonIdAsync(Guid lessonId);
    }
}
