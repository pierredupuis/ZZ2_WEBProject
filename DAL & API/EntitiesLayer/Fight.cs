using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        Army armyChallenger1;
        Army armyChallenger2;
        Army winningArmy;

        

        public Fight(int p_id, Army p_armyChallenger1, Army p_armyChallenger2, Army p_winningArmy)
        {
            ArmyChallenger1 = p_armyChallenger1;
            ArmyChallenger2 = p_armyChallenger2;
            WinningArmy = p_winningArmy;

            base.Id = p_id;
        }

        public Army ArmyChallenger1
        {
            get
            {
                return armyChallenger1;
            }

            set
            {
                armyChallenger1 = value;
            }
        }

        public Army ArmyChallenger2
        {
            get
            {
                return armyChallenger2;
            }

            set
            {
                armyChallenger2 = value;
            }
        }

        public Army WinningArmy
        {
            get
            {
                return winningArmy;
            }

            set
            {
                winningArmy = value;
            }
        }
    }
}
