using DrugPreventionSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface IProgramFeedbackRepository
    {
        Task<ProgramFeedback?> GetByIdAsync(Guid feedbackId);
        Task<IEnumerable<ProgramFeedback>> GetAllAsync();
        Task AddAsync(ProgramFeedback feedback);
        Task UpdateAsync(ProgramFeedback feedback);
        Task DeleteAsync(Guid feedbackId);
    }
} 