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

        public double Result_CPM(float weight, float height, float pal, int age, int sex)
        {
            CPM cpm = new CPM( weight, height,  pal,  age,  sex);
           return cpm.ResultCalc();

        }

   
    }
}
