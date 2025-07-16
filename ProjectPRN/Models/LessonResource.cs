using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPreventionSystem.DataAccess.Models
{
    [Table("lesson_resources")]
    public class LessonResource
    {
        [Key]
        [Column("resource_id")]
        public Guid ResourceId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Lesson")]
        [Column("lesson_id")]
        public Guid LessonId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("resource_type")]
        public string ResourceType { get; set; } = string.Empty; // video, pdf, link, etc.

        [Required]
        [MaxLength(500)]
        [Column("resource_url")]
        public string ResourceUrl { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        // Navigation property
        public virtual Lesson Lesson { get; set; } = null!;
    }
}
