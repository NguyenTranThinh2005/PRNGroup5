using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IBlogRepository
    {
        Task<Blog> CreateAsync(Blog blog);
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(Guid id);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(Guid id);
    }
}
