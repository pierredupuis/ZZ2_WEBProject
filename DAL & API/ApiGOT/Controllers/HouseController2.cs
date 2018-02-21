using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiGOT.Controllers
{
    public class HouseController2 : ApiController
    {
        // GET: api/HouseController2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HouseController2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HouseController2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HouseController2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HouseController2/5
        public void Delete(int id)
        {
        }
    }
}
