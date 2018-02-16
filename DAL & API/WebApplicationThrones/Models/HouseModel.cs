using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationThrones.Models
{
    public class HouseModel
    {
        public String ID { get; set; }

        [Display(Name = "Name")]
        public String Name { get; set; }

        [Display(Name = "Number of Units")]
        public int NumberOfUnits { get; set; }
		
		[Display(Name = "Housers")]
        List<CharacterModel> Housers { get; set; }

        public HouseModel()
        {

        }

        /*public HouseModel(House h)
        {
            Name = h.Name;
            NumberOfUnits = h.NumberOfUnits;
			Housers = h.Housers;
        }*/
    }
}