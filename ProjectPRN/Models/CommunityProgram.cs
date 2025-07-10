using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Models
{
    [Table("community_programs")]
    public class CommunityProgram
    {
        [Key]
        [Column("program_id")]
        public Guid ProgramId { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty; 

        [Column("description", TypeName = "text")]
        public string? Description { get; set; } 

        [MaxLength(255)]
        [Column("target_audience")] // Đối tượng mục tiêu (có thể có hoặc không tùy nhu cầu)
        public string? TargetAudience { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; } 

        [Column("end_date")]
        public DateTime EndDate { get; set; } 

        [MaxLength(255)]
        [Column("location")]
        public string? Location { get; set; } 

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<ProgramParticipant> ProgramParticipants { get; set; } = new List<ProgramParticipant>();
        public virtual ICollection<ProgramFeedback> ProgramFeedbacks { get; set; } = new List<ProgramFeedback>();
    }
}