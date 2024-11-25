using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Model
{
    public class ExercisesRequest
    {

        public int Exeid { get; set; }
        public string Name { get; set; }
        public InfoItem[] Info { get; set; }
        public string Sets { get; set; }

    }
}
