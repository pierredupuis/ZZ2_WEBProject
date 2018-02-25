using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationThrones.Models
{
    public class HouseModel : ArmyModel
    {
        public int ID { get; set; }
        		
		[Display(Name = "Housers")]
        List<CharacterModel> Housers { get; set; }

        public HouseModel()
        {

        }

    }
}