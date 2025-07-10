using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository.Participants
{
    public class ProgramParticipantRepository : IProgramParticipantRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramParticipant>> GetAllAsync()
        {
            return await _context.ProgramParticipants.ToListAsync();
        }

        public async Task<ProgramParticipant?> GetByIdAsync(Guid id)
        {
            return await _context.ProgramParticipants.FirstOrDefaultAsync(p => p.ParticipantId == id);
        }

        public async Task<ProgramParticipant> CreateAsync(ProgramParticipant participant)
        {
            await _context.AddAsync(participant);
            await _context.SaveChangesAsync();
            return participant;
        }

        public async Task UpdateAsync(ProgramParticipant participant)
        {
            _context.ProgramParticipants.Update(participant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var participant = await _context.ProgramParticipants.FirstOrDefaultAsync(p => p.ParticipantId == id);
            if (participant != null)
            {
                _context.ProgramParticipants.Remove(participant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
