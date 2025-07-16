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
    public class SurveyCourseRecommendationRepository : ISurveyCourseRecommendationRepository
    {
        private readonly ApplicationDbContext _context;

        public SurveyCourseRecommendationRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<SurveyCourseRecommendation> AddRecommendation(SurveyCourseRecommendation recommendation)
        {
            await _context.AddAsync(recommendation);
            await _context.SaveChangesAsync();
            return recommendation;
        }

        public async Task DeleteRecommendation(Guid recommendationId)
        {
            var recommendation = await _context.SurveyCourseRecommendations
                .FindAsync(recommendationId);
            if(recommendation != null)
            {
                _context.SurveyCourseRecommendations.Remove(recommendation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SurveyCourseRecommendation>> GetAllCourseRecommendations()
        {
            var recommendations = await _context.SurveyCourseRecommendations.ToListAsync();
            return recommendations;
        }

        public async Task<SurveyCourseRecommendation?> GetRecommendationById(Guid recommendationId)
        {
            var recommendation = await _context.SurveyCourseRecommendations.FirstOrDefaultAsync(r => r.RecommendationId == recommendationId);
            return recommendation;
        }

        public async Task<IEnumerable<SurveyCourseRecommendation>> GetRecommendationsByCourseId(Guid courseId)
        {
            var recommendations = await _context.SurveyCourseRecommendations
                .Where(r => r.CourseId == courseId)
                .ToListAsync();
            return recommendations;
        }

        public async Task<IEnumerable<SurveyCourseRecommendation>> GetRecommendationsBySurveyAndRiskLevelAsync(Guid surveyId, string riskLevel)
        {
            return await _context.SurveyCourseRecommendations
                                 .Include(scr => scr.Course) 
                                 .Where(scr => scr.SurveyId == surveyId && scr.RiskLevel == riskLevel)
                                 .OrderBy(scr => scr.Priority) 
                                 .ToListAsync();
        }

        public async Task<SurveyCourseRecommendation> UpdateRecommendation(SurveyCourseRecommendation recommendation)
        {
            _context.Update(recommendation);
            await _context.SaveChangesAsync();
            return recommendation;
        }
    }
}
