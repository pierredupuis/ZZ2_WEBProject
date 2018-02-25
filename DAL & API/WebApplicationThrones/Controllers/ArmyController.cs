using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationThrones.Models;

namespace WebApplicationThrones.Controllers
{
    public class ArmyController : Controller
    {
        public static async Task<ArmyModel> _GetArmy(int ID)
        {
            ArmyModel Army = null;
            if(ID > 0)
            {
                Army = await HouseController._GetHouse(ID);
            }
            else if(ID < 0)
            {
                Army = await WhiteWalkerController._GetWhiteWalker(ID);
            }
            return Army;
        }
    }
}