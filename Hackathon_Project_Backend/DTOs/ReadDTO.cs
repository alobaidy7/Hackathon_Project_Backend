namespace Hackathon_Project_Backend.DTOs
{
    public class ReadDTO
    {
        public int GazPercentage { get; set; } // may come analog
        public int TempDeg { get; set; }
        public int DCM { get; set; } // dust
        public int Quality { get; set; } // formula used in controller later
        public int CityId { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
