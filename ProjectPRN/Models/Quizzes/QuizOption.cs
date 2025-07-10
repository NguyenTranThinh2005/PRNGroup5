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
    [Table("quiz_options")]
    public class QuizOption
    {
        [Key]
        [Column("option_id")]
        public Guid OptionId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("QuizQuestion")]
        [Column("question_id")]
        public Guid QuestionId { get; set; }

        [Required]
        [Column("option_text")]
        public string OptionText { get; set; } = string.Empty;

        [Column("is_correct")]
        public bool IsCorrect { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual QuizQuestion QuizQuestion { get; set; } = null!;
        public virtual ICollection<UserQuizAnswer> UserQuizAnswers { get; set; } = new List<UserQuizAnswer>();
    }
}
