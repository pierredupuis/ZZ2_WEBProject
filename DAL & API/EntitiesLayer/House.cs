using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        Character[] housers;
        string name;
        int numberOfUnits;

        static int currId = 0;

        public string Name { get => name; set => name = value; }
        public int NumberOfUnits { get => numberOfUnits; set => numberOfUnits = value; }
        internal Character[] Housers { get => housers; set => housers = value; }

        public void addHousers(Character c) { }
        public House(string p_name = "Undefined", int p_numberOfUnits = 0)
        {
            name = p_name;
            numberOfUnits = p_numberOfUnits;

            id = currId;
            currId++;
        }


    }
}
