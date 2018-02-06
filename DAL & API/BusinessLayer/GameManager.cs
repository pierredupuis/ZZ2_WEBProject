using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLayer
{
    public class GameManager
    {
        public List<Fight> GetFights()
        {
            return DalManager.Instance.GetFights();
        }
    }
}
