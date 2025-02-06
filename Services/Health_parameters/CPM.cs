using FYR_api.Enums;
using FYR_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Services.Health_parameters
{
    public class CPM : Calculate_Parameters
    {
        float _weight;
        float _height;
        float _pal;
        int _age;
        int _sex;
        public CPM(float weight, float height, float pal, int age, int sex) { 
            _weight = weight;
            _height = height;
             _pal = pal;
            _age = age;
            _sex = sex;

        }
        public override double ResultCalc()
        {
            int gender_val;
            if ((Sex)_sex == Sex.Male)
            {
                gender_val = -161;
            }
            else
            {
                gender_val = 5;
            }
            var ppm = 10f * _weight + 6.25f * _height + gender_val;
            var cpm_result = ppm * _pal;
            return  cpm_result;
        }
    }
}
