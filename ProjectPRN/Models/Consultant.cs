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
    [Table("consultants")]
    public class Consultant
    {
        [Key]
        [Column("consultant_id")]
        public Guid ConsultantId { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [MaxLength(100)]
        [Column("license_number")]
        public string? LicenseNumber { get; set; }

        [MaxLength(200)]
        [Column("specialization")]
        public string? Specialization { get; set; }

        [Column("years_of_experience")]
        public int? YearsOfExperience { get; set; }

        [MaxLength(500)]
        [Column("qualifications")]
        public string? Qualifications { get; set; }

        [MaxLength(1000)]
        [Column("bio")]
        public string? Bio { get; set; }

        [Column("consultation_fee")]
        public decimal? ConsultationFee { get; set; }

        [Column("is_available")]
        public bool IsAvailable { get; set; } = true;

        [MaxLength(500)]
        [Column("working_hours")]
        public string? WorkingHours { get; set; } // JSON format cho lịch làm việc

        [Column("rating")]
        public decimal? Rating { get; set; }

        [Column("total_consultations")]
        public int TotalConsultations { get; set; } = 0;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual User User { get; set; } = null!;
        // THÊM: Một Consultant có thể có nhiều TimeSlot
        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
        // THÊM: Một Consultant có thể có nhiều Appointment (nơi họ là người tư vấn)
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}