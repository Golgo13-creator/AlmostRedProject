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
    public class SportController : ApiController
    {
        private SportService CreateSportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var sportService = new SportService(userId);
            return sportService;
        }
        [HttpPost]
        public IHttpActionResult PostSport([FromBody] SportCreate player)
        {
            if (player is null)
                return BadRequest("Cannot use null values.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSportService();
            var isSuccessful = service.CreateSport(player);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Sport Created");
        }
        [HttpGet]
        public IHttpActionResult GetSports()
        {
            var service = CreateSportService();
            var sports = service.GetAllSports();
            if (sports is null)
                return InternalServerError();
            return Ok(sports);
        }
        [HttpPut]
        public IHttpActionResult PutSports(int id, SportEdit sport)
        {
            if (id < 1)
                return BadRequest("Invalid Sport Number entry");
            if (sport.Id != id)
                return BadRequest("Sport Number missmatch");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateSportService();
            var isSuccessful = service.PutSport(sport);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Update Successful!");
        }
        [HttpDelete]
        public IHttpActionResult DeleteSport(int id)
        {
            if (id < 1)
                return BadRequest("Invalid Sport Number Entry.");
            var service = CreateSportService();
            var isSuccessful = service.DeleteSport(id);
            if (!isSuccessful)
                return InternalServerError();
            return Ok("Delete Successful");
        }
    }
}
