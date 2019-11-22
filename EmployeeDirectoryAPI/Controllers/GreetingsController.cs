using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryAPI.Authorization;
using EmployeeDirectoryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDirectoryAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Greetings")]
    public class GreetingsController : Controller
    {
        private IGreetingsRepository greetingsRepsository;
        GoogleAuthorization googleAuth = new GoogleAuthorization();

        public GreetingsController(IGreetingsRepository _greetingsRepsository)
        {
            greetingsRepsository = _greetingsRepsository;
        }

        [HttpGet("Bday/{BdayMonth}")]
        public IActionResult getBdayEmployees(int BdayMonth,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var allBday = greetingsRepsository.getAllBirthdayEmployee(BdayMonth);
                    return Ok(allBday);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(exp);
            }

        }

        [HttpGet("anniversary/{AnniverMonth}")]
        public IActionResult getanniversary(int AnniverMonth,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var allAnniver = greetingsRepsository.getAllAniversaryEmployee(AnniverMonth, DateTime.Now.Year);
                    return Ok(allAnniver);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound(exp);
            }

        }
    }
}