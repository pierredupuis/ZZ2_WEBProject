using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EntitiesLayer.DTOs;
using BusinessLayer;

namespace ApiGOT.Controllers
{
    public class TerritoryController : ApiController
    {
        public IHttpActionResult GetAllTerritorys()
        {
            List<TerritoryDTO> Territorys = new List<TerritoryDTO>();

            foreach (var Territory in GameManager.Instance.GetTerritorys())
            {
                Territorys.Add(Territory);
            }

            return Ok(Territorys);
        }

        public IHttpActionResult GetTerritoryById(int id)
        {
            TerritoryDTO Territory = GameManager.Instance.GetTerritoryById(id);
            if (Territory.Id == -1)
                return NotFound();
            else
                return Ok(Territory);
        }

        public IHttpActionResult PostTerritory([FromBody] TerritoryDTO Territory)
        {
            GameManager.Instance.AddTerritory(Territory);
            return Ok();
        }

        public IHttpActionResult PutTerritory([FromBody] TerritoryDTO Territory)
        {
            GameManager.Instance.EditTerritory(Territory);
            return Ok();
        }

        public IHttpActionResult DeleteTerritory(int id)
        {
            GameManager.Instance.DeleteTerritory(id);
            return Ok();
        }
    }
}
