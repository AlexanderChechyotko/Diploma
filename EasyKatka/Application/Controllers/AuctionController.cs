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
		private List<string> _allowedMimetypes = new List<string>
		{
			"image/jpeg",
			"image/pjpeg",
			"image/png",
			"image/svg+xml"
		};

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
				if (auctionVm.LotInformation.UploadedImage != null && auctionVm.LotInformation.UploadedImage.ContentLength > 0)
				{
					if (_allowedMimetypes.Contains(auctionVm.LotInformation.UploadedImage.ContentType))
					{
						string userId = AuthenticationManager.User.Claims.ElementAt(0).Value;

						Auction auction = new Auction
						{
							LotPhoto = new LotPhoto
							{
								FileName = Path.GetFileName(auctionVm.LotInformation.UploadedImage.FileName),
								ContentType = auctionVm.LotInformation.UploadedImage.ContentType
							},
							Title = auctionVm.LotInformation.Title,
							StartPrice = auctionVm.LotInformation.StartPrice,
							TradingStart = auctionVm.TradingStart,
							UserId = userId,
						};
						using (var reader = new BinaryReader(auctionVm.LotInformation.UploadedImage.InputStream))
						{
							auction.LotPhoto.Content = reader.ReadBytes(auctionVm.LotInformation.UploadedImage.ContentLength);
						}

						await _auctionService.CreateAuction(auction);
						return RedirectToAction("Index", "Home");
					}
					else
					{
						ModelState.AddModelError("LotPhoto", "Некорректный формат изображения");
					}
				}
				else
				{
					ModelState.AddModelError("LotPhoto", "Изображение не было получено");
				}
            }

            return View(auctionVm);
        }

        [AllowAnonymous]
        public async Task<ActionResult> GetImage(int id)
        {
            var auction = _auctionService.GetAuctionById(id);
            var fileToRetrieve = auction.LotPhoto;

            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
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

			string userName = AuthenticationManager.User.Identity.Name;
            AuctionDescriptionViewModel model = AuctionDescriptionViewModel.BindModel(auction, userName);

			return View("Auction", model);
        }
    }
}