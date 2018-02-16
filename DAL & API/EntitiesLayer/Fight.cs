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

        

        public Fight(int p_id, House p_houseChallenger1, House p_houseChallenger2, House p_winningHouse)
        {
            HouseChallenger1 = p_houseChallenger1;
            HouseChallenger2 = p_houseChallenger2;
            WinningHouse = p_winningHouse;

            base.Id = p_id;
        }

        public House HouseChallenger1
        {
            get
            {
                return houseChallenger1;
            }

            set
            {
                houseChallenger1 = value;
            }
        }

        public House HouseChallenger2
        {
            get
            {
                return houseChallenger2;
            }

            set
            {
                houseChallenger2 = value;
            }
        }

        public House WinningHouse
        {
            get
            {
                return winningHouse;
            }

            set
            {
                winningHouse = value;
            }
        }
    }
}
