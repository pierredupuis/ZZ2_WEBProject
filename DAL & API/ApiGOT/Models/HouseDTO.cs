using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGOT.Models
{
    public class HouseDTO
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public int nbOfUnits { get; set; }

        public HouseDTO(House house)
        {
            Id = house.Id;
            Name = house.Name;
            nbOfUnits = house.NbOfUnits;
        }
    }
}