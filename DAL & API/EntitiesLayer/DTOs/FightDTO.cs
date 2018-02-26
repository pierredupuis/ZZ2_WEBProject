using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EntitiesLayer;

namespace EntitiesLayer.DTOs
{
    public class FightDTO
    {
        public int AttArmy { get; set; }
        public int DefArmy { get; set; }
        public int WinningArmy { get; set; }
        public int Id { get; set; }

        public FightDTO()
        {
            Id = -1;
        }

        public FightDTO(int id, int p_attArmy, int p_defArmy, int winningHouse)
        {
            AttArmy = p_attArmy;
            DefArmy = p_defArmy;
            WinningArmy = winningHouse;
            Id = id;
        }
        public FightDTO(Fight f)
        {
            AttArmy = f.AttArmy.Id;
            DefArmy = f.DefArmy.Id;
            WinningArmy = f.WinningArmy.Id;
        }
    }
}