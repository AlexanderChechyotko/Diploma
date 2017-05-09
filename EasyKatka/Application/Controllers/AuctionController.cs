using Application.Helpers;
using Application.Models.AuctionModels;
using BLL.Intefaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class AuctionController : BaseController
    {
        private IUserService _userService;

        private IAuctionService _auctionService;

        public AuctionController(IUserService userSevice, IAuctionService auctionService)
        {
            _userService = userSevice;
            _auctionService = auctionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin, user")]
        public async Task<ActionResult> CreateAuction()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAuction(AuctionViewModel auctionVm)
        {
            if (ModelState.IsValid)
            {
                string imagePath = $"{AppConfigManager.LotsImagesBasePath}/{ (new Random()).Next(10000, int.MaxValue)}{auctionVm.LotInformation.UploadedImage.FileName}";
                if (auctionVm.LotInformation.UploadedImage != null)
                {
                    auctionVm.LotInformation.UploadedImage.SaveAs(imagePath);
                }
                string userId = AuthenticationManager.User.Claims.ElementAt(0).Value;

                Auction auction = new Auction
                {
                    ImagePath = imagePath,
                    Title = auctionVm.LotInformation.Title,
                    StartPrice = auctionVm.LotInformation.StartPrice,
                    TradingStart = auctionVm.TradingStart,
                    UserId = userId,
                };

                await _auctionService.CreateAuction(auction);
                return RedirectToAction("Index", "Home");
            }

            return View(auctionVm);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Open(int id)
        {
            Auction auction = _auctionService.GetAuctionById(id);

            if (auction == null)
            {
                ModelState.AddModelError("", "Лот не найден");
                return View("error");
            }

            AuctionDescriptionViewModel model = AuctionDescriptionViewModel.BindModel(auction);

            return View("Auction", model);
        }
    }
}