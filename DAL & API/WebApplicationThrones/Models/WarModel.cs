using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationThrones.Models
{
    public class WarModel
    {
		public int ID { get; set; }

		[Display(Name = "Alliance 1")]
        public List<HouseModel> Alliance1 { get; set; }
		
		[Display(Name = "Alliance 2")]
        public List<HouseModel> Alliance2 { get; set; }
		
		[Display(Name = "Fights")]
        public List<FightModel> Fights { get; set; }

        public WarModel()
        {

        }

        /*public WarModel(War w)
        {
			Fights = w.Fights;
			Alliance1 = w.Alliance1;
			Alliance2 = w.Alliance2;
        }*/

    }
}
