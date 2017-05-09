using BLL.Intefaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servises
{
    public class AuctionService : IAuctionService
    {
        private IUnitOfWork _uow;

        public AuctionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Auction> GetAuctions()
        {
            return _uow.Auctions.GetAll();
        }

        public Auction GetAuctionById(int id)
        {
            var auction = _uow.Auctions.GetAll()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return auction;
        }

        public async Task CreateAuction(Auction auction)
        {
            _uow.Auctions.Create(auction);
            await _uow.SaveAsync();
        }

        public async Task UpdateAuction(Auction auction)
        {
            _uow.Auctions.Update(auction);
            await _uow.SaveAsync();
        }
    }
}
