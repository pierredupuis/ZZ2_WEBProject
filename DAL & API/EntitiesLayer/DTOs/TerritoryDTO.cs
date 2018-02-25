using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntitiesLayer.DTOs
{
    public class TerritoryDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Owner { get; set; }


        public TerritoryDTO()
        {
            Id = -1;
        }

        public TerritoryDTO(int id, string type, int owner)
        {
            Id = id;
            Owner = owner;
        }
    }
}