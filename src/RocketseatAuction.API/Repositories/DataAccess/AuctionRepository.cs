using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Interfaces;

namespace RocketseatAuction.API.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly RocketseatAuctionDbContext _rocketseatAuctionDbContext;

        public AuctionRepository(RocketseatAuctionDbContext rocketseatAuctionDbContext) =>
            _rocketseatAuctionDbContext = rocketseatAuctionDbContext;

        public Auction? GetCurrent()
        {
            var today = new DateTime(2024, 01, 25);

            return _rocketseatAuctionDbContext.Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);

        }
    }
}
