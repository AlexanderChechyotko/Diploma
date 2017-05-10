using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class BidsController : Controller
    {
        // GET: Bids
        public ActionResult Index()
        {
            return View();
        }
    }
}