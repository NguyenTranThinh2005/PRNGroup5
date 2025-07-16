using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Users;

namespace Models.Courses
{
    [Table("course_certificates")]
    public class CourseCertificate
    {
        [Key]
        [Column("certificate_id")]
        public Guid CertificateId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey("Course")]
        [Column("course_id")]
        public Guid CourseId { get; set; }

        [Column("issued_at")]
        public DateTime IssuedAt { get; set; } = DateTime.Now;

        [MaxLength(500)]
        [Column("certificate_url")]
        public string? CertificateUrl { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}