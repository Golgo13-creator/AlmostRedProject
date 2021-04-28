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
    public class SportService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public SportService(Guid userId)
        {
            _userId = userId;
        }
        //create a sport
        public bool CreateSport(SportCreate model)
        {
            Sport entity = new Sport
            {
                SportName = model.SportName
            };
            _context.Sports.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get all sports
        public List<SportDetail> GetAllSports()
        {
            var sportentities = _context.Sports.ToList();
            var sportList = sportentities.Select(s => new SportDetail
            {
                Id = s.Id,
                SportName = s.SportName
            }).ToList();
            return sportList;
        }
        //update sport
        public bool PutSport(SportEdit newSportData)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldSportData =
                    ctx
                    .Sports
                    .Single(p => p.Id == newSportData.Id);

                oldSportData.Id = newSportData.Id;
                oldSportData.SportName = newSportData.SportName;
                return ctx.SaveChanges() == 1;
            }
        }
        //delete sport
        public bool DeleteSport(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var sportToDelete =
                    ctx
                    .Sports
                    .Single(p => p.Id == id);

                if (sportToDelete != null)
                {
                    ctx.Sports.Remove(sportToDelete);

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
    }
}
