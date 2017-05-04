using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKatka.Models.Models
{
    public class Lot
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TradingStart { get; set; }

        public string ImagePath { get; set; }

        public double StartPrice { get; set; }
    }
}
