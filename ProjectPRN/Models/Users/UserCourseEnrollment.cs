using DrugPreventionSystem.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Courses;

namespace Models.Users
{
    [Table("user_course_enrollments")]
    public class UserCourseEnrollment
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; } 

        [Required]
        [ForeignKey("Course")]
        [Column("course_id")]
        public Guid CourseId { get; set; } 

        [Required]
        [Column("enrolled_at")]
        public DateTime EnrolledAt { get; set; } = DateTime.Now; 

        [Required]
        [MaxLength(50)] 
        [Column("status")]
        
        public string Status { get; set; } = EnrollmentStatus.NotStarted.ToString(); // Mặc định là NotStarted

        [Column("completed_at")]
        public DateTime? CompletedAt { get; set; } 

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; } 

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
