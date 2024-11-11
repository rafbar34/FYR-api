using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Model
{
    public class ParametersModel
    {
        public int Age { get; set; }  // Pole "age" z obiektu "answers"
        public float Hip { get; set; }  // Pole "hip" z obiektu "answers"
        public string Sex { get; set; }  // Pole "sex" z obiektu "answers"
        public string Name { get; set; }  // Pole "name" z obiektu "answers"
        public float Waist { get; set; }  // Pole "waist" z obiektu "answers"
        public int Height { get; set; }  // Pole "height" z obiektu "answers"
        public float Weight { get; set; }  // Pole "weight" z obiektu "answers"
        public string BodyType { get; set; }  // Pole "body_type" z obiektu "answers"
    }
}
