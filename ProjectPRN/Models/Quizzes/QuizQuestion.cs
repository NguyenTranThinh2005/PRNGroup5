using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Users;

namespace Models.Quizzes
{
    [Table("quiz_questions")]
    public class QuizQuestion
    {
        [Key]
        [Column("question_id")]
        public Guid QuestionId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Quiz")]
        [Column("quiz_id")]
        public Guid QuizId { get; set; }

        [Required]
        [Column("question_text")]
        public string QuestionText { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("question_type")]
        public string? QuestionType { get; set; } // single_choice, multi_choice, text

        [Column("sequence")]
        public int Sequence { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Quiz Quiz { get; set; } = null!;
        public virtual ICollection<QuizOption> QuizOptions { get; set; } = new List<QuizOption>();
        public virtual ICollection<UserQuizAnswer> UserQuizAnswers { get; set; } = new List<UserQuizAnswer>();
    }
}
