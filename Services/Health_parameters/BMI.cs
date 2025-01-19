using FYR_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Services.Health_parameters
{
    public class BMI : Calculate_Parameters
    {
        private float _weight;
        private float _height;
        public BMI(float weight,float height)
        {
            _weight = weight;
            _height = height;
    }

        public double CalcBMI(float weight, float height)
        {
            if (weight < 0 || height < 0) { return 0; };
            float bmi = MathF.Round(weight / MathF.Pow(height / 100, 2), 2);
            return bmi;
        }
        public override double ResultCalc()
        {
            return CalcBMI(_weight, _height);
        }
    }
}
