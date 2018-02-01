using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        Character[] Housers;
        String name;
        int numberOfUnits;

        public string Name { get => name; set => name = value; }
        public int NumberOfUnits { get => numberOfUnits; set => numberOfUnits = value; }
        internal Character[] Housers1 { get => Housers; set => Housers = value; }

        public House()
        {

        }
        void AddHousers(Character houser)
        {

        }

        public override String ToString()
        {
            return "House "+name+" has "+Housers.Length+" Residents.\n";
        }
    }
}
