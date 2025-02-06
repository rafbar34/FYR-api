using FYR_api.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Supabase.Gotrue;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FYR_api.Controllers
{
    [Route("/api")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ConnectDBService? _connectDb;

        public SurveyController(ConnectDBService? connectDb)
        {
            _connectDb = connectDb;
        }
        [HttpGet]
        [Route("/survey")]
        public async Task<ActionResult> GetSurvey()
        {
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<SurveyModel>().Get();
            var survey_data = result.Models;

            if (result.ResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest(result.Models);
            }
            return Ok(result.Models);
        }

        [HttpGet]
        [Route("/survey/user/{id}")]
        public async Task<ActionResult> GetUserSurvey(Guid id)
        {
            if (id == null)
            {
                return BadRequest("Bad user ID");
            }
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<UsersSurveyModel>().Where(x => x.UserId == id).Get();
            var survey_data = result.Models;

            return Ok(result.Model);
        }

        [HttpPost]
        [Route("/survey/user/{id}")]
        public async Task<ActionResult> PostSurvey(Guid id, [FromBody] SurveyRequest request)
        {
            if (id == null)
            {
                return BadRequest("Bad user ID");
            }
            Guid newGuid = Guid.NewGuid();
            var newData = new UsersSurveyModel
            {
                Id = newGuid,
                UserId = id,
                Age = request.Age,
                Sex = request.Sex,
                Name = request.Name,
                Pal = request.Pal,
                Sleep = request.AverageSleep,
                IsCompleted = request.IsCompleted,
            };
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<UsersSurveyModel>().Insert(newData);

            if (result.Models == null || !result.Models.Any())
            {
                return BadRequest("Error post survey.");
            }

            return Ok(new { message = "Survey saved successfully", result });
        }

        [HttpPatch]
        [Route("/survey/user/{id}")]
        public async Task<ActionResult> UpdateSurvey(Guid id, [FromBody] SurveyRequest request)
        {
            if (id == null)
            {
                return BadRequest("Bad user ID");
            }
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<UsersSurveyModel>().Where(x => x.UserId == id).Set(x => x, request).Update(); ;
            Console.WriteLine($"UserSurveyModel data: {JsonConvert.SerializeObject(result)}");


            if (result.Models == null || !result.Models.Any())
            {
                return BadRequest("Error updating survey.");
            }

            return Ok(new { message = "Survey updated successfully", result });
        }


        [HttpGet]
        [Route("/user/daily_survey/{id}")]
        public async Task<ActionResult> DailySurvey(Guid id)
        {
            if (id == null) return BadRequest("Bad user ID");
            
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<DailySurveyModel>().Where(x => x.UserId == id).Get();
            var survey_data = result.Models;

            return Ok(result.Model);
        }
    }
}
