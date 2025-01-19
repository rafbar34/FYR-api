using FYR_api.Enums;
using FYR_api.Services.Bmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Services.Health_parameters
{
    public class HealthParameters
    {



        public double Result_Whr(float hips, float waist)
        {
            Whr whr = new Whr(hips, waist);
            return whr.ResultCalc();
        }

        public double Result_Bmi(float weight, float height)
        {
            BMI bmi = new BMI(weight, height);
            return bmi.ResultCalc();
        }

        public object CalcCPM(float weight, float height, float pal, int age, int sex)
        {
            int gender_val;
            if ((Sex)sex == Sex.Male)
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
