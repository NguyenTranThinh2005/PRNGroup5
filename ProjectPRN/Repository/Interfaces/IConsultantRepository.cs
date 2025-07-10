using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IConsultantRepository
    {
        Task<IEnumerable<Consultant>> GetAllConsultantsAsync();
        Task<Consultant?> GetConsultantByIdAsync(Guid id);
        Task<Consultant> AddConsultant(Consultant consultant);
        Task UpdateConsultantAsync(Consultant consultant);
        Task DeleteConsultantAsync(Guid id);
    }
}
