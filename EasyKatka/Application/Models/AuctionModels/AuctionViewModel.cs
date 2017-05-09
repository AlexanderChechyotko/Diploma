using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Models.AuctionModels
{
    public class AuctionViewModel
    {
        public int AuctionId { get; set; }

        public LotInformationViewModel LotInformation { get; set; }

        [Required]
        public DateTime TradingDateStart { get; set; }

        [Required]
        public DateTime TradingTimeStart { get; set; }

        public DateTime TradingStart
        {
            get
            {
                return new DateTime(
                    this.TradingDateStart.Year,
                    this.TradingDateStart.Month,
                    this.TradingDateStart.Day,
                    this.TradingTimeStart.Hour,
                    this.TradingTimeStart.Minute,
                    this.TradingTimeStart.Second
                );
            }
        }
    }
}