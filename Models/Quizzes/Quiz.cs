using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace Models.Quizzes
{
    [Table("quizzes")]
    public class Quiz
    {
        [Key]
        [Column("quiz_id")]
        public Guid QuizId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Lesson")]
        [Column("lesson_id")]
        public Guid LessonId { get; set; } // Unique vì mỗi Lesson chỉ có 1 Quiz

        [Required]
        [MaxLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("passing_score")]
        public float? PassingScore { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Lesson Lesson { get; set; } = null!;
        public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
    }
}
