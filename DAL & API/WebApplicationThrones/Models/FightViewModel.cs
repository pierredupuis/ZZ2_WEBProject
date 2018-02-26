using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationThrones.Models
{
    public class FightViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Attacking Army")]
        public HouseModel AttArmy { get; set; }

        [Display(Name = "Defending Army")]
        public ArmyModel DefArmy { get; set; }

        [Display(Name = "Victorious Army")]
        public ArmyModel WinningArmy { get; set; }

        public FightViewModel()
        {

        }
    }
}