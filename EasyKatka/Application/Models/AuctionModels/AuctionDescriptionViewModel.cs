using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.AuctionModels
{
    public class AuctionDescriptionViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public double StartPrice { get; set; }

        public DateTime TradingStart { get; set; }

        public static List<AuctionDescriptionViewModel> BindModelList(IEnumerable<Auction> auctions)
        {
            return auctions.Select(x => new AuctionDescriptionViewModel
            {
                Id = x.Id,
                UserName = null,
                Title = x.Title,
                TradingStart = x.TradingStart,
                StartPrice = x.StartPrice
            }).ToList();
        }

        public static AuctionDescriptionViewModel BindModel(Auction auction, string userName)
        {
            return new AuctionDescriptionViewModel
            {
                Id = auction.Id,
                UserName = userName,
                Title = auction.Title,
                TradingStart = auction.TradingStart,
                StartPrice = auction.StartPrice
            };
        }
    }
}