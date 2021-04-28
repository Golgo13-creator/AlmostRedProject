﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmostRed.Models
{
    public class SportCreate
    {
        [Required]
        [Display(Name = "Sport Name")]
        public string SportName { get; set; }
    }
}
