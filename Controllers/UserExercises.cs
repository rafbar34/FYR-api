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
    public class UserExercises : ControllerBase
    {

    public readonly ConnectDBService? _connectDb;
        public UserExercises(ConnectDBService? connectDb)
        {
            _connectDb = connectDb;
        }
 
        [HttpGet]
        [Route("/exercises/{id}")]
        public async Task<ActionResult> GetExercises(Guid id)
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;


            var result = await getExpection.ExpectionHandler(async () =>
            {
                var res = await supabaseClient.From<ExercisesModel>().Where(x => x.UserId == id).Get();
                return res;
            });

            return result;
            
        }
    }
}
