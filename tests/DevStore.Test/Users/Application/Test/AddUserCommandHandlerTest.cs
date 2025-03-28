using AutoMapper;
using Bogus;
using DevStore.Core.Helpers.Repository;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Models.Entities;
using DevStore.Test.Users.Fixtures;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Events;
using DevStore.Users.Application.Handlers.Commands;
using DevStore.Users.Domain.Interfaces.Repositories;
using DevStore.Users.Domain.Models.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevStore.Test.Users.Application.Test
{
    public class AddUserCommandHandlerTest
    {
    private readonly IMediatorHandler _mediator;
    private readonly IMapper _mapper;
    private readonly IUsersRepository _repository;
    private readonly AddUserCommandHandler _handler;

    public AddUserCommandHandlerTest()
    {
        // Setup the mocked dependencies
        _mediator = Substitute.For<IMediatorHandler>();
        _mapper = Substitute.For<IMapper>();
        _repository = Substitute.For<IUsersRepository>();

        // Instantiate the handler with mocked dependencies
        _handler = new AddUserCommandHandler(_mediator, _mapper, _repository);
    }

    [Fact]
    public async Task ApplyCommandAsync_Should_Throw_ValidationError_When_User_Already_Exists()
    {
        // Arrange
        var fakeUser = UserFixture.CreateUserRandom();

            var addUserCommand = new AddUserCommand(
        fakeUser.Email,
            fakeUser.UserName,
            fakeUser.Password,
            fakeUser.Name,
            fakeUser.Address,
        fakeUser.Phone,
            fakeUser.Status,
            fakeUser.Role);

        // Setup the mocked behavior
        _mapper.Map<User>(addUserCommand).Returns(fakeUser);

            // Simulate the user already existing in the repository
        var query = _handler.CheckExists(fakeUser, LogicalOperator.And);
        _repository.GetFirstByExpressionAsync(Arg.Any<Expression<Func<User, bool>>>()).Returns(fakeUser);

        // Act
        await _handler.ApplyCommandAsync(addUserCommand);            

        // Assert
        await _mediator.DidNotReceive().RaiseEvent(Arg.Any<UserCreatedEvent>());        
    }

    [Fact]
    public async Task ApplyCommandAsync_Should_Insert_User_When_No_Duplicate_Found()
    {
            // Arrange
            var fakeUser = UserFixture.CreateUserRandom();

            var addUserCommand = new AddUserCommand(
        fakeUser.Email,
            fakeUser.UserName,
            fakeUser.Password,
            fakeUser.Name,
            fakeUser.Address,
            fakeUser.Phone,
        fakeUser.Status,
            fakeUser.Role);

        // Setup the mocked behavior
        _mapper.Map<User>(addUserCommand).Returns(fakeUser);

        // Simulate the user not existing in the repository
        var query = _handler.CheckExists(fakeUser, LogicalOperator.And);
        _repository.GetFirstByExpressionAsync(query).Returns((User)null); // User doesn't exist

        // Act
        await _handler.ApplyCommandAsync(addUserCommand);

        // Assert
        await _mediator.Received(1).RaiseEvent(Arg.Any<UserCreatedEvent>());
        await _repository.Received(1).InsertAsync(fakeUser);
    }    

    [Fact]
    public async Task ApplyCommandAsync_Should_Apply_Business_Rules_And_Persist_User()
    {
            // Arrange
            var fakeUser = UserFixture.CreateUserRandom();

            var addUserCommand = new AddUserCommand(
        fakeUser.Email,
        fakeUser.UserName,
            fakeUser.Password,
            fakeUser.Name,
            fakeUser.Address,
            fakeUser.Phone,
        fakeUser.Status,
            fakeUser.Role);

        // Setup the mocked behavior
        _mapper.Map<User>(addUserCommand).Returns(fakeUser);

        // Simulate the user not existing in the repository
        var query = _handler.CheckExists(fakeUser, LogicalOperator.And);
        _repository.GetFirstByExpressionAsync(query).Returns((User)null);

        // Act
        await _handler.ApplyCommandAsync(addUserCommand);

        // Assert
        await _repository.Received(1).InsertAsync(fakeUser); // Ensure the user is inserted
        await _mediator.Received(1).RaiseEvent(Arg.Any<UserCreatedEvent>()); // Ensure the event is raised
    }
}
}
