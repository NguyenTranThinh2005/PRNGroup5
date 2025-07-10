using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext _context;
        public InstructorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Instructor> CreateAsync(Instructor response)
        {
            await _context.Instructors.AddAsync(response);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }
        public async Task<Instructor?> GetByIdAsync(Guid id)
        {
            return await _context.Instructors.FirstOrDefaultAsync(c => c.InstructorId == id);
        }
        public async Task UpdateAsync(Instructor response)
        {
            _context.Instructors.Update(response);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var response = await _context.Instructors.FirstOrDefaultAsync(c => c.InstructorId == id);
            if (response != null)
            {
                _context.Instructors.Remove(response);
                await _context.SaveChangesAsync();
            }
        }

    }
}
