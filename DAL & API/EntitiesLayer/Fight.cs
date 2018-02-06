using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        House houseChallenger1;
        House houseChallenger2;
        House winningHouse;

        static int currId = 0;

        public Fight(House p_houseChallenger1, House p_houseChallenger2, House p_winningHouse)
        {
            houseChallenger1 = p_houseChallenger1;
            houseChallenger2 = p_houseChallenger2;
            winningHouse = p_winningHouse;

            id = currId;
            currId++;
        }
    }
}
