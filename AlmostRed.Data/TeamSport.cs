using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostRed.Data
{
    public class TeamSport
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(Sport))]
        public int SportId { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
