using Application.Models.AuctionModels;
using Application.Models.PostModels;
using BLL.Intefaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        private IAuctionService _auctionService;

        public HomeController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [AllowAnonymous]
        public ActionResult Index(string filter)
        {
            var auctions = _auctionService.GetAuctions();
            var model = AuctionDescriptionViewModel.BindModelList(auctions);

            //if (filter != null)
            //{
            //    switch (filter)
            //    {
            //        case "DateDesc":
            //            model.Posts = model.Posts.OrderByDescending(m => m.AddedOn).ToList();
            //            break;
            //        case "Date":
            //            model.Posts = model.Posts.OrderBy(m => m.AddedOn).ToList();
            //            break;
            //        case "LikesDesc":
            //            model.Posts = model.Posts.OrderByDescending(m => m.Likes).ToList();
            //            break;
            //        case "Likes":
            //            model.Posts = model.Posts.OrderBy(m => m.Likes).ToList();
            //            break;
            //        default:
            //            model.Posts = model.Posts.OrderByDescending(m => m.AddedOn).ToList();
            //            break;
            //    }
            //}

            return View(model);
        }
    }
}