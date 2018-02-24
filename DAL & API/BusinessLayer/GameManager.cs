using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using EntitiesLayer;

namespace BusinessLayer
{
    public class GameManager
    {
        private static readonly Lazy<GameManager> lazy = new Lazy<GameManager>(() => new GameManager());

        public static GameManager Instance { get { return lazy.Value; } }
        GameManager()
        {
            
        }


        /*public static List<Fight> GetFights()
        {
            return DalManager.Instance.GetFights();
        }*/
        public List<House> GetHouses()
        {
            return DalManager.Instance.GetHouses();
        }
        public House GetHouseById(int p_id)
        {
            return DalManager.Instance.GetHouseById(p_id);
        }
        public void AddHouse(string name, int nbOfUnits)
        {
            DalManager.Instance.AddHouse(name, nbOfUnits);
        }
        public void EditHouse(int id, string name, int nbOfUnits)
        {
            DalManager.Instance.EditHouse(id, name, nbOfUnits);
        }
        public void DeleteHouse(int id)
        {
            DalManager.Instance.DeleteHouse(id);
        }
    }
}
