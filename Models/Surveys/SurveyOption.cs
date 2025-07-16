using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Users;

namespace Models.Surveys
{
    public class SurveyOption
    {
        [Key]
        [Column("option_id")]
        public Guid OptionId { get; set; } = Guid.NewGuid();

        [ForeignKey("SurveyQuestion")]
        [Column("question_id")]
        public Guid QuestionId { get; set; }

        [Required]
        [MaxLength(500)]
        [Column("option_text")]
        public string OptionText { get; set; } = string.Empty;

        [Column("score_value")]
        public int? ScoreValue { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; } = null!;
        public virtual ICollection<UserSurveyAnswer> UserSurveyAnswers { get; set; } = new List<UserSurveyAnswer>();
    }
}
