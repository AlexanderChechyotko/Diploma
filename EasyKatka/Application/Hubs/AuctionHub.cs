using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using BLL.Intefaces;
using Application.Util;
using System.Threading.Tasks;
using Application.Tools;

namespace Application.Hubs
{
    public class AuctionHub : Hub
    {
		private IUserService _userService;

		private IAuctionService _auctionService;

		private AuctionProcess _auctionProcess;
		
		public AuctionHub() : this(AutofacConfig.GetUserContext(), AutofacConfig.GetAuctionContext())
		{
		}

		public AuctionHub(IUserService userService, IAuctionService auctionService)
		{
			_userService = userService;
			_auctionService = auctionService;

			_auctionProcess = new AuctionProcess(_auctionService);
			_auctionProcess.SendState += SendState;
			_auctionProcess.Start();
		}

		public void SendState(int auctionId, int ticks, double currentPrice, string lastUser)
		{
			Clients.All.InvokeMessage(auctionId, ticks.ToString(), currentPrice.ToString(), lastUser.ToString());
		}

		public async Task PlaceBet(int auctionId, string userName)
        {
			var n = await _userService.FindByNameAsync(userName);
			_auctionProcess.PlaceBet(auctionId, userName);
			Clients.All.InvokeMessage(userName);
		}
    }
}