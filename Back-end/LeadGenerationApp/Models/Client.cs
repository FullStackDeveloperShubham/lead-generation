using System.ComponentModel.DataAnnotations;

namespace LeadGenerationApp.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [MaxLength(300)]
        public string? Location { get; set; }

        public double? Budget { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? Area { get; set; }

        [MaxLength(50)]
        public string? Priority { get; set; }
    }
}
