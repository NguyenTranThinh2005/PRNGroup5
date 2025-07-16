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
    [Table("user_survey_answers")]
    public class UserSurveyAnswer
    {
        [Key]
        [Column("answer_id")]
        public Guid AnswerId { get; set; } = Guid.NewGuid(); 

        [ForeignKey("UserSurveyResponse")]
        [Column("response_id")]
        public Guid ResponseId { get; set; }

        [ForeignKey("SurveyQuestion")]
        [Column("question_id")]
        public Guid QuestionId { get; set; }

        [ForeignKey("SurveyOption")] 
        [Column("option_id")]
        public Guid? OptionId { get; set; }

        [Column("answer_text")]
        public string? AnswerText { get; set; } 

        [Column("answered_at")]
        public DateTime AnsweredAt { get; set; } = DateTime.Now;

        
        public virtual UserSurveyResponse UserSurveyResponse { get; set; } = null!;
        public virtual SurveyQuestion SurveyQuestion { get; set; } = null!;
        public virtual SurveyOption? SurveyOption { get; set; }
    }
}
