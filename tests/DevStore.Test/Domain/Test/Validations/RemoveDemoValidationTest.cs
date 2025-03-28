//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentValidation.TestHelper;
//using DevStore.Domain.Commands;
//using DevStore.Domain.Validations;
//using Xunit;

//namespace DevStore.Test.Domain.Test.Validations
//{
//    public class RemoveDemoValidationTest
//    {
//        [Fact]

//        public void AddDemoValidation()
//        {
//            var validation = new RemoveDemoValidation();

           
//            Assert.True(validation.TestValidate(new RemoveDemoCommand(Guid.NewGuid())).IsValid);
//        }
//    }
//}
