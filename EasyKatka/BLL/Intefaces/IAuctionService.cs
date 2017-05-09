using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IAuctionService
    {
        IEnumerable<Auction> GetAuctions();

        Auction GetAuctionById(int id);

        Task CreateAuction(Auction auction);

        Task UpdateAuction(Auction auction);
    }
}
