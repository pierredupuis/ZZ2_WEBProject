using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

using EntitiesLayer;
namespace ApiGOT.Models
{
    [DataContract]
    public class HouseDTO
    {
        [DataMember]
        public int Id { get; set;}
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NumberOfUnits { get; set; }

        // Lors de la reception du JSON, créé un HouseDTO automatiquement : a besoin d'un constructeur par défaut.
        public HouseDTO()
        {
            Id = -1;
        }

        public HouseDTO(House house)
        {
            Id = house.Id;
            Name = house.Name;
            NumberOfUnits = house.NumberOfUnits;
        }
    }
}