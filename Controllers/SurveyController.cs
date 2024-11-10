﻿using FYR_api.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet]
        [Route("/survey/user/{id}")]
        public async Task<ActionResult> GetUserSurvey(string id)
        {
            if (id == null)
            {
                return BadRequest("Bad user ID");
            }
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<UsersSurveyModel>().Where(x=>x.UserId == id).Get();
            var survey_data = result.Models;

            return Ok(result);
        }

        [HttpPatch]
        [Route("/survey/user/{id}")]
        public async Task<ActionResult> UpdateSurvey(string id,[FromBody] SurveyRequest request)
        {
            if (id == null)
            {
                return BadRequest("Bad user ID");
            }
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await supabaseClient.From<UsersSurveyModel>().Where(x => x.UserId == id).Set(x => x.Answers, request.Answers).Update(); ;
            Console.WriteLine($"UserSurveyModel data: {JsonConvert.SerializeObject(result)}"); // Logowanie


            if (result.Models == null || !result.Models.Any())  // Sprawdzamy, czy operacja się powiodła
            {
                return BadRequest("Error updating survey.");
            }

            return Ok(new { message = "Survey updated successfully", result });
        }
    }
}
