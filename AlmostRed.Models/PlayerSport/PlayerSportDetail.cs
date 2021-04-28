using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostRed.Models
{
    public class PlayerSportDetail
    {
        public int Id { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int SportId { get; set; }
    }
}
