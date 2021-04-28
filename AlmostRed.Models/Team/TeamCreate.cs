using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostRed.Models
{
    public class TeamCreate
    {
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
    }
}
