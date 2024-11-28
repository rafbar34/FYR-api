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
    public class Workout : ControllerBase
    {
        private readonly ConnectDBService? _connectDb;
        
            public Workout(ConnectDBService? connectDb)
            { 
            _connectDb = connectDb;
            }
        

        [HttpGet]
        [Route("/workout/{id}")]
        public async Task<ActionResult> GetWorkouts(Guid id)
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;


            var result = await getExpection.ExpectionHandler(async () =>
            {
                var res = await supabaseClient.From<WorkoutModel>().Where((x) => x.UserId == id).Get();
                return res.Models;
            });
            return Ok(result);

        }
    }
}
