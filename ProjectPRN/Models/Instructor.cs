using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Courses;

namespace DrugPreventionSystem.DataAccess.Models
{
    [Table("instructors")]
    public class Instructor
    {
        [Key]
        [Column("instructor_id")]
        public Guid InstructorId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("bio")]
        public string? Bio { get; set; }

        [MaxLength(500)]
        [Column("profile_image_url")]
        public string? ProfileImageUrl { get; set; }

        [Column("experience_years")]
        public int? ExperienceYears { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
