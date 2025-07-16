using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DrugPreventionSystem.DataAccess.Models;
using Models.Courses;

namespace Models.Users
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [ForeignKey("Role")]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("email_verified")]
        public bool EmailVerified { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("last_login")]
        public DateTime? LastLogin { get; set; }

        // Navigation properties
        public virtual Role Role { get; set; } = null!;
        public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<UserSurveyResponse> UserSurveyResponses { get; set; } = new List<UserSurveyResponse>();
        public virtual ICollection<UserLessonProgress> UserLessonProgresses { get; set; } = new List<UserLessonProgress>();
        public virtual ICollection<UserQuizAnswer> UserQuizAnswers { get; set; } = new List<UserQuizAnswer>();
        public virtual ICollection<UserModuleQuizResult> UserModuleQuizResults { get; set; } = new List<UserModuleQuizResult>();
        public virtual ICollection<CourseCertificate> CourseCertificates { get; set; } = new List<CourseCertificate>();
        public virtual ICollection<UserCourseEnrollment> UserCourseEnrollments { get; set; } = new List<UserCourseEnrollment>();
        public virtual ICollection<ProgramParticipant> ProgramParticipants { get; set; } = new List<ProgramParticipant>();
    }
}