using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Users
{
    [Table("user_profiles")]
    public class UserProfile
    {
        [Key]
        [Column("profile_id")]
        public Guid ProfileId { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [MaxLength(100)]
        [Column("first_name")]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(10)]
        [Column("gender")]
        public string? Gender { get; set; }

        [MaxLength(20)]
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [MaxLength(500)]
        [Column("address")]
        public string? Address { get; set; }

        [MaxLength(100)]
        [Column("city")]
        public string? City { get; set; }

        [MaxLength(100)]
        [Column("occupation")]
        public string? Occupation { get; set; }

        [MaxLength(50)]
        [Column("education_level")]
        public string? EducationLevel { get; set; }

        [MaxLength(50)]
        [Column("age_group")]
        public string? AgeGroup { get; set; } // học sinh, sinh viên, phụ huynh, giáo viên

        [MaxLength(255)]
        [Column("avatar_url")]
        public string? AvatarUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}
