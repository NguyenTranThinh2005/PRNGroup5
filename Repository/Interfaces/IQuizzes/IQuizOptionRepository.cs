using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces.IQuizzes
{
    public interface IQuizOptionRepository
    {
        Task<IEnumerable<QuizOption>> GetAllAsync();
        Task<QuizOption?> GetByIdAsync(Guid id);
        Task<QuizOption> CreateAsync(QuizOption option);
        Task UpdateAsync(QuizOption option);
        Task DeleteAsync(Guid id);
    }
}
