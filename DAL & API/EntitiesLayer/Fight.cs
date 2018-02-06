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

        public House HouseChallenger1 { get => houseChallenger1; set => houseChallenger1 = value; }
        public House HouseChallenger2 { get => houseChallenger2; set => houseChallenger2 = value; }
        public House WinningHouse { get => winningHouse; set => winningHouse = value; }
        public int Id { get => id; set => id = value; }

        public Fight(int p_id, House p_houseChallenger1, House p_houseChallenger2, House p_winningHouse)
        {
            HouseChallenger1 = p_houseChallenger1;
            HouseChallenger2 = p_houseChallenger2;
            WinningHouse = p_winningHouse;

            id = p_id;
        }
    }
}
