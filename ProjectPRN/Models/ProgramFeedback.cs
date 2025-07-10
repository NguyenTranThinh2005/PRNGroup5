using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Users;

namespace DrugPreventionSystem.DataAccess.Models
{
    [Table("program_feedback")]
    public class ProgramFeedback
    {
        [Key]
        [Column("feedback_id")] 
        public Guid FeedbackId { get; set; }

        [ForeignKey("CommunityProgram")]
        [Column("program_id")]
        public Guid ProgramId { get; set; } 

        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; } 

        [Column("rating")]
        public int Rating { get; set; } 

        [Column("comments", TypeName = "text")]
        public string? Comments { get; set; } 

        [Column("submitted_at")]
        public DateTime SubmittedAt { get; set; } = DateTime.Now; 

        // Navigation properties
        public virtual CommunityProgram CommunityProgram { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
