using System.ComponentModel.DataAnnotations;

namespace FLEXISOURCETEST.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age => ComputeAge();

        public double BMI => ComputeBmi();
        public List<RunningActivity>? RunningActivities { get; set; }

        private int ComputeAge()
        {
            var today = DateTime.Today;
            var age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private double ComputeBmi()
        {
            return Weight / ((Height / 100) * (Height / 100));
        }
    }
}
