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

        public required object Answers { get; set; }

        public required bool IsCompleted { get; set; }
    }
}
