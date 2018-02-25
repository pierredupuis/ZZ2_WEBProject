using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        public Army Army1 { get; set; }
        public Army Army2 { get; set; }
        public Army WinningArmy { get; set; }



        public Fight(int p_id, Army p_army1, Army p_army2, Army p_winningArmy)
        {
            Army1 = p_army1;
            Army2 = p_army2;
            WinningArmy = p_winningArmy;

            base.Id = p_id;
        }

       
    }
}
