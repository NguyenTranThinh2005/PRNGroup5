using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IProgramParticipantRepository
    {
        Task<IEnumerable<ProgramParticipant>> GetAllAsync();
        Task<ProgramParticipant?> GetByIdAsync(Guid id);
        Task<ProgramParticipant> CreateAsync(ProgramParticipant participant);
        Task UpdateAsync(ProgramParticipant participant);
        Task DeleteAsync(Guid id);
    }
}
