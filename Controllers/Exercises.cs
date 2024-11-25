using FYR_api.Model;
using FYR_api.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYR_api.Controllers
{
    public class Exercises : ControllerBase
    {

        public readonly ConnectDBService? _connectDb;
        public Exercises(ConnectDBService? connectDb)
        {
            _connectDb = connectDb;
        }

        [HttpGet]
        [Route("/user-exercises/{id}")]
        public async Task<ActionResult> GetUserExercises(Guid id)
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;


            var result = await getExpection.ExpectionHandler(async () =>
            {
                var res = await supabaseClient.From<ExercisesUserModel>().Where(x => x.UserId == id).Get();
                return res;
            });

            return result;

        }
        [HttpPost]
        [Route("/user-exercises/{id}")]
        public async Task<ActionResult> AddNewUserExercise(Guid id, [FromBody] ExercisesRequest data)
        {

            if (data == null)
            {
                return BadRequest("Dane wejściowe są puste.");
            }



            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;


            var result = await getExpection.ExpectionHandler(async () =>
            {
                var newData = new ExercisesUserModel
                {
                    Info = data.Info,
                    Name = data.Name,
                    Sets = data.Sets,
                    UserId = id,
                    ExeId = data.Exeid
                };
                var res = await supabaseClient.From<ExercisesUserModel>().Insert(newData);
                return res;
            });

            return result;
        }


        [HttpGet]
        [Route("/exercises")]
        public async Task<ActionResult> getExercises()
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;
            var result = await getExpection.ExpectionHandler(async () =>
                {
                    var res = await supabaseClient.From<ExercisesModel>().Get();
                    return res;
                }
                );

            return result;
        }
    }
}