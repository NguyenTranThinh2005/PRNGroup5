using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;

namespace Models.Courses
{
    [Table("course_weeks")]
    public class CourseWeek
    {
        [Key]
        [Column("week_id")]
        public Guid WeekId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Course")]
        [Column("course_id")]
        public Guid CourseId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("week_number")]
        public int WeekNumber { get; set; }

        // Navigation properties
        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
