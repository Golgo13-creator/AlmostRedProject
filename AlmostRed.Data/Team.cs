using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostRed.Data
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TeamName { get; set; }
        public virtual ICollection<TeamSport> TeamSports { get; set; } = new List<TeamSport>();
    }
}
