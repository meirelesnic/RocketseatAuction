using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Interfaces;

namespace RocketseatAuction.API.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly RocketseatAuctionDbContext _rocketseatAuctionDbContext;

        public OfferRepository(RocketseatAuctionDbContext rocketseatAuctionDbContext) =>
            _rocketseatAuctionDbContext = rocketseatAuctionDbContext;

        public void Add(Offer offer)
        {

            _rocketseatAuctionDbContext.Offers.Add(offer);

            _rocketseatAuctionDbContext.SaveChanges();
        }
    }
}
