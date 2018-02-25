using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntitiesLayer;

namespace EntitiesLayer.DTOs
{
    public class FightDTO
    {
        public int Army1 { get; set; }
        public int Army2 { get; set; }
        public int WinningArmy { get; set; }
        public int Id { get; set; }

        public FightDTO()
        {
            Id = -1;
        }

        public FightDTO(int army1, int army2, int winningHouse, int id)
        {
            Army1 = army1;
            Army2 = army2;
            WinningArmy = winningHouse;
            Id = id;
        }
        public FightDTO(Fight f)
        {
            Army1 = f.Army1.Id;
            Army2 = f.Army2.Id;
            WinningArmy = f.WinningArmy.Id;
        }
    }
}