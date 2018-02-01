using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        List<House> Houses;
        List<Territory> Territories;
         List<Character> Characters;

        public DalManager()
        {

        }
        public DalManager(List<House> h, List<Territory> t, List<Character> c)
        {
            Houses = new List<House>(h);
            Territories = new List<Territory>(t);
            Characters = new List<Character>(c);
        }

        public List<House> GetExsistingHouses()
        {
            return Houses;
        }
        public List<House> Get200UnitHouses()
        {
            List<House> tmp = new List<House>();
            foreach (House h in Houses)
            {
                if (h.NumberOfUnits > 200)
                {
                    tmp.Add(h);
                }
            }
            return tmp;
        }

        public List<Territory> GetExistingTerritories()
        {
            return Territories;
        }

        public List<Character> GetCharacters()
        {
            return Characters;
        }

        public List<String> GetCaracts()
        {
            List<String> caracts = new List<string>();
            foreach(Character c in Characters)
            {
                caracts.Add(c.ToString());
            }
            return caracts;
        }

    }
}
