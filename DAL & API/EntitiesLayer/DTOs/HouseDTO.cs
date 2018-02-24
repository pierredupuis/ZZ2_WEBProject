using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EntitiesLayer.DTOs
{
    public class HouseDTO
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public int NumberOfUnits { get; set; }

        // Lors de la reception du JSON, créé un HouseDTO automatiquement : a besoin d'un constructeur par défaut.
        public HouseDTO()
        {
            Id = -1;
        }

        public HouseDTO(int id, string name, int numberOfUnits)
        {
            Id = id;
            Name = name;
            NumberOfUnits = numberOfUnits;
        }

        public HouseDTO(House house)
        {
            Id = house.Id;
            Name = house.Name;
            NumberOfUnits = house.NumberOfUnits;
        }
    }
}