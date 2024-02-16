using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.Interfaces;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void ExecuteSucess()
        {
            //Arrange

            var auctionTest = new Faker<Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1, 700))
                .RuleFor(action => action.Name, f => f.Lorem.Word())
                .RuleFor(action => action.Starts, f=> f.Date.Past())
                .RuleFor(action => action.Ends, f=> f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
                {
                    new Item
                    {
                        Id = f.Random.Number(1, 700),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(5, 1000),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var auctionRepositoryMock = new Mock<IAuctionRepository>();

            auctionRepositoryMock.Setup(i => i.GetCurrent()).Returns(auctionTest);

            var getCurrentAuctionUseCase = new GetCurrentAuctionUseCase(auctionRepositoryMock.Object);

            //Act
            var auction = getCurrentAuctionUseCase.Execute();

            //Assert
            auction.Should().NotBeNull();
            auction.Id.Should().Be(auctionTest.Id);
            auction.Name.Should().Be(auctionTest.Name);
        }
    }
}
