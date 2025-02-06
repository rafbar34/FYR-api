using FYR_api.Enums;
using FYR_api.Model;
using FYR_api.NewFolder;
using FYR_api.Services;
using FYR_api.Services.Health_parameters;
using Microsoft.AspNetCore.Mvc;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

                var res = await supabaseClient.From<UsersSurveyModel>().Where(x => x.UserId == id).Get();
                var daily_res = await supabaseClient.From<DailySurveyModel>().Where(x => x.UserId == id).Get();
                var health_parameters = new HealthParameters();
                var answers_survey = res.Model;
                var answer_daily_survey = daily_res.Model;

                double whr = health_parameters.Result_Whr(answer_daily_survey.Hip, answer_daily_survey.Waist);
                double bmi = health_parameters.Result_Bmi(answer_daily_survey.Weight, answer_daily_survey.Height);
                double cpm = health_parameters.Result_CPM(answer_daily_survey.Weight, answer_daily_survey.Height, answers_survey.Pal, answers_survey.Age, answers_survey.Sex);
                bool AreRequiredFieldsPresent(params object?[] fields) => fields.All(field => field != null);

                var requiredFields = new[] { answer_daily_survey?.Weight, answer_daily_survey?.Height, answer_daily_survey?.Hip, answer_daily_survey?.Waist, answers_survey?.Pal, answers_survey?.Age, answers_survey?.Sex };

                if (AreRequiredFieldsPresent(requiredFields))
                {
                    return BadRequest("Brak niektórych danych");
                }
                List<object> measurements = new List<object> {
                bmi,
                whr,
                cpm
                };

                return measurements;
            }
            );

             return result;
        }
    }
}
