using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Tools.Models
{
	public class LiveAuction
	{
		public int AuctionId { get; set; }

		public int Ticks { get; set; }

		public double CurrentPrice { get; set; }

		public string LastUser { get; set; }
	}
}