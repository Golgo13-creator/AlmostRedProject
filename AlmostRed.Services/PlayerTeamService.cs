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
    public class PlayerTeamService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public PlayerTeamService(Guid userId)
        {
            _userId = userId;
        }
        //create playerteam
        public bool CreatePlayerTeam(PlayerTeamCreate model)
        {
            PlayerTeam entity = new PlayerTeam
            {
                PlayerId = model.PlayerId,
                TeamId = model.TeamId
            };
            _context.PlayerTeams.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get(players by team)
        public List<PlayerTeamDetail> GetPlayersByTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PlayerTeams
                        .Where(e => e.TeamId == teamId)
                        .Select(
                            e =>
                                new PlayerTeamDetail
                                {
                                    Id = e.Id,
                                    PlayerId = e.PlayerId,
                                    TeamId = e.TeamId
                                }
                        );
                return query.ToList();
            }
        }
    }
}
