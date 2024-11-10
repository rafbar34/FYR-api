using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Services
{
    public class HealthParameters
    {
        public double CalcWhr(double hips,double waist)
        {
            if(hips  < 0 || waist < 0) return 0;

            var whr = waist / hips;
            return whr;
        }

        public double CalcBMI(double weight, double height)
        {
            if (weight < 0 || height < 0) { return 0; };
            var bmi = weight / Math.Pow(height, 2);
            return bmi;
        }
    }   
}
