using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Hackathon_Project_Backend.Models
{
    public class Read
    {
        public int Id { get; set; }
        public int GazPercentage { get; set; } // may come analog
        public int TempDeg { get; set; }
        public int DCM { get; set; } // dust
        public int Quality { get; set; } // formula used in controller later
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
