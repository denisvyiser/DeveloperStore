//using DevStore.Domain.ErrorHandler;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Domain.Test.ErrorHandler
//{
//    public class ErrorDetailsTest
//    {
//        [Fact]
//        public async Task ErrorDetails()
//        {
//            var errorDetail = new ErrorDetails(new ErrorResult() { Errors = new List<string>() {"error not found" }, Url = "/error" }, new Exception("Error"));

//            Assert.NotNull(errorDetail);
//        }
//    }
//}
