using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class ConsultantRepository : IConsultantRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsultantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Consultant>> GetAllConsultantsAsync()
        {
            return await _context.Consultants.ToListAsync();
        }
        
        public async Task<Consultant?> GetConsultantByIdAsync(Guid id)
        {
            return await _context.Consultants.FirstOrDefaultAsync(c => c.ConsultantId == id);
        }
        
        public async Task UpdateConsultantAsync(Consultant consultant)
        {
            _context.Consultants.Update(consultant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConsultantAsync(Guid id)
        {
            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant != null)
            {
                _context.Consultants.Remove(consultant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Consultant> AddConsultant(Consultant consultant)
        {
            await _context.Consultants.AddAsync(consultant);
            await _context.SaveChangesAsync();
            return consultant;
        }
    }
}

