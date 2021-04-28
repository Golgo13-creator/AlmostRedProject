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
    public class PlayerTeamController : ApiController
    {
        private PlayerTeamService CreatePlayerTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playerTeamService = new PlayerTeamService(userId);
            return playerTeamService;
        }
        //post playerteam
        [HttpPost]
        public IHttpActionResult PostPlayerTeam([FromBody] PlayerTeamCreate player)
        {
            if (player is null)
                return BadRequest("Cannot use null values.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerTeamService();
            var isSuccessful = service.CreatePlayerTeam(player);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("PlayerTeam Created");
        }
        //get players by team
        [HttpGet]
        public IHttpActionResult GetPlayersByTeam(int teamId)
        {
            PlayerTeamService playerTeamService = CreatePlayerTeamService();
            var playerteams = playerTeamService.GetPlayersByTeam(teamId);
            return Ok(playerteams);
        }
    }
}
