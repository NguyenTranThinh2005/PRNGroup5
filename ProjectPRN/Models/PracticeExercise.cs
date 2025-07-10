using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Models
{
    [Table("practice_exercises")]
    public class PracticeExercise
    {
        [Key]
        [Column("exercise_id")]
        public Guid ExerciseId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Lesson")]
        [Column("lesson_id")]
        public Guid LessonId { get; set; }

        [Column("instruction")]
        public string? Instruction { get; set; }

        [MaxLength(500)]
        [Column("attachment_url")]
        public string? AttachmentUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Lesson Lesson { get; set; } = null!;
    }
}
