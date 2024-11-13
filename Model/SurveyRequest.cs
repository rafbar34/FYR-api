using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Model
{
    public class SurveyRequest
    {
        public required string UserId { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public float Pal { get; set; }
        public int AverageSleep { get; set; }

        public required bool IsCompleted { get; set; }
    }
    public class SurveyDailyRequest
    {
        public required string UserId { get; set; }
        public float Hip { get; set; }
        public string Name { get; set; }
        public float Waist { get; set; }
        public int Height { get; set; }
        public float Weight { get; set; }
        public float Pal { get; set; }
        public int Sleep { get; set; }
        public DateTime Last_meal { get; set; }
        public DateTime Awake { get; set; }

        public required bool IsCompleted { get; set; }
    }
}
