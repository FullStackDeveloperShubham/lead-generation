using System.ComponentModel.DataAnnotations;

namespace LeadGenerationApp.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public string? ManagerName { get; set; }

        public virtual ICollection<Team>? Teams { get; set; }
    }
}
