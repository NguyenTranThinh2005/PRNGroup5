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
    [Table("user_response_course_recommendations")]
    public class UserResponseCourseRecommendation
    {
        [Key]
        [Column("user_rec_id")]
        public Guid UserRecId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("UserSurveyResponse")]
        [Column("response_id")]
        public Guid ResponseId { get; set; }

        [Required]
        [ForeignKey("Course")]
        [Column("course_id")]
        public Guid CourseId { get; set; }

        [Column("recommended_at")]
        public DateTime RecommendedAt { get; set; } = DateTime.Now;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual UserSurveyResponse UserSurveyResponse { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}

