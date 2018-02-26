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
    public class WhiteWalkerController : ApiController
    {

        public IHttpActionResult GetAllWhiteWalkers()
        {
            List<WhiteWalkerDTO> wws = new List<WhiteWalkerDTO>();

            foreach (var ww in GameManager.Instance.GetWhiteWalkers())
            {
                wws.Add(ww);
            }

            return Ok(wws);
        }

        public IHttpActionResult GetWhiteWalkerById(int id)
        {
            WhiteWalkerDTO ww = GameManager.Instance.GetWhiteWalkerById(id);
            if (ww.Id == 0)
                return NotFound();
            else
                return Ok(ww);
        }
        
        public IHttpActionResult PostWhiteWalker(WhiteWalkerDTO ww)
        {
            GameManager.Instance.AddWhiteWalker(ww);
            return Ok();
        }

        public IHttpActionResult PutWhiteWalker([FromBody] WhiteWalkerDTO ww)
        {
            GameManager.Instance.EditWhiteWalker(ww);
            return Ok();
        }

        public IHttpActionResult DeleteWhiteWalker(int id)
        {
            GameManager.Instance.DeleteWhiteWalker(id);
            return Ok();
        }
    }
}
