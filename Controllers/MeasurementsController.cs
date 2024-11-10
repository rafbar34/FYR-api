using FYR_api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Controllers
{
    public class MeasurementsController: ControllerBase
    {
        [HttpGet]
        [Route("/measurements/bmi")]
        public ActionResult BMIController ()
        {

            //var measurments = new HealthParameters();
            //var bmi = measurments.CalcBMI();
            return Ok("test");
        }
    }
}
