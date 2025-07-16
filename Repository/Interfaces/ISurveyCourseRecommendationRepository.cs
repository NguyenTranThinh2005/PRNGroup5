using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace DrugPreventionSystem.DataAccess.Repository.Interfaces
{
    public interface ISurveyCourseRecommendationRepository
    {
        Task<IEnumerable<SurveyCourseRecommendation>> GetAllCourseRecommendations();
        Task<SurveyCourseRecommendation?> GetRecommendationById(Guid recommendationId);
        Task<IEnumerable<SurveyCourseRecommendation>> GetRecommendationsByCourseId(Guid courseId);
        Task<SurveyCourseRecommendation> AddRecommendation(SurveyCourseRecommendation recommendation);
        Task<SurveyCourseRecommendation> UpdateRecommendation(SurveyCourseRecommendation recommendation);
        Task DeleteRecommendation(Guid recommendationId);
        Task<IEnumerable<SurveyCourseRecommendation>> GetRecommendationsBySurveyAndRiskLevelAsync(Guid surveyId, string riskLevel);
    }
}
