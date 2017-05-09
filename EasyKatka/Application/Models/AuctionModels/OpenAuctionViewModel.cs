using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.AuctionModels
{
    public class OpenAuctionViewModel
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public double StartPrice { get; set; }

        public DateTime TradingStart { get; set; }
    }
}