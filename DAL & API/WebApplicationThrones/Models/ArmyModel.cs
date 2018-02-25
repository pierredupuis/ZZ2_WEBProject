using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationThrones.Models
{
    public abstract class ArmyModel
    {
        [Display(Name = "Number of Units")]
        public int NumberOfUnits { get; set; }

        public string Name { get; set; }
    }
}