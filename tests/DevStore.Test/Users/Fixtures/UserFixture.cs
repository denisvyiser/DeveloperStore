using Bogus;
using DevStore.Core.Helpers.Repository;
using DevStore.Core.Models.ValueObjects;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Views;
using DevStore.Users.Domain.Models.Entities;
using DevStore.Users.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Test.Users.Fixtures
{
    public class UserFixture
    {
        public static User CreateUserRandom(Guid id = default, string userName = default, string password = default)
        {

            var fake = new Faker("pt_BR");

            var userFake = new User(
                id == Guid.Empty ? fake.Person.Random.Guid() : id,
                fake.Person.Email,
                userName == null || userName == string.Empty ? fake.Person.UserName : userName,
                password == null || password == string.Empty ? fake.Person.Random.AlphaNumeric(8) : password,
                fake.Person.Phone,
                (Status)fake.Random.Int(0, 2),
                (Role)fake.Random.Int(0, 2));

            userFake.Address = new Address(fake.Address.City(),
                fake.Address.StreetName(), fake.Address.Random.Number(999).ToString(),
                fake.Address.ZipCode("#####-###"))
            {
                Geolocation = new Geolocation { Latitude = fake.Address.Latitude(0, 50), Longitude = fake.Address.Longitude(0, 99) }
            };

            userFake.Name = new Name(fake.Person.FirstName, fake.Person.LastName);

            return userFake;
        }

        public static List<User> CreateUserList(int qty)
        {
            List<User> users = new List<User>();
            for (int i = 1; i <= qty; i++)
                users.Add(CreateUserRandom());

            return users;
        }


        public static UserView MapEntityToView(User user)
        {

            return new UserView {
                Id = user.Id,
            Address = user.Address,
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            Phone = user.Phone,
            Role = user.Role,
            Status = user.Status,
            UserName = user.UserName
            };
        }

        public static List<UserView> MapEntityListToViewList(List<User> users)
        {
          
            return users.Select(c=> new UserView { 
            Id = c.Id,
            Address = c.Address,
            Email = c.Email,
            Name = c.Name,
            Password = c.Password,
            Phone = c.Phone,
            Role = c.Role,
            Status = c.Status,
            UserName = c.UserName            
            }).ToList();
        }

        public static AddUserCommand CreateAddCommandRandom(string userName = default, string password = default)
        {
            var fake = new Faker("pt_BR");

            var userFake = new AddUserCommand(fake.Person.Email,
                userName == null || userName == string.Empty ? fake.Person.UserName : userName,
                password == null || password == string.Empty ? fake.Person.Random.AlphaNumeric(8) : password,
                new Name(fake.Person.FirstName, fake.Person.LastName),
                new Address(fake.Address.City(),
                fake.Address.StreetName(), fake.Address.Random.Number(999).ToString(),
                fake.Address.ZipCode("#####-###"))
                {
                    Geolocation = new Geolocation { Latitude = fake.Address.Latitude(0, 50), Longitude = fake.Address.Longitude(0, 99) }
                },
                fake.Person.Phone,
                (Status)fake.Random.Int(0, 2),
                (Role)fake.Random.Int(0, 2)
                );

            return userFake;
        }

        public static UpdateUserCommand CreateUpdateCommandRandom(Guid id = default, string userName = default, string password = default)
        {
            var fake = new Faker("pt_BR");

            var userFake = new UpdateUserCommand(id, fake.Person.Email,
                userName == null || userName == string.Empty ? fake.Person.UserName : userName,
                password == null || password == string.Empty ? fake.Person.Random.AlphaNumeric(8) : password,
                new Name(fake.Person.FirstName, fake.Person.LastName),
                new Address(fake.Address.City(),
                fake.Address.StreetName(), fake.Address.Random.Number(999).ToString(),
                fake.Address.ZipCode("#####-###"))
                {
                    Geolocation = new Geolocation { Latitude = fake.Address.Latitude(0, 50), Longitude = fake.Address.Longitude(0, 99) }
                },
                fake.Person.Phone,
                (Status)fake.Random.Int(0, 2),
                (Role)fake.Random.Int(0, 2)
                );

            return userFake;
        }
    }
}

