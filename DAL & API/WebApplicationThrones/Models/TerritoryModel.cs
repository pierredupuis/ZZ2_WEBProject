using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationThrones.Models
{
    public class TerritoryModel
    {
		[Display(Name = "Territory Type")]
        public TerritoryTypeEnum TerritoryType { get; set; }
		
		[Display(Name = "Owner")]
        public HouseModel Owner { get; set; }
        
        public TerritoryModel()
        {

        }

    }
}
