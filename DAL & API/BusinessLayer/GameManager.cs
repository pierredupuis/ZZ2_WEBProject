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
        public static List<Fight> GetFights()
        {
            return DalManager.Instance.GetFights();
        }
    }
}
