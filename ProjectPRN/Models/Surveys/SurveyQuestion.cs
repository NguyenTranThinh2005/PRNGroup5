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
    [Table("survey_questions")]
    public class SurveyQuestion
    {
        [Key]
        [Column("question_id")]
        public Guid QuestionId { get; set; } = Guid.NewGuid();

        [ForeignKey("Survey")]
        [Column("survey_id")]
        public Guid SurveyId { get; set; }

        [Required]
        [Column("question_text")]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("question_type")]
        public string QuestionType { get; set; } = string.Empty;

        [Column("sequence")]
        public int Sequence { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Survey Survey { get; set; } = null!;
        public virtual ICollection<SurveyOption> SurveyOptions { get; set; } = new List<SurveyOption>();
        public virtual ICollection<UserSurveyAnswer> UserSurveyAnswers { get; set; } = new List<UserSurveyAnswer>();
    }
}
