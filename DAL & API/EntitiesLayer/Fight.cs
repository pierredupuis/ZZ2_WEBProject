using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        public Army AttArmy { get; set; }
        public Army DefArmy { get; set; }
        public Army WinningArmy { get; set; }



        public Fight(int p_id, Army p_AttArmy, Army p_DefArmy, Army p_winningArmy)
        {
            AttArmy = p_AttArmy;
            DefArmy = p_DefArmy;
            WinningArmy = p_winningArmy;

            base.Id = p_id;
        }

       
    }
}
