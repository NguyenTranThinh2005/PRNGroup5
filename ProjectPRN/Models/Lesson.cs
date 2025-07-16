using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Users;
using Models.Quizzes;
using Models.Courses;

namespace DrugPreventionSystem.DataAccess.Models
{
    [Table("lessons")]
    public class Lesson
    {
        [Key]
        [Column("lesson_id")]
        public Guid LessonId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("CourseWeek")]
        [Column("week_id")]
        public Guid WeekId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("content")]
        public string? Content { get; set; }

        [Column("duration_minutes")]
        public int? DurationMinutes { get; set; }

        [Column("sequence")]
        public int Sequence { get; set; }

        [Column("has_quiz")]
        public bool HasQuiz { get; set; } = false;

        [Column("has_practice")]
        public bool HasPractice { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual CourseWeek CourseWeek { get; set; } = null!;
        public virtual ICollection<LessonResource> LessonResources { get; set; } = new List<LessonResource>();
        public virtual Quiz? Quiz { get; set; } // Một bài học có thể có một Quiz
        public virtual ICollection<PracticeExercise> PracticeExercises { get; set; } = new List<PracticeExercise>();
        public virtual ICollection<UserLessonProgress> UserLessonProgresses { get; set; } = new List<UserLessonProgress>();
        public virtual ICollection<UserModuleQuizResult> UserModuleQuizResults { get; set; } = new List<UserModuleQuizResult>();
    }
}