using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BusinessLayer;
using EntitiesLayer.DTOs;

namespace ApiGOT.Controllers
{
    public class WarController : ApiController
    {
        public IHttpActionResult GetAllWars()
        {
            List<WarDTO> Wars = new List<WarDTO>();

            foreach (var War in GameManager.Instance.GetWars())
            {
                Wars.Add(War);
            }

            return Ok(Wars);
        }

        public IHttpActionResult GetWarById(int id)
        {
            WarDTO War = GameManager.Instance.GetWarById(id);
            if (War.Id == -1)
                return NotFound();
            else
                return Ok(War);
        }

        public IHttpActionResult PostWar([FromBody] WarDTO War)
        {
            GameManager.Instance.AddWar(War);
            return Ok();
        }

        /*public IHttpActionResult PutWar([FromBody] WarDTO War)
        {
            GameManager.Instance.EditWar(War);
            return Ok();
        }*/

        public IHttpActionResult DeleteWar(int id)
        {
            GameManager.Instance.DeleteWar(id);
            return Ok();
        }
    }
}
