using FYR_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Services.Bmi
{
    public class Whr : Calculate_Parameters
    {
        private float _hips;
        private float _waist;
        public Whr(float hips, float waist) {
            _hips = hips;
            _waist = waist;
        }
        private double CalcWhr(float hips, float waist)
        {
            if (hips < 0 || waist < 0) return 0;

            var whr = MathF.Round(waist / hips, 2);
            return  whr;
        }

        public override double ResultCalc()
        {
            return CalcWhr(_hips, _waist);
        }
    }
}
