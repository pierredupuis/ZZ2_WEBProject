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

        [Display(Name = "Attacking House")]
        public HouseModel HouseChallenger { get; set; }
		
        [Display(Name = "Defending House")]
        public HouseModel HouseChallenged { get; set; }
		
        [Display(Name = "Victorious House")]
        public HouseModel WinningHouse { get; set; }

        public FightModel()
        {

        }

    }
}
