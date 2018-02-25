using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationThrones.Models
{
    public class WhiteWalkerModel
    {
        public int Id { get; set; }

        [Display(Name = "Number of Units")]
        public int NumberOfUnits { get; set; }

        public WhiteWalkerModel()
        {

        }

        
    }
}