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

        public FightDTO()
        {
            Id = -1;
        }

        public FightDTO(int houseChallenging, int houseChallenged, int winningHouse, int id)
        {
            HouseChallenging = houseChallenging;
            HouseChallenged = houseChallenged;
            WinningHouse = winningHouse;
            Id = id;
        }
    }
}