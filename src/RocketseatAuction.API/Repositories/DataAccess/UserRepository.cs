using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Interfaces;

namespace RocketseatAuction.API.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly RocketseatAuctionDbContext _rocketseatAuctionDbContext;

        public UserRepository(RocketseatAuctionDbContext rocketseatAuctionDbContext) =>
            _rocketseatAuctionDbContext = rocketseatAuctionDbContext;

        public bool ExistUserWithEmail(string email)
        {
            return _rocketseatAuctionDbContext.Users.Any(user => user.Email.Equals(email));
        }

        public User GetUserByEmail(string email)
        {
            return _rocketseatAuctionDbContext.Users.First(user => user.Email.Equals(email));
        }
    }
}
