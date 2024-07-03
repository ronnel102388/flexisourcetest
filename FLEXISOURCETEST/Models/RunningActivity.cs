using System.ComponentModel.DataAnnotations;

namespace FLEXISOURCETEST.Models
{
    public class RunningActivity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double DistanceKm { get; set; }

        public TimeSpan Duration => EndTime - StartTime;

        public double AveragePace => Duration.TotalMinutes / DistanceKm;

    }
}
