using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntitiesLayer;
using ApiGOT.Models;
using BusinessLayer;
using Newtonsoft.Json;

/*
 * Uniquement utilisé pour rélaiser des tests avec la WebApp tant que l'API n'est pas fonctionnelle
 */

namespace ApiGOT.Controllers
{
    public class HouseTestController : ApiController
    {
        private static List<HouseDTO> TestList = new List<HouseDTO>() { new HouseDTO(new House(0, "Stark", 120)), new HouseDTO(new House(1, "Baratheon", 50)), new HouseDTO(new House(2, "Lannister", 500)) };

        public List<HouseDTO> GetAllHouses()
        {
            /*List<HouseDTO> houses = new List<HouseDTO>();

            foreach (var house in GameManager.GetHouses())
            {
                houses.Add(new HouseDTO(house));
            }

            return houses;*/
            return TestList;
        }

        public HouseDTO GetHouseByID(int ID)
        {
            return TestList.ElementAt(ID);
        }
        
        public void PostHouse(HouseDTO house)
        {

            if (house != null)
            {
                TestList.Add(house);
            }
            else
            {
               throw new NullReferenceException();
            }
        }
        
        public void DeleteHouse(int id)
        {
            foreach(HouseDTO h in TestList)
            {
                if(h.Id == id)
                {
                    TestList.Remove(h);
                }
            }
        }
    }
}
