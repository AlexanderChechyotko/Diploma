using System.Web.Http;

namespace EasyKatka.Controllers
{
    public class LotApiController : ApiController
    {
        public IHttpActionResult GetLot(int id)
        {
            return Json("sasha");
        }
    }
}