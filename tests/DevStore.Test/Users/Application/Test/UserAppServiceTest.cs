using AutoMapper;
using DevStore.Application.Core.Views;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Models.Pagination;
using DevStore.Test.Users.Fixtures;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Queries;
using DevStore.Users.Application.Services;
using DevStore.Users.Application.Views;
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
    public class UserAppServiceTest
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly UserAppService _userAppService;

        public UserAppServiceTest()
        {
            _mapper = Substitute.For<IMapper>();
            _mediator = Substitute.For<IMediatorHandler>();
            _userAppService = new UserAppService(_mapper, _mediator);
        }

        [Fact]
        public async Task Get_Should_Return_Valid_UserView_When_User_Exists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = UserFixture.CreateUserRandom(userId);
            
            _mediator.SendQuery(Arg.Any<GetUserByIdQuery>())
                     .Returns(user);  // Return the mocked user entity

            _mapper.Map<UserView>(user).Returns(UserFixture.MapEntityToView(user));  // Map to the UserView

            // Act
            var result = await _userAppService.Get(userId);

            // Assert
            result.Should().NotBeNull();
            result.Email.Should().Be(user.Email);
            result.UserName.Should().Be(user.UserName);
            await _mediator.Received(1).SendQuery(Arg.Any<GetUserByIdQuery>());
            _mapper.Received(1).Map<UserView>(user);
        }

        [Fact]
        public async Task GetPaginated_Should_Return_Valid_PaginatedList_When_Users_Exist()
        {
            // Arrange

            var listUser = UserFixture.CreateUserList(10);

            var queryParams = new Dictionary<string, string> { { "page", "1" }, { "pageSize", "10" } };

            var paginatedResult = new PaginatedList<User>(
                listUser.AsQueryable(),
                new PaginationObject()
                {
                    Order = new List<Order> { new Core.Models.Pagination.Order("Id", "asc") },
                    Page = new Page(1, 10),
                    TotalItem = 10
                });


            var userViewList = new List<UserView> { new UserView { Email = "test@example.com", UserName = "testuser" } };

            _mediator.SendQuery(Arg.Any<GetUserPaginatedQuery>())
                     .Returns(paginatedResult);

            _mapper.Map<PaginatedList<UserView>>(paginatedResult).Returns(new PaginatedList<UserView>
            (UserFixture.MapEntityListToViewList(listUser).AsQueryable(),
                 new PaginationObject()
                {
                    Order = new List<Order> { new Core.Models.Pagination.Order("Id", "asc") },
                    Page = new Page(1, 10),
                    TotalItem = 10
                })

            );

            // Act
            var result = await _userAppService.GetPaginated(queryParams);

            // Assert
            result.Should().NotBeNull();
            result.TotalItem.Should().Be(paginatedResult.TotalItem);
            result.Data.Should().HaveCount(paginatedResult.Data.Count);
            await _mediator.Received(1).SendQuery(Arg.Any<GetUserPaginatedQuery>());
            _mapper.Received(1).Map<PaginatedList<UserView>>(paginatedResult);
        }

        [Fact]
        public async Task Save_Should_Return_Saved_UserView_When_Valid_Model_Is_Provided()
        {
            // Arrange
            var user = UserFixture.CreateUserRandom();

            var addUserCommand = new AddUserCommand(user.Email, user.UserName, user.Password, user.Name, user.Address, user.Phone, user.Status, user.Role);
            
            _mapper.Map<AddUserCommand>(Arg.Any<UserView>()).Returns(addUserCommand);
            _mediator.SendCommand(addUserCommand).Returns(Task.CompletedTask);
            _mapper.Map<UserView>(Arg.Any<User>()).Returns(UserFixture.MapEntityToView(user));

            // Act
            var result = await _userAppService.Save(UserFixture.MapEntityToView(user));

            // Assert
            result.Should().NotBeNull();
            result.Email.Should().Be(user.Email);   
        }

        [Fact]
        public async Task Update_Should_Return_Updated_UserView_When_Valid_Model_Is_Provided()
        {
            // Arrange
            var userView = UserFixture.CreateUserRandom();

            var updateUserCommand = new UpdateUserCommand(Guid.NewGuid(), userView.Email, userView.UserName, userView.Password, userView.Name, userView.Address, userView.Phone, userView.Status, userView.Role);

            _mapper.Map<UpdateUserCommand>(Arg.Any<UserView>()).Returns(updateUserCommand);
            _mediator.SendCommand(updateUserCommand).Returns(Task.CompletedTask);
            _mapper.Map<UserView>(Arg.Any<User>()).Returns(UserFixture.MapEntityToView(userView));

            // Act
            var result = await _userAppService.Update(UserFixture.MapEntityToView(userView));

            // Assert
            result.Should().NotBeNull();
            result.Email.Should().Be(userView.Email);

        }

        [Fact]
        public async Task Remove_Should_Call_Mediator_To_Remove_User()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var removeCommand = new RemoveUserCommand(userId);

            _mediator.SendCommand(removeCommand).Returns(Task.CompletedTask);

            // Act
            Func<Task> func = async () => { await _userAppService.Remove(userId); };


            // Assert
            await func.Should().NotThrowAsync();
        }
    }
}
