using FYR_api.Model;
using Microsoft.AspNetCore.Mvc;
using Supabase.Gotrue;
using System.Net;

namespace FYR_api.Controllers
{
    [Route("/api")]
    [ApiController]
    public class SurveyController: ControllerBase
    {
        private readonly ConnectDBService? _connectDb;

        public SurveyController(ConnectDBService? connectDb) {
            _connectDb = connectDb;
        }
        [HttpGet]
        [Route("/survey")]
        public async Task<ActionResult> GetSurvey()
        {
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<SurveyModel>().Get();
            var survey_data = result.Models;

            if(result.ResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest(result.Models);
            }
            return Ok(result.Models);
        }

        [HttpPatch]
        [Route("/survey")]
        public async Task<ActionResult> PostSurvey([FromBody] SurveyRequest request)
        {
            var supabaseClient = _connectDb.SupabaseClient;
            var result = supabaseClient.From<UserSurveyModel>().Where(x => x.UserId == request.UserId).Set(x => x.Answers, request);

            return Ok(result);
        }
    }
}
