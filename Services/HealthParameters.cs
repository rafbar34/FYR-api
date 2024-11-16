using FYR_api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Services
{
    public class HealthParameters
    {
        public object CalcWhr(float hips, float waist)
        {
            if(hips  < 0 || waist < 0) return 0;

            var whr = MathF.Round(waist / hips, 2);
            return new { whr };
        }

        public object CalcBMI(float weight, float height)
        {
            if (weight < 0 || height < 0) { return 0; };
            float bmi = MathF.Round((weight / MathF.Pow(height / 100, 2)), 2);
            return new { bmi };
        }

        public object CalcCPM(float weight, float height, float pal, int age, int sex)
        {
            int gender_val;
            if((Sex)sex == Sex.Male)
            {
                gender_val = -161;
            }
            else
            {
                gender_val = 5;
            }
            var ppm = 10f * weight + 6.25f * height + gender_val;
            var cpm = ppm * pal;
            return new { cpm };
        }
    }   
}
