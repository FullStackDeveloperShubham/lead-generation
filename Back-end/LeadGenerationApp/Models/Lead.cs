using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadGenerationApp.Models
{
    public class Lead
    {
        [Key]
        public int LeadId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedBy { get; set; }
        // Navigation
        [ForeignKey(nameof(UserId))]
        public virtual Users? User { get; set; }

        public virtual ICollection<LeadAssign>? Assignments { get; set; }
    }
}
