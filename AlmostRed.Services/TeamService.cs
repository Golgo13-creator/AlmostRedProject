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
    public class TeamService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public TeamService(Guid userId)
        {
            _userId = userId;
        }
        //create a team
        public bool CreateTeam(TeamCreate model)
        {
            Team entity = new Team
            {
                TeamName = model.TeamName
            };
            _context.Teams.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get all teams
        public List<TeamDetail> GetAllTeams()
        {
            var teamentities = _context.Teams.ToList();
            var playerList = teamentities.Select(s => new TeamDetail
            {
                Id = s.Id,
                TeamName = s.TeamName
            }).ToList();
            return playerList;
        }
        //update team
        public bool PutTeam(TeamEdit newTeamData)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldPlayerData =
                    ctx
                    .Teams
                    .Single(p => p.Id == newTeamData.Id);

                oldPlayerData.Id = newTeamData.Id;
                oldPlayerData.TeamName = newTeamData.TeamName;
                return ctx.SaveChanges() == 1;
            }
        }
        //delete team
        public bool DeleteTeam(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teamToDelete =
                    ctx
                    .Teams
                    .Single(p => p.Id == id);

                if (teamToDelete != null)
                {
                    ctx.Teams.Remove(teamToDelete);

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
    }
}
