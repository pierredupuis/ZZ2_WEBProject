using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationThrones.Models
{
    public class HousesModel
    {
        public List<HouseModel> list { get; set; }

        public HousesModel()
        {
            list = new List<HouseModel>();
        }
    }

}