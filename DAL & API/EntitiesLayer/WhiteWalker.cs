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
            NumberOfUnits += EnnemyCasualties;
            NumberOfUnits -= Casualties;
        }
        public override void LoseBattle(int Casualties, int EnnemyCasualties)
        {
            NumberOfUnits -= Casualties; // No Raising the Dead when you're losing, better focus on running away
        }

        public override string Descriptor()
        {
            return "WhiteWalker";
        }

        public override void UnitWins(Random r)
        {
            // Zombies are binary. They're dead (moving) or they're dead (dead). No Wounds.
        }
        public override void UnitLoses(Random r)
        {
            // Zombies aren't really tough... they lose they die... well, again
        }
        public override void UnitDraw(Random r)
        {
            NumberOfUnits--;
            // Zombies aren't really tough... there is no "draw". They die for real if equality.
        }
    }
}
