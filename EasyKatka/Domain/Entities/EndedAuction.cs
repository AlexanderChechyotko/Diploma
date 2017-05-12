using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class EndedAuction
	{
		public int Id { get; set; }

		public string Winner { get; set; }

		public double WinnerPrice { get; set; }

		public int AuctionId { get; set; }

		public virtual Auction Auction { get; set; }
	}
}
