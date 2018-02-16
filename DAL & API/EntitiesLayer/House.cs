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

        public Character[] Housers
        {
            get
            {
                return housers;
            }

            set
            {
                housers = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int NumberOfUnits
        {
            get
            {
                return numberOfUnits;
            }

            set
            {
                numberOfUnits = value;
            }
        }

        public void addHousers(Character c) { }
        public House(int p_id, string p_name = "Undefined", int p_numberOfUnits = 0)
        {
            Id = p_id;
            name = p_name;
            numberOfUnits = p_numberOfUnits;
        }
    }
}
