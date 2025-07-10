using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces.IQuizzes
{
    public interface IQuizQuestionRepository
    {
        Task<IEnumerable<QuizQuestion>> GetAllAsync();
        Task<QuizQuestion?> GetByIdAsync(Guid id);
        Task<QuizQuestion> CreateAsync(QuizQuestion quiz);
        Task UpdateAsync(QuizQuestion quiz);
        Task DeleteAsync(Guid id);
    }
}
