using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostRed.Data
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeams { get; set; } = new List<PlayerTeam>();
        public virtual ICollection<PlayerSport> PlayerSports { get; set; } = new List<PlayerSport>();
    }
}
