using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Interfaces;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.test.Offers.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ExecuteSuccess(int itemId)
        {
            //Arrange
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

            var offerRepositoryMock = new Mock<IOfferRepository>();
            var loggedUserMock = new Mock<ILoggedUser>();

            loggedUserMock.Setup(i => i.User()).Returns(new User());

            var createOfferUseCase = new CreateOfferUseCase(loggedUserMock.Object, offerRepositoryMock.Object);

            //Act
            var act = () => createOfferUseCase.Execute(itemId, request);

            //Assert
            act.Should().NotThrow();

        }
    }
}
