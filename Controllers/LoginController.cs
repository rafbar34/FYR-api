using FYR_api.Model;
using FYR_api.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Supabase.Gotrue;

namespace FYR_api.Controllers
{
    [Route("/api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ConnectDBService? _connectDb;

            public LoginController(ConnectDBService? connectDb)
        {
            _connectDb = connectDb; 
        }

        [HttpPost]
        [Route("/signUp")]
        public async Task<ActionResult<Session>> Post([FromBody] SignUpRequest request)
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;

            var res = await getExpection.ExpectionHandler(async () =>
            {
                var session = await supabaseClient.Auth.SignUp(request.Email, request.Password);
                return session;
            }
              );

            return res;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult<Session>> Post([FromBody] LoginRequest request)
        {
            var getExpection = new GetExceptionHandler();
            var supabaseClient = _connectDb.SupabaseClient;
            var res =  await getExpection.ExpectionHandler(async () =>
                {
                   var session =   await supabaseClient.Auth.SignIn(request.Email, request.Password);
                    return session;
                }
            );

            return res;
        }

    }
}
