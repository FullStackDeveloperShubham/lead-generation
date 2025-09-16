using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadGenerationApp.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public int UserId { get; set; }
        public int ManagerId { get; set; }

        // Navigation
        [ForeignKey(nameof(UserId))]
        public virtual Users? User { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public virtual Manager? Manager { get; set; }
    }
}
