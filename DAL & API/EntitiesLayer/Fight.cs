using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer
{
    public class Fight
    {
        House houseChallenged;
        House houseChallenging;
        House winningHouse;

        public override String ToString()
        {
            return "House " + houseChallenging.toString() + " VS. " + houseChallenging.toString();
        }
    }
}
