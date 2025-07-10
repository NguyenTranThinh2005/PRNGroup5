using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Courses;

namespace Models.Surveys
{
    [Table("survey_course_recommendations")]
    public class SurveyCourseRecommendation
    {
        [Key]
        [Column("recommendation_id")]
        public Guid RecommendationId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Survey")]
        [Column("survey_id")]
        public Guid SurveyId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("risk_level")]
        public string RiskLevel { get; set; } = string.Empty; // 'low', 'moderate', 'high', 'very_high'

        [MaxLength(255)]
        [Column("recommended_action_keyword")]
        public string? RecommendedActionKeyword { get; set; }

        [Required]
        [ForeignKey("Course")]
        [Column("course_id")]
        public Guid CourseId { get; set; }

        [Column("priority")]
        public int Priority { get; set; } = 1; // Mức độ ưu tiên khi hiển thị (số nhỏ hơn ưu tiên cao hơn)

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Survey Survey { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
