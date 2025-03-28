using Castle.Components.DictionaryAdapter.Xml;
using DevStore.Test.Users.Fixtures;
using DevStore.Users.Domain.Interfaces.Repositories;
using DevStore.Users.Domain.Models.Entities;
using DevStore.Users.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Test.Users.Infrastructure.Mocks
{
    public class UsersDbContextMock
    {
        private readonly UsersDbContext _context;
        public UsersDbContextMock()
        {

            _context = Setup();
        }

        public UsersDbContext GetInstance() => _context;
        private UsersDbContext Setup()
        {
            var options = new DbContextOptionsBuilder<UsersDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            return new UsersDbContext(options);
        }

        public User MockUser(Guid id = default, string userName = default, string password = default)
        {
            var fakeUser = UserFixture.CreateUserRandom(id, userName, password);


            _context.AddRange(fakeUser);
            _context.SaveChanges();
            _context.Entry(fakeUser).State = EntityState.Detached;

            return fakeUser;
        }

        public void MockUserList(int qty)
        {
            _context.AddRange(UserFixture.CreateUserList(qty));
            _context.SaveChanges();
        }

    }
}
