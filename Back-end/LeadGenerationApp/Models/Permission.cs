using System.ComponentModel.DataAnnotations;

namespace LeadGenerationApp.Models
{
    public class Permission
    {
        
        [Key]
        public int PermissionID { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Update { get; set; }
        public bool Insert { get; set; }

        public virtual ICollection<Roles>? Roles { get; set; }
    }
}
