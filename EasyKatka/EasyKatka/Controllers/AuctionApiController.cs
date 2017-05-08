using System.Collections.Generic;
using System.Web.Http;

namespace EasyKatka.Controllers
{
    public class AuctionApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> GetAuctions()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IHttpActionResult AddLot()
        {
            return Ok();
        }
    }
}