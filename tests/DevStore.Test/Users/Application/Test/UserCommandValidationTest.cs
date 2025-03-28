using Bogus;
using DevStore.Core.Models.ValueObjects;
using DevStore.Users.Application.Commands;
using DevStore.Users.Application.Validations;
using DevStore.Users.Domain.Models.Enums;
using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevStore.Test.Users.Application.Test
{
    public class UserCommandValidationTests
    {
        private readonly Faker fake;

        public UserCommandValidationTests()
        {
            fake = new Faker("pt_BR");
        }

        [Fact]
        public void Should_Fail_If_Email_Is_Null_Or_Empty()
        {
            // Arrange
           

            var commandFake = new AddUserCommand(null,
                fake.Person.UserName,
                fake.Person.Random.AlphaNumeric(8),
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


            UserCommandValidation<AddUserCommand> _validation = new UserCommandValidation<AddUserCommand>();

            // Act
            var result = _validation.TestValidate(commandFake);

            //Assert

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Fail_If_UserName_Is_Null_Or_Empty()
        {
            // Arrange
            var commandFake = new UpdateUserCommand(Guid.NewGuid(),fake.Person.Email,
             null,
             fake.Person.Random.AlphaNumeric(8),
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

            UserCommandValidation<UpdateUserCommand> _validation = new UserCommandValidation<UpdateUserCommand>();

            // Act
            var result = _validation.TestValidate(commandFake);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public void Should_Fail_If_Name_Is_Invalid()
        {
            // Arrange
            var commandFake = new AddUserCommand(fake.Person.Email,
             fake.Person.UserName,
             fake.Person.Random.AlphaNumeric(8),
             new Name("",""),
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

            UserCommandValidation<AddUserCommand> _validation = new UserCommandValidation<AddUserCommand>();

            // Act
            var result = _validation.TestValidate(commandFake);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Fail_If_Address_Is_Invalid()
        {
            //arrange
            var commandFake = new UpdateUserCommand(Guid.NewGuid(),fake.Person.Email,
              fake.Person.UserName,
              fake.Person.Random.AlphaNumeric(8),
              new Name(fake.Person.FirstName, fake.Person.LastName),
              new Address("","","",""),
              fake.Person.Phone,
              (Status)fake.Random.Int(0, 2),
              (Role)fake.Random.Int(0, 2)
              );

            UserCommandValidation<UpdateUserCommand> _validation = new UserCommandValidation<UpdateUserCommand>();

            // Act
            var result = _validation.TestValidate(commandFake);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Address);
        }

        [Fact]
        public void Should_Pass_When_All_Fields_Are_Valid()
        {
            //arrange
            var commandFake = new RemoveUserCommand(Guid.NewGuid());


            // Act
            var result = commandFake.IsValid();

            //Assert
            result.Should().BeTrue();
        }
              
    }
}
