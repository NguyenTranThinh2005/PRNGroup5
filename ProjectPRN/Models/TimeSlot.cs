using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Models
{
    [Table("time_slots")]
    public class TimeSlot
    {
        [Key]
        [Column("time_slot_id")]
        public Guid TimeSlotId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Consultant")] // Tham chiếu đến Consultant
        [Column("consultant_id")]
        public Guid ConsultantId { get; set; }

        [Required]
        [Column("slot_date", TypeName = "date")] // Chỉ lưu ngày
        public DateTime SlotDate { get; set; }

        [Required]
        [Column("start_time", TypeName = "time")] // Chỉ lưu giờ bắt đầu
        public TimeSpan StartTime { get; set; }

        [Required]
        [Column("end_time", TypeName = "time")] // Chỉ lưu giờ kết thúc
        public TimeSpan EndTime { get; set; }



        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual Consultant Consultant { get; set; } = null!;


        public virtual Appointment? Appointment { get; set; } // Một TimeSlot có thể có hoặc không có Appointment
    }
}
