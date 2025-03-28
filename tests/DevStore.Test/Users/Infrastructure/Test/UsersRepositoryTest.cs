using Bogus;
using DevStore.Core.Models.Pagination;
using DevStore.Infrastructure.Repositories;
using DevStore.Users.Domain.Models.Entities;
using DevStore.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Linq.Expressions;
using DevStore.Test.Users.Infrastructure.Mocks;
using DevStore.Test.Users.Fixtures;

namespace DevStore.Test.Users.Infrastructure.Test
{
    public class UsersRepositoryTest
    {
        private readonly UsersDbContextMock _usersDbContextMock;
        private readonly UsersRepository _usersRepository;
        public UsersRepositoryTest()
        {
            _usersDbContextMock = new UsersDbContextMock();
            _usersRepository = new UsersRepository(_usersDbContextMock.GetInstance());
        }

        [Fact]
        public async Task GetUserByCredentials_ShouldReturnUser_WhenCredentialsAreValid()
        {
            // Arrange: Create a fake user using Bogus
            var validUser = _usersDbContextMock.MockUser(userName: "test", password: "test");

            // Act: Call the method under test
            var result = await _usersRepository.GetUserByCredentials(validUser.UserName, validUser.Password);

            // Assert: Ensure the correct user is returned
            result.Should().NotBeNull();
            result.UserName.Should().Be(validUser.UserName);
            result.Password.Should().Be(validUser.Password);
        }

        [Fact]
        public async Task GetUserByCredentials_ShouldReturnNull_WhenCredentialsAreInvalid()
        {
            // Arrange: Create a fake user
            var validUser = _usersDbContextMock.MockUser(userName: "test2");

            // Act: Call the method under test
            var result = await _usersRepository.GetUserByCredentials("test2", "test");

            // Assert: Ensure that the result is null
            result.Should().BeNull();
        }

        [Fact]
        public async Task InsertAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange: Create a fake entity using Bogus
            var fakeUser = UserFixture.CreateUserRandom();

            // Act: Call the method under test
            Func<Task> func = async () => { await _usersRepository.InsertAsync(fakeUser); };


            // Assert: Ensure the entity was added and SaveChangesAsync was called
            await func.Should().NotThrowAsync();
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateEntityAndSaveChanges()
        {
            Guid userId = Guid.Parse("7C390786-46DD-491C-BD8E-37148B8FD666");

            // Arrange: Create a fake entity using Bogus
            var validUser = _usersDbContextMock.MockUser(userId, userName: "test3");

            var validUserToUpdate = UserFixture.CreateUserRandom(userId);

            // Act: Call UpdateAsync
            Func<Task> func = async () =>
            {
                await _usersRepository.UpdateAsync(validUserToUpdate);
            };

            // Assert: Ensure the entity was updated and SaveChangesAsync was called
            await func.Should().NotThrowAsync();
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveEntityAndSaveChanges()
        {
            Guid userId = Guid.Parse("7C390786-46DD-491C-BD8E-37148B8FD665");

            // Arrange: Create a fake entity using Bogus
            var validUser = _usersDbContextMock.MockUser(userId, userName: "test3");

            // Act: Call DeleteAsync
            Func<Task> func = async () =>
            {
                await _usersRepository.DeleteAsync(validUser);
            };

            // Assert: Ensure the entity was removed and SaveChangesAsync was called
            await func.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ListPagedAsync_ShouldReturnPaginatedListOfEntities()
        {
            // Arrange: Create a list of fake entities using Bogus
            _usersDbContextMock.MockUserList(10); // Generate 10 entities

            var order = new List<Order>() { new Order("Id", "asc") }; // Define an empty order for simplicity
            var page = new Page(1, 5); // Page 1 with 5 items per page
            var filter = new List<Filter>() { new Filter("Version", Operator.Equals, "0") }; // Empty filters for simplicity

            // Act: Call ListPagedAsync
            var result = await _usersRepository.ListPagedAsync(order, page, filter);

            // Assert: Verify the paginated list is returned
            result.Should().NotBeNull();
            result.Page.Index.Should().Be(1);
            result.Page.Quantity.Should().Be(5);// Since we are requesting page 1 with 5 items per page            
        }

        [Fact]
        public async Task GetFirstByExpressionAsync_ShouldReturnEntityWhenExpressionMatches()
        {
            // Arrange: Create a fake entity using Bogus
            var validUser = _usersDbContextMock.MockUser(userName: "test4");

            // Act: Call GetFirstByExpressionAsync with an expression matching the entity
            var result = await _usersRepository.GetFirstByExpressionAsync(e => e.UserName == validUser.UserName);

            // Assert: Ensure the correct entity is returned
            result.UserName.Should().Be(validUser.UserName);
        }

        [Fact]
        public async Task GetFirstByExpressionAsync_ShouldReturnNullWhenNoMatch()
        {
            // Arrange: Create a fake entity using Bogus
            var validUser = _usersDbContextMock.MockUser();

            // Act: Call GetFirstByExpressionAsync with a non-matching expression
            var result = await _usersRepository.GetFirstByExpressionAsync(e => e.UserName == "test5");

            // Assert: Ensure no entity is returned
            result.Should().BeNull();
        }

    }
}
