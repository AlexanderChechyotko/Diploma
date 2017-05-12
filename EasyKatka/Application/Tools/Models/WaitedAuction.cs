using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Tools.Models
{
	public class WaitedAuction
	{
		public int AuctionId { get; set; }

		public DateTime TradingStart { get; set; }

		public double StartPrice { get; set; }

		public string LastUser { get; set; }
	}
}