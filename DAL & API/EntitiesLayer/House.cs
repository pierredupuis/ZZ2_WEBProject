﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.DTOs;

namespace EntitiesLayer
{
    public class House : Army
    {
        public Character[] Housers { get; set; }
        public string Name { get; set; }

        public House(int p_id, string p_name = "Undefined", int p_numberOfUnits = 0)
        {
            Id = p_id;
            Name = p_name;
            NumberOfUnits = p_numberOfUnits;
        }
        public House(HouseDTO hdto)
        {
            Id = hdto.Id;
            Name = hdto.Name;
            NumberOfUnits = hdto.NumberOfUnits;
        }

        public void addHousers(Character c) { }

        public override void WinBattle(int Casualties, int EnnemyCasualties)
        {
            NumberOfUnits += 10; // Reputation Bonus. Great victories means more people willing to enroll !
        }

        public override void LoseBattle(int Casualties, int EnnemyCasualties)
        {
            NumberOfUnits = 0; // Reputation Malus. Dude, you're losing, it's sad, but nobody wants to be with you at the end.
        }

        public override string Descriptor()
        {
            return "House";
        }

        public override void UnitLoses(Random r)
        {
            if (r.Next(0, 10) < 9)  // 1/10 to survive
                NumberOfUnits--;
        }
        public override void UnitWins(Random r)
        {
            if (r.Next(0, 20) == 19) // 1/20 to die from wounds
                NumberOfUnits--;
        }

        public override void UnitDraw(Random r)
        {
            if (r.Next(0, 20) == 19) // 1/20 to die from wounds
                NumberOfUnits--;
        }
    }
}
