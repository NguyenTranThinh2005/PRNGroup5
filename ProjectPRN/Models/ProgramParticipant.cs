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
    [Table("program_participants")]
    public class ProgramParticipant
    {
        [Key]
        [Column("participant_id")] 
        public Guid ParticipantId { get; set; }

        [ForeignKey("CommunityProgram")]
        [Column("program_id")]
        public Guid ProgramId { get; set; } 

        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; } 

        [Column("registered_at")]
        public DateTime RegisteredAt { get; set; } = DateTime.Now; 

        [Column("attended")]
        public bool Attended { get; set; } = false; // Đánh dấu người dùng đã tham gia 

        [Column("feedback_submitted")]
        public bool FeedbackSubmitted { get; set; } = false; // Cờ đánh dấu đã gửi feedback hay chưa

        // Navigation properties
        public virtual CommunityProgram CommunityProgram { get; set; } = null!;
        public virtual User User { get; set; } = null!; // Đảm bảo bạn đã có class User
    }
}
