using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplicationThrones.Models;

namespace WPFofThrones.Models
{
    public class WhiteWalkerModel : ArmyModel
    {
        public int Id { get; set; }
        
        public WhiteWalkerModel()
        {
            Name = "Dead";
        }

        
    }
}