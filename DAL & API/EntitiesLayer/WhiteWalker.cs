using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.DTOs;

namespace EntitiesLayer
{
    public class WhiteWalker : Army
    {
        public WhiteWalker(int p_id, int p_numberOfUnits = 0)
        {
            Id = p_id;
            NumberOfUnits = p_numberOfUnits;
        }
        public WhiteWalker(WhiteWalkerDTO wwdto)
        {
            Id = wwdto.Id;
            NumberOfUnits = wwdto.NumberOfUnits;
        }

        public override void WinBattle(int Casualties, int EnnemyCasualties)
        {
            // Raise the Dead ! But no reputation bonus. No one volunteers for joining the army of the dead...
            NumberOfUnits += EnnemyCasualties - Casualties;
        }
        public override void LoseBattle(int Casualties, int EnnemyCasualties)
        {
            NumberOfUnits -= Casualties; // No Raising the Dead when you're losing, better focus on running away
        }

    }
}
