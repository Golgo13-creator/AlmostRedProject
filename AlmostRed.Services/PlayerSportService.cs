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
    public class PlayerSportService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public PlayerSportService(Guid userId)
        {
            _userId = userId;
        }
        //create playersport
        public bool CreatePlayerSport(PlayerSportCreate model)
        {
            PlayerSport entity = new PlayerSport
            {
                PlayerId = model.PlayerId,
                SportId = model.SportId
            };
            _context.PlayerSports.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get(players by sport)
        public List<PlayerSportDetail> GetPlayersBySport(int sportId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PlayerSports
                        .Where(e => e.SportId == sportId)
                        .Select(
                            e =>
                                new PlayerSportDetail
                                {
                                    Id = e.Id,
                                    PlayerId = e.PlayerId,
                                    SportId = e.SportId
                                }
                        );
                return query.ToList();
            }
        }
        //update playersport
        public bool PutPlayersSport(PlayerSportEdit playerSportData)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldPlayerSportData =
                    ctx
                    .PlayerSports
                    .Single(p => p.Id == playerSportData.Id);

                oldPlayerSportData.Id = playerSportData.Id;
                oldPlayerSportData.PlayerId = playerSportData.PlayerId;
                oldPlayerSportData.SportId = playerSportData.SportId;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
