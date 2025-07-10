using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Users;

namespace Models.Surveys
{
    [Table("surveys")]
    public class Survey
    {
        [Key]
        [Column("survey_id")]
        public Guid SurveyId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [MaxLength(255)]
        [Column("target_audience")]
        public string? TargetAudience { get; set; }
        [MaxLength(50)]
        [Column("estimated_duration")]
        public string? EstimatedDuration { get; set; }


        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();
        public virtual ICollection<UserSurveyResponse> UserSurveyResponses { get; set; } = new List<UserSurveyResponse>();
        public virtual ICollection<SurveyCourseRecommendation> SurveyCourseRecommendations { get; set; } = new List<SurveyCourseRecommendation>();
    }
}
