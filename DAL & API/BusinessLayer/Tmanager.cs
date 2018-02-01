using System;
using StubDataAccessLayer;
using System.Linq;
using System.Collections.Generic;
using EntitiesLayer;

namespace BusinessLayer
{
    public class Tmanager
    {
        static DalManager _manager = new StubDataAccessLayer.DalManager();
        public List<House> GetHouses()
        {
            List<House> houses = new List<House>(_manager.GetExsistingHouses());
            IEnumerable<House> query = from h in houses select h;
            return query.ToList<House>();
            /*foreach (House s in query)
                Console.WriteLine(s.ToString());*/
        }

        public List<House> GettHousesOver200Units()
        {
            List<House> houses = new List<House>(_manager.Get200UnitHouses());
            IEnumerable<House> query = from h in houses where h.NumberOfUnits > 200 select h;
            return query.ToList<House>();
            /*foreach (House s in query)
                Console.WriteLine(s.ToString());*/
        }

        public List<Character> GetCharacters()
        {
            List<Character> chars = new List<Character>(_manager.GetCharacters());
            IEnumerable<Character> query = from h in chars where (h.Pv > 50) && (h.Pf > 3) select h;
            return query.ToList<Character>();
            /*foreach (Character c in query)
                Console.WriteLine(c.ToString());*/
        }

        public List<Territory> GetTerritories()
        {
            List<Territory> ters = new List<Territory>(_manager.GetExistingTerritories());
            IEnumerable<Territory> query = from h in ters select h;
            return query.ToList<Territory>();
            /*foreach (Territory t in query)
                Console.WriteLine(t.ToString());*/
        }
  
    }
}
