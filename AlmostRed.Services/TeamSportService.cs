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
    public class TeamSportService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public TeamSportService(Guid userId)
        {
            _userId = userId;
        }
        //create teamsport
        public bool CreateTeamSport(TeamSportCreate model)
        {
            TeamSport entity = new TeamSport
            {
                TeamId = model.TeamId,
                SportId = model.SportId
            };
            _context.TeamSports.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get(get teams by sport)
        public List<TeamSportDetail> GetTeamsBySport(int sportId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeamSports
                        .Where(e => e.SportId == sportId)
                        .Select(
                            e =>
                                new TeamSportDetail
                                {
                                    Id = e.Id,
                                    TeamId = e.TeamId,
                                    SportId = e.SportId
                                }
                        );
                return query.ToList();
            }
        }
    }
}
