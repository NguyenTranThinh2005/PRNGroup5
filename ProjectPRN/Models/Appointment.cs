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
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("appointment_id")]
        public Guid AppointmentId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey("Consultant")]
        [Column("consultant_id")]
        public Guid ConsultantId { get; set; }

        [Required]
        [ForeignKey("TimeSlot")]
        [Column("time_slot_id")]
        public Guid TimeSlotId { get; set; }

        // New: Lý do tư vấn (string)
        [Required]
        [MaxLength(255)] // Giới hạn độ dài cho lý do
        [Column("reason_for_consultation")]
        public string ReasonForConsultation { get; set; } = string.Empty;

        // New: Hình thức tư vấn (string)
        [Required]
        [MaxLength(50)] // Ví dụ: "Online" hoặc "In-person"
        [Column("consultation_type")]
        public string ConsultationType { get; set; } = string.Empty;

        // New: Bạn đã từng tham gia tư vấn trước đây chưa?
        [Required]
        [Column("has_previous_consultation")]
        public bool HasPreviousConsultation { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("status")] // Ví dụ: "Pending", "Confirmed", "Completed", "Cancelled"
        public string Status { get; set; } = "Pending";

        [Column("notes", TypeName = "text")] // Ghi chú của người dùng
        public string? Notes { get; set; }
        [Required]
        [MaxLength(500)]
        [Column("meet_url")]
        public string MeetUrl { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Consultant Consultant { get; set; } = null!;
        public virtual TimeSlot TimeSlot { get; set; } = null!;
    }
}
