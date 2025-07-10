using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IInstructorRepository
    {
        Task<Instructor> CreateAsync(Instructor instructor);
        Task UpdateAsync(Instructor instructor);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Instructor>> GetAllAsync();
        Task<Instructor?> GetByIdAsync(Guid id);

    }
}
