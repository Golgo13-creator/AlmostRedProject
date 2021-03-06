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
    public class PlayerController : ApiController
    {
       private PlayerService CreatePlayerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playerService = new PlayerService(userId);
            return playerService;
        }
        [HttpPost]
        public IHttpActionResult PostPlayer([FromBody] PlayerCreate player)
        {
            if (player is null)
                return BadRequest("Cannot use null values.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerService();
            var isSuccessful = service.CreatePlayer(player);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Player Created");
        }
        [HttpGet]
        public IHttpActionResult GetPlayers()
        {
            var service = CreatePlayerService();
            var players = service.GetAllPlayers();
            if (players is null)
                return InternalServerError();
            return Ok(players);
        }
        [HttpPut]
        public IHttpActionResult PutPlayers(int id, PlayerEdit player)
        {
            if (id < 1)
                return BadRequest("Invalid Player Number entry");
            if (player.Id != id)
                return BadRequest("Player Number missmatch");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlayerService();
            var isSuccessful = service.PutPlayers(player);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Update Successful!");
        }
        [HttpDelete]
        public IHttpActionResult DeletePlayer(int id)
        {
            if (id < 1)
                return BadRequest("Invalid Player Number Entry.");
            var service = CreatePlayerService();
            var isSuccessful = service.DeletePlayers(id);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Delete Successful");
        }
    }
}
