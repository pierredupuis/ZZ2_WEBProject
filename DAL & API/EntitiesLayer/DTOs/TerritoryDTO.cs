using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntitiesLayer.DTOs
{
    public class TerritoryDTO
    {
        public int Id { get; set; }
        public int Owner { get; set; }


        public TerritoryDTO()
        {

        }
        /*public TerritoryDTO(Territory territory)
        {
            Id = territory.Id;
            Owner = territory.Owner;
        }*/
    }
}