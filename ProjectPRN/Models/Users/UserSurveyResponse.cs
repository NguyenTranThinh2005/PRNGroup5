using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Surveys;

namespace Models.Users
{
    [Table("user_survey_responses")]
    public class UserSurveyResponse
    {
        [Key]
        [Column("response_id")]
        public Guid ResponseId { get; set; } = Guid.NewGuid();

        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey("Survey")]
        [Column("survey_id")]
        public Guid SurveyId { get; set; }

        [Column("taken_at")]
        public DateTime TakenAt { get; set; } = DateTime.Now;

        [MaxLength(50)]
        [Column("risk_level")]
        public string? RiskLevel { get; set; }

        [MaxLength(500)]
        [Column("recommended_action")]
        public string? RecommendedAction { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Survey Survey { get; set; } = null!;
        public virtual ICollection<UserSurveyAnswer> UserSurveyAnswers { get; set; } = new List<UserSurveyAnswer>();
    }
}

