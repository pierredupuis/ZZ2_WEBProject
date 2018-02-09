using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntitiesLayer;

namespace ApiGOT.Models
{
    public class FightDTO
    {
        public int HouseChallenging { get; set; }
        public int HouseChallenged { get; set; }
        public int WinningHouse { get; set; }
        public int Id { get; set; }

        /*public FightDTO(Fight fight)
        {
            Id = fight.Id;
            HouseChallenging = fight.HouseChallenger1;
            HouseChallenged = fight.HouseChallenger2;
            WinningHouse = fight.WinningHouse;
        }*/

    }
}