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
    public class TeamController : ApiController
    {
        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamService = new TeamService(userId);
            return teamService;
        }
        [HttpPost]
        public IHttpActionResult PostTeam([FromBody] TeamCreate team)
        {
            if (team is null)
                return BadRequest("Cannot use null values.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            var isSuccessful = service.CreateTeam(team);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Team Created");
        }
        [HttpGet]
        public IHttpActionResult GetTeams()
        {
            var service = CreateTeamService();
            var teams = service.GetAllTeams();
            if (teams is null)
                return InternalServerError();
            return Ok(teams);
        }
        [HttpPut]
        public IHttpActionResult PutTeams(int id, TeamEdit team)
        {
            if (id < 1)
                return BadRequest("Invalid Team Number entry");
            if (team.Id != id)
                return BadRequest("Team Number missmatch");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTeamService();
            var isSuccessful = service.PutTeam(team);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Update Successful!");
        }
        [HttpDelete]
        public IHttpActionResult DeleteTeam(int id)
        {
            if (id < 1)
                return BadRequest("Invalid Team Number Entry.");
            var service = CreateTeamService();
            var isSuccessful = service.DeleteTeam(id);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Delete Successful");
        }
    }
}
