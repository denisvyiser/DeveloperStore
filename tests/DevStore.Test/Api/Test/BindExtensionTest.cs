//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using DevStore.Api.Configurations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace DevStore.Test.Api.Test
//{
//    public class BindExtensionTest
//    {
//        private readonly IServiceCollection _serviceCollection;
//        private readonly IConfiguration _configuration;
//        public BindExtensionTest()
//        {
//            _serviceCollection = new ServiceCollection();
//            var inMemorySettings = new Dictionary<string, string> {
//            //{"TopLevelKey", "TopLevelValue"},
//            {"FakeConfig:BaseUrl", "http://localhost"}
//            };

//            _configuration = new ConfigurationBuilder()
//                .AddInMemoryCollection(inMemorySettings)
//                .Build();

//        }

//        [Fact]
//        public async Task RegisterConfiguration()
//        {
//            var result = _serviceCollection.RegisterConfiguration<FakeConfig>(_configuration, "FakeConfig");

//            var serviceProvider = _serviceCollection.BuildServiceProvider();

//            var service = serviceProvider.GetService<FakeConfig>();

//            Assert.NotNull(service);
//        }
//    }
//}
