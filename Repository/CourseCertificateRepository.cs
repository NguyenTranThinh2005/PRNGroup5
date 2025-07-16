using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Repository
{
    public class CourseCertificateRepository : ICourseCertificateRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseCertificateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CourseCertificate> AddAsync(CourseCertificate entity)
        {
            await _context.CourseCertificates.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<CourseCertificate>> GetAllAsync()
        {
            return await _context.CourseCertificates.ToListAsync();
        }
        public async Task<CourseCertificate?> GetByIdAsync(Guid id)
        {
            return await _context.CourseCertificates.FindAsync(id);
        }
        public async Task UpdateAsync(CourseCertificate entity)
        {
            _context.CourseCertificates.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.CourseCertificates.FindAsync(id);
            if (entity != null)
            {
                _context.CourseCertificates.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<CourseCertificate>> GetByUserIdAsync(Guid userId)
        {
            return await _context.CourseCertificates.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<IEnumerable<CourseCertificate>> GetByCourseIdAsync(Guid courseId)
        {
            return await _context.CourseCertificates.Where(x => x.CourseId == courseId).ToListAsync();
        }

        public async Task<CourseCertificate?> GetByUserIdAndCourseIdAsync(Guid userId, Guid courseId)
        {
            return await _context.CourseCertificates
           .FirstOrDefaultAsync(cc => cc.UserId == userId && cc.CourseId == courseId);
        }
    }
} 