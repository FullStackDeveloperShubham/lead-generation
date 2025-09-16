using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadGenerationApp.Models
{
    public class LeadAssign
    {
        [Key]
        public int LeadAssignId { get; set; }

        [Column("UserId", Order = 1)]
        public int UserId { get; set; }

        public DateTime Time { get; set; }

        [Column("Permition")]
        public string? Permission { get; set; }

        public string? Status { get; set; }

        [ForeignKey(nameof(LeadAssignId))]
        public virtual Lead? Lead { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual Users? User { get; set; }
        public ICollection<LeadAssign> LeadAssigns { get; set; }
    }
}
