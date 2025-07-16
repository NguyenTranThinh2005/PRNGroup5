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
    [Table("user_lesson_progress")]
    public class UserLessonProgress
    {
        [Key]
        [Column("progress_id")]
        public Guid ProgressId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey("Lesson")]
        [Column("lesson_id")]
        public Guid LessonId { get; set; }

        [Column("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [Column("quiz_score")]
        public float? QuizScore { get; set; }

        [Column("passed")]
        public bool Passed { get; set; } = false;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Lesson Lesson { get; set; } = null!;
    }
}
