using FYR_api.Model;
using FYR_api.NewFolder;
using FYR_api.Services;
using Microsoft.AspNetCore.Mvc;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Controllers
{
    public class MeasurementsController: ControllerBase
    {
        public readonly ConnectDBService? _connectDb;

        public MeasurementsController(ConnectDBService? connectDb)
        {
            _connectDb = connectDb;
        }

        [HttpGet]
        [Route("/measurements/bmi/{id}")]
        public async Task<ActionResult> BMIController (string id)
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;

            var result = await getExpection.ExpectionHandler(async () =>
            {

              var res =   await supabaseClient.From<UsersSurveyModel>().Where(x => x.UserId == id).Get();
            var measurments = new HealthParameters();
            if(res.Models.Count() == 0)
                {
                    return BadRequest("Bad request, table is empty");
                }
            var weight = res.Model.Answers.Weight;
            var height = res.Model.Answers.Height;

            var hips = res.Model.Answers.Hip;
            var waist = res.Model.Answers.Waist;

            var bmi = measurments.CalcBMI(weight, height);
            var whr = measurments.CalcWhr(hips, waist);

            var parameters = new { whr, bmi };
                return parameters;
            }
            );

             return result;
        }
    }
}
