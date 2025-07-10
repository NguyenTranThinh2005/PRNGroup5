using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Users;
using Models.Surveys;
using DrugPreventionSystem.DataAccess.Models;

namespace Models.Courses
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("course_id")]
        public Guid CourseId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(500)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [MaxLength(100)]
        [Column("age_group")]
        public string? AgeGroup { get; set; } // học sinh, sinh viên, phụ huynh, giáo viên, ...

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("total_duration")]
        public int? TotalDuration { get; set; } // Tổng thời lượng khóa học 

        [Column("lesson_count")]
        public int? LessonCount { get; set; }

        [Column("student_count")]
        public int? StudentCount { get; set; }

        [Required]
        [ForeignKey("Instructor")]
        [Column("instructor_id")]
        public Guid InstructorId { get; set; }

        [Column("requirements")]
        public string? Requirements { get; set; }

        [Column("certificate_available")]
        public bool CertificateAvailable { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(1000)]
        [Column("thumbnail_url")]
        public string? ThumbnailUrl { get; set; }

        // Navigation properties
        public virtual Instructor Instructor { get; set; } = null!;
        public virtual ICollection<CourseWeek> CourseWeeks { get; set; } = new List<CourseWeek>();
        public virtual ICollection<CourseCertificate> CourseCertificates { get; set; } = new List<CourseCertificate>();
        public virtual ICollection<SurveyCourseRecommendation> SurveyCourseRecommendations { get; set; } = new List<SurveyCourseRecommendation>();
        public virtual ICollection<UserResponseCourseRecommendation> UserResponseCourseRecommendations { get; set; } = new List<UserResponseCourseRecommendation>();
        public virtual ICollection<UserCourseEnrollment> UserCourseEnrollments { get; set; } = new List<UserCourseEnrollment>();
    }
}
