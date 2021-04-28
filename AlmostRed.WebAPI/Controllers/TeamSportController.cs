using AlmostRed.Models;
using AlmostRed.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlmostRed.WebAPI.Controllers
{
    [Authorize]
    public class TeamSportController : ApiController
    {
        private TeamSportService CreateTeamSportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamSportService = new TeamSportService(userId);
            return teamSportService;
        }
        //post teamsport
        [HttpPost]
        public IHttpActionResult PostTeamSport([FromBody] TeamSportCreate sport)
        {
            if (sport is null)
                return BadRequest("Cannot use null values.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamSportService();
            var isSuccessful = service.CreateTeamSport(sport);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("TeamSport Created");
        }
        //get teams by sport
        [HttpGet]
        public IHttpActionResult GetTeamsBySport(int sportId)
        {
            TeamSportService teamSportService = CreateTeamSportService();
            var teamsport = teamSportService.GetTeamsBySport(sportId);
            return Ok(teamsport);
        }
    }
}
