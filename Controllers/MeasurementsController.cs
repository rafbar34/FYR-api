using FYR_api.Enums;
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
        [Route("/measurements/{id}")]
        public async Task<ActionResult> BMIController (string id)
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;

            var result = await getExpection.ExpectionHandler(async () =>
            {

             var res =   await supabaseClient.From<UsersSurveyModel>().Where(x => x.UserId == id).Get();
            var measurments = new HealthParameters();

            var weight = res.Model.Answers.Weight;
            var height = res.Model.Answers.Height;

            var hips = res.Model.Answers.Hip;
            var waist = res.Model.Answers.Waist;

            var pal = res.Model.Answers.Pal;
            var age = res.Model.Answers.Age;
            var sex = res.Model.Answers.Sex;

            var bmi = measurments.CalcBMI(weight, height);
            var whr = measurments.CalcWhr(hips, waist);
            var cpm = measurments.calcCPM(weight, height, pal, age, sex);

            var parameters = new { whr, bmi, cpm };
                return parameters;
            }
            );

             return result;
        }
    }
}
