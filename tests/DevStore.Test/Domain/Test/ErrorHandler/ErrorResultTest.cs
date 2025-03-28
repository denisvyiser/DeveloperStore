//using DevStore.Domain.Core.Extensions;
//using DevStore.Domain.ErrorHandler;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Domain.Test.ErrorHandler
//{
//    public class ErrorResultTest
//    {
//        [Fact]
//        public async Task ErrorResult()
//        {
//            var errorResult = new ErrorResult() {Id = Guid.NewGuid(), Errors = new List<string>() { "error not found" }, Url = "/error", CreatedAt = DateTime.Now.ToBrazilianTimezone() };

            
//            Assert.NotNull(errorResult.ToString());
//        }
//    }
//}
