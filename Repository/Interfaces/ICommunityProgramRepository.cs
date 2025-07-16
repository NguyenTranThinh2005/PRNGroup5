using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ICommunityProgramRepository
    {
        Task<CommunityProgram> GetProgramByIdAsync(Guid id);
        Task<IEnumerable<CommunityProgram>> GetAllProgramsAsync();
        Task<CommunityProgram> AddCommunityProgramAsync(CommunityProgram program);
        Task<CommunityProgram> UpdateCommunityProgramAsync(CommunityProgram program);
        Task DeleteCommunityProgramAsync(Guid communityProgramId);
    }
}
