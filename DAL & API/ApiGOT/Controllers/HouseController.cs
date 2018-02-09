﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiGOT.Controllers
{
    public class HouseController : ApiController
    {
        public List<HouseDTO> GetAllHouses()
        {
            List<HouseDTO> houses = new List<HouseDTO>();

            foreach (var house in GameManager.getHouses())
            {
                houses.Add(new HouseDTO(house));
            }

            return houses;
        }
    }
}
