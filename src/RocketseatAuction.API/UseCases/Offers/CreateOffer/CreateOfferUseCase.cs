using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Interfaces;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;

        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }
        
        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.UtcNow,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };
            
            _offerRepository.Add(offer);

            return offer.Id;
        }
    }
}
