using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ApiGOT.Models;
using BusinessLayer;

namespace ApiGOT.Controllers
{
    public class CharacterController : ApiController
    {
        public IHttpActionResult GetAllCharacters()
        {
            List<CharacterDTO> Characters = new List<CharacterDTO>();

            foreach (var Character in GameManager.Instance.GetCharacters())
            {
                Characters.Add(Character);
            }

            return Ok(Characters);
        }

        public IHttpActionResult GetCharacterById(int id)
        {
            CharacterDTO Character = GameManager.Instance.GetCharacterById(id);
            if (Character.Id == -1)
                return NotFound();
            else
                return Ok(Character);
        }

        public IHttpActionResult PostCharacter([FromBody] CharacterDTO Character)
        {
            GameManager.Instance.AddCharacter(Character);
            return Ok();
        }

        public IHttpActionResult PutCharacter([FromBody] CharacterDTO Character)
        {
            GameManager.Instance.EditCharacter(Character);
            return Ok();
        }

        public IHttpActionResult DeleteCharacter(int id)
        {
            GameManager.Instance.DeleteCharacter(id);
            return Ok();
        }
    }
}
