using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplicationThrones.Models
{
    public class FightModel
    {
        public int ID { get; set; }

        [Display(Name = "Attacking Army")]
        public int Army1 { get; set; }
		
        [Display(Name = "Defending Army")]
        public int Army2 { get; set; }
		
        [Display(Name = "Victorious Army")]
        public int WinningArmy { get; set; }

        public FightModel()
        {

        }

    }
}
