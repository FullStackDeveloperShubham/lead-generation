using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace LeadGenerationApp.Models
{
    public class Roles
    {
        [Key]
        public int RollID { get; set; }
        public string? RollName { get; set; }
        public int PermissionID { get; set; }

        // Navigation
        [ForeignKey(nameof(PermissionID))]
        public virtual Permission? Permission { get; set; }

        public virtual ICollection<Users>? Users { get; set; }
    }
}
