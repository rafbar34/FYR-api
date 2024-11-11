using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Services
{
    public class HealthParameters
    {
        public float CalcWhr(float hips, float waist)
        {
            if(hips  < 0 || waist < 0) return 0;

            var whr = MathF.Round(waist / hips, 2);
            return whr;
        }

        public float CalcBMI(float weight, float height)
        {
            if (weight < 0 || height < 0) { return 0; };
            float bmi = MathF.Round((weight / MathF.Pow(height/100, 2)),2);
            return bmi;
        }
    }   
}
