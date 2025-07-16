using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Quizzes;

namespace Models.Users
{
    [Table("user_quiz_answers")]
    public class UserQuizAnswer
    {
        [Key]
        [Column("user_quiz_answer_id")]
        public Guid UserQuizAnswerId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey("QuizQuestion")]
        [Column("question_id")]
        public Guid QuestionId { get; set; }

        [ForeignKey("QuizOption")]
        [Column("selected_option_id")]
        public Guid? SelectedOptionId { get; set; } // null nếu là câu hỏi dạng text

        [Column("answer_text")]
        public string? AnswerText { get; set; } // dùng nếu câu hỏi dạng text

        [Column("answered_at")]
        public DateTime AnsweredAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual QuizQuestion QuizQuestion { get; set; } = null!;
        public virtual QuizOption? SelectedOption { get; set; }
    }
}
