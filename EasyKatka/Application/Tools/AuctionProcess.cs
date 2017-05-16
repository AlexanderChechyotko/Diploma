using Application.Tools.Models;
using BLL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Application.Tools
{
	public class AuctionProcess
	{
		private IAuctionService _auctionService;

		private Dictionary<int, LiveAuction> _liveAuctions = new Dictionary<int, LiveAuction>();

		private Dictionary<int, WaitedAuction> _waitedAuctions = new Dictionary<int, WaitedAuction>();

		private object _locker = new object();

		public delegate void SendAuctionStateHandler(int auctionId, int ticks, double currentPrice, string lastUser);

		public event SendAuctionStateHandler SendState;

		public event SendAuctionStateHandler SetWinner;

		public AuctionProcess(IAuctionService auctionService)
		{
			_auctionService = auctionService;
		}

		private void SetWaitingAuctions()
		{
			var waitedAuctions = _auctionService.GetAuctions().Where(x => x.TradingStart > DateTime.Now);

			foreach (var auction in waitedAuctions)
			{
				if (!_waitedAuctions.ContainsKey(auction.Id))
				{
					var waitedAuction = new WaitedAuction
					{
						AuctionId = auction.Id,
						LastUser = auction.User.Email,
						StartPrice = auction.StartPrice,
						TradingStart = auction.TradingStart
					};

					_waitedAuctions.Add(auction.Id, waitedAuction);
				}
			}
		}

		private void SetLiveAuctions()
		{
			var liveAuctions = _waitedAuctions.Where(x => x.Value.TradingStart <= DateTime.Now);

			foreach (var auction in liveAuctions)
			{
				if (!_liveAuctions.ContainsKey(auction.Key))
				{
					var liveAuction = new LiveAuction
					{
						AuctionId = auction.Key,
						CurrentPrice = auction.Value.StartPrice,
						LastUser = auction.Value.LastUser,
						Ticks = 5
					};

					_liveAuctions.Add(auction.Key, liveAuction);
					_waitedAuctions.Remove(auction.Key);
				}
			}
		}

		public void PlaceBet(int auctionId, string userName)
		{

		}

		private void TimerHandler(object obj)
		{
			ParallelLoopResult result = Parallel.ForEach(_liveAuctions,
				(x) =>
				{
					x.Value.Ticks--;

					if (x.Value.Ticks >= 0)
					{
						SendState?.Invoke(x.Value.AuctionId, x.Value.Ticks, x.Value.CurrentPrice, x.Value.LastUser);
					}
					else
					{
						SetWinner?.Invoke(x.Value.AuctionId, x.Value.Ticks, x.Value.CurrentPrice, x.Value.LastUser);
						_waitedAuctions.Remove(x.Value.AuctionId);
					}
				});
		}

		public void Start()
		{
			TimerCallback timerCallback = new TimerCallback(TimerHandler);
			Timer timer = new Timer(timerCallback, null, 100, 1000);
		}
	}
}