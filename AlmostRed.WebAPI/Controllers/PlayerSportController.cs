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
    public class PlayerSportController : ApiController
    {
        private PlayerSportService CreatePlayerSportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playerSportService = new PlayerSportService(userId);
            return playerSportService;
        }
        //post playersport
        [HttpPost]
        public IHttpActionResult PostPlayerSport([FromBody] PlayerSportCreate player)
        {
            if (player is null)
                return BadRequest("Cannot use null values.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerSportService();
            var isSuccessful = service.CreatePlayerSport(player);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("PlayerSport Created");
        }
        //get players by sport
        [HttpGet]
        public IHttpActionResult GetPlayersBySport(int sportId)
        {
            PlayerSportService playerSportService = CreatePlayerSportService();
            var playersport = playerSportService.GetPlayersBySport(sportId);
            return Ok(playersport);
        }
    }
}
