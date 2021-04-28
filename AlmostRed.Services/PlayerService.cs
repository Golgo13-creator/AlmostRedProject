using AlmostRed.Data;
using AlmostRed.Models;
using AlmostRed.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostRed.Services
{
    public class PlayerService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public PlayerService(Guid userId)
        {
            _userId = userId;
        }
        //create a player
        public bool CreatePlayer(PlayerCreate model)
        {
            Player entity = new Player
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            _context.Players.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get all players
        public List<PlayerDetail> GetAllPlayers()
        {
            var playerentities = _context.Players.ToList();
            var playerList = playerentities.Select(s => new PlayerDetail
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName
            }).ToList();
            return playerList;
        }
        //update player
        public bool PutPlayers(PlayerEdit newPlayerData)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldPlayerData =
                    ctx
                    .Players
                    .Single(p => p.Id == newPlayerData.Id);

                oldPlayerData.Id = newPlayerData.Id;
                oldPlayerData.FirstName = newPlayerData.FirstName;
                oldPlayerData.LastName = newPlayerData.LastName;
                return ctx.SaveChanges() == 1;
            }
        }
        //delete player
        public bool DeletePlayers(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var playerToDelete =
                    ctx
                    .Players
                    .Single(p => p.Id == id);

                if (playerToDelete != null)
                {
                    ctx.Players.Remove(playerToDelete);

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
    }
}
