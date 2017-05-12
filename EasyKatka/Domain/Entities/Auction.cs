using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public LotPhoto LotPhoto { get; set; }

        public double StartPrice { get; set; }

        public DateTime TradingStart { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
