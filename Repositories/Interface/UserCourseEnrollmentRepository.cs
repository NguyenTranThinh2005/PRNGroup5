using DrugPreventionSystem.DataAccess.Context;
using DrugPreventionSystem.DataAccess.Models;
using DrugPreventionSystem.DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Users;
using Repositories.Interface.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.User
{
    public class UserCourseEnrollmentRepository : IUserCourseEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public UserCourseEnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserCourseEnrollment> AddAsync(UserCourseEnrollment entity)
        {
            await _context.UserCourseEnrollments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<UserCourseEnrollment>> GetAllAsync()
        {
            return await _context.UserCourseEnrollments.ToListAsync();
        }
        public async Task<UserCourseEnrollment?> GetByIdAsync(Guid id)
        {
            return await _context.UserCourseEnrollments.FindAsync(id);
        }
        public async Task UpdateAsync(UserCourseEnrollment entity)
        {
            _context.UserCourseEnrollments.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.UserCourseEnrollments.FindAsync(id);
            if (entity != null)
            {
                _context.UserCourseEnrollments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<UserCourseEnrollment>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserCourseEnrollments.Where(x => x.UserId == userId)
                .Include(uce => uce.Course) 
                .ThenInclude(c => c.CourseWeeks)
                    .ThenInclude(cw => cw.Lessons)
                .Include(uce => uce.Course.Instructor)
                .ToListAsync();
        }
        public async Task<IEnumerable<UserCourseEnrollment>> GetByCourseIdAsync(Guid courseId)
        {
            return await _context.UserCourseEnrollments.Where(x => x.CourseId == courseId).ToListAsync();
        }

        public async Task<UserCourseEnrollment?> GetByUserIdAndCourseIdAsync(Guid userId, Guid courseId)
        {
            return await _context.UserCourseEnrollments
           .FirstOrDefaultAsync(uce => uce.UserId == userId && uce.CourseId == courseId);
        }
    }
} 