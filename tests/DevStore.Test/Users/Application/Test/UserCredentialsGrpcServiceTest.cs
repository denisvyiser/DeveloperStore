using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Grpc.Contracts;
using DevStore.Test.Users.Fixtures;
using DevStore.Users.Application.Queries;
using DevStore.Users.Application.Services;
using DevStore.Users.Domain.Models.Entities;
using DevStore.Users.Domain.Models.Enums;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevStore.Test.Users.Application.Test
{
    public class UserCredentialsGrpcServiceTest
    {
        private readonly IMediatorHandler _mediator;
        private readonly UserCredentialsGrpcService _userCredentialsGrpcService;

        public UserCredentialsGrpcServiceTest()
        {
            _mediator = Substitute.For<IMediatorHandler>();
            _userCredentialsGrpcService = new UserCredentialsGrpcService(_mediator);
        }

        [Fact]
        public async Task GetUserByCredentials_Should_Return_Valid_UserCredentialsResponse_When_User_Exists()
        {
            // Arrange
            var request = new UserCredentialsRequest
            {
                UserName = "testuser",
                Password = "password123"
            };

            var userEntity = UserFixture.CreateUserRandom();

            var getUserByCredentialsQuery = new GetUserByCredentialsQuery
            {
                UserName = request.UserName,
                Password = request.Password
            };

            _mediator.SendQuery(Arg.Any<GetUserByCredentialsQuery>())
                     .Returns(userEntity);

            var expectedResponse = new UserCredentialsResponse
            {
                UserName = userEntity.UserName,
                Name = new NameResponse
                {
                    FirstName = userEntity.Name.FirstName,
                    LastName = userEntity.Name.LastName
                },
                Role = userEntity.Role.ToString(),
                Status = userEntity.Status.ToString()
            };

            // Act
            var result = await _userCredentialsGrpcService.GetUserByCredentials(request);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(expectedResponse);
            result.Error.Should().BeNull();
            await _mediator.Received(1).SendQuery(Arg.Any<GetUserByCredentialsQuery>());
        }

        [Fact]
        public async Task GetUserByCredentials_Should_Return_Error_When_User_Not_Found()
        {
            // Arrange
            var request = new UserCredentialsRequest
            {
                UserName = "invaliduser",
                Password = "wrongpassword"
            };

            _mediator.SendQuery(Arg.Any<GetUserByCredentialsQuery>())
                     .Returns((User)null);  // Simulating user not found

            // Act
            var result = await _userCredentialsGrpcService.GetUserByCredentials(request);

            // Assert
            result.Should().NotBeNull();
            result.Error.Should().Be("Invalid User or Password");
            result.Data.Should().BeNull();
            await _mediator.Received(1).SendQuery(Arg.Any<GetUserByCredentialsQuery>());
        }
    }
}
