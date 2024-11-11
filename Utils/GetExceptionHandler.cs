using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Gotrue;

namespace FYR_api.NewFolder
{
    public class GetExceptionHandler : ControllerBase
    {
        public async Task<ActionResult<Session>>ExpectionSessionHandler (Func<Task<Session>> supabaseAction)
        {
            try
            {
                var session = await supabaseAction();
                return new OkObjectResult(session);
            }
            catch (Supabase.Gotrue.Exceptions.GotrueException ex)
            {

                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<ActionResult> ExpectionHandler(Func<Task<object>> supabaseAction)
        {
            try
            {
                var session = await supabaseAction();
                return new OkObjectResult(session);
            }
            catch (Supabase.Gotrue.Exceptions.GotrueException ex)
            {

                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
