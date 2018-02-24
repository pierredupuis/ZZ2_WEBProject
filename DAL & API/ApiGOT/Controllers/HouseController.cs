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
using System.Web;

namespace ApiGOT.Controllers
{
    public class HouseController : ApiController
    {

        public IHttpActionResult GetAllHouses()
        {
            List<HouseDTO> houses = new List<HouseDTO>();

            foreach (var house in GameManager.Instance.GetHouses())
            {
                houses.Add(house);
            }

            return Ok(houses);
        }

        public IHttpActionResult GetHouseById(int id)
        {
            HouseDTO house = GameManager.Instance.GetHouseById(id);
            if (house.Id == -1)
                return NotFound();
            else
                return Ok(house);
        }

        public IHttpActionResult PostHouse([FromBody] HouseDTO house)
        {
            GameManager.Instance.AddHouse(house);
            return Ok();
        }

        public IHttpActionResult PutHouse([FromBody] HouseDTO house)
        {
            GameManager.Instance.EditHouse(house);
            return Ok();
        }

        public IHttpActionResult DeleteHouse(int id)
        {
            GameManager.Instance.DeleteHouse(id);
            return Ok();
        }
    }
}
