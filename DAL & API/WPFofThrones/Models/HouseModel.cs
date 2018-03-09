using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplicationThrones.Models;

namespace WPFofThrones.Models
{
    public class HouseModel : ArmyModel
    {
        public int ID { get; set; }

        public HouseModel()
        {

        }

        public override String ToString()
        {
            return Name + " " + NumberOfUnits;
        }
    }
}