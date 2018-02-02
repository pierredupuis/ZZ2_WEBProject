using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ApiGOT.Models;
using DataAccessLayer;

namespace ApiGOT.Controllers
{
    public class CharacterController : ApiController
    {
        public List<CharacterDTO> getAllCharacters()
        {
            List<CharacterDTO> list = new List<CharacterDTO>();

            DalManager m = DalManager.Instance;

            foreach(var charac in m.getAllCharacters())
            {
                list.Add(new CharacterDTO(charac));
            }

            return list;
        }
    }
}
