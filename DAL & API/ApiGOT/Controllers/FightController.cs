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
    public class FightController : ApiController
    {
        public IHttpActionResult GetAllFights()
        {
            List<FightDTO> Fights = new List<FightDTO>();

            foreach (var Fight in GameManager.Instance.GetFights())
            {
                Fights.Add(Fight);
            }

            return Ok(Fights);
        }

        public IHttpActionResult GetFightById(int id)
        {
            FightDTO Fight = GameManager.Instance.GetFightById(id);
            if (Fight.Id == -1)
                return NotFound();
            else
                return Ok(Fight);
        }

        public IHttpActionResult PostFight([FromBody] FightDTO Fight)
        {
            GameManager.Instance.AddFight(Fight);
            return Ok();
        }

        public IHttpActionResult PutFight([FromBody] FightDTO Fight)
        {
            GameManager.Instance.EditFight(Fight);
            return Ok();
        }

        public IHttpActionResult DeleteFight(int id)
        {
            GameManager.Instance.DeleteFight(id);
            return Ok();
        }
    }
}
