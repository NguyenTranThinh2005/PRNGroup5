using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace Models.Users
{
    [Table("user_module_quiz_result")]
    public class UserModuleQuizResult
    {
        [Key]
        [Column("result_id")]
        public Guid ResultId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey("Lesson")] 
        [Column("lesson_id")]
        public Guid LessonId { get; set; }

        [Column("total_score")]
        public float TotalScore { get; set; }

        [Column("correct_count")]
        public int CorrectCount { get; set; }

        [Column("total_questions")]
        public int TotalQuestions { get; set; }

        [MaxLength(50)]
        [Column("status")]
        public string Status { get; set; } = string.Empty; // passed, failed

        [Column("taken_at")]
        public DateTime TakenAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Lesson Lesson { get; set; } = null!;
    }
}