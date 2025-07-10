using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class ProgramFeedbackRepository : IProgramFeedbackRepository
    {
        private readonly ApplicationDbContext _context;
        public ProgramFeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProgramFeedback?> GetByIdAsync(Guid feedbackId)
        {
            return await _context.ProgramFeedbacks
                .Include(f => f.CommunityProgram)
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.FeedbackId == feedbackId);
        }

        public async Task<IEnumerable<ProgramFeedback>> GetAllAsync()
        {
            return await _context.ProgramFeedbacks
                .Include(f => f.CommunityProgram)
                .Include(f => f.User)
                .ToListAsync();
        }

        public async Task AddAsync(ProgramFeedback feedback)
        {
            await _context.ProgramFeedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProgramFeedback feedback)
        {
            _context.ProgramFeedbacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid feedbackId)
        {
            var feedback = await _context.ProgramFeedbacks.FindAsync(feedbackId);
            if (feedback != null)
            {
                _context.ProgramFeedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
} 