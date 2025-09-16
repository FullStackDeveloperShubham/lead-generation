using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace LeadGenerationApp.Models
{
    public class Users
    {
        [Key]
        public int UserId{ get; set; }
        public string? UserName { get; set; }
        public int RollID { get; set; }
        public string? UserPassword { get; set; }

        // Navigation
        [ForeignKey(nameof(RollID))]
        public virtual Roles? Role { get; set; }

        public virtual ICollection<Team>? Teams { get; set; }
        public virtual ICollection<Lead>? Leads { get; set; }
        public virtual ICollection<LeadAssign>? LeadAssignments { get; set; }
    }
}
