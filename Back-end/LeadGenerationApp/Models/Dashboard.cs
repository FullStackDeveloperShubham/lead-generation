using System.ComponentModel.DataAnnotations;

namespace LeadGenerationApp.Models
{
    public class Dashboard
    {
        [Key]
        public int DashboardId { get; set; }

        public int TotalLeads { get; set; }
        public int TotalCompleted { get; set; }
        public int PendingLeft { get; set; }
        public int TodaysAppointment { get; set; }
    }
}
