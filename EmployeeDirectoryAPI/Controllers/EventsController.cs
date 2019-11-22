using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectoryAPI.Authorization;
using EmployeeDirectoryAPI.Models;
using EmployeeDirectoryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeDirectoryAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {

        private readonly ILogger<EmployeeListController> _logger;
        private IEventsRepository eventsRepository;
        GoogleAuthorization googleAuth = new GoogleAuthorization();
        public EventsController(IEventsRepository _eventsRepository, ILogger<EmployeeListController> logger)
        {
            _logger = logger;
            eventsRepository = _eventsRepository;  
        }

        [HttpGet]
        public IActionResult GetEvents([FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken)){
                    var allEvents = eventsRepository.GetAllEvents();
                    return Ok(allEvents);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }

        [HttpGet("{eventId}")]
        public IActionResult GetEvents(int eventId,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                if (googleAuth.ProcessRequestAtGoogle(googleToken))
                {
                    var eventDetails = eventsRepository.GetEventDetails(eventId);
                    return Ok(eventDetails);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }


        [HttpPost("add")]
        public IActionResult AddEvents([FromBody] EventsDto eventData,
            [FromHeader(Name = "id_token")]string googleToken)
        {
            try
            {
                eventsRepository.AddEvents(eventData);
                return Ok("Added the Event");
            }
            catch (Exception exp)
            {
                return NotFound();
            }
        }


    }
}