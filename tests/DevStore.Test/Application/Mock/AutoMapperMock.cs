//using AutoMapper;
//using DevStore.Application.Mappings;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DevStore.Test.Application.Mock
//{
//    public class AutoMapperMock
//    {
//        public IMapper Setup()
//        {
//            IMapper _mapper;

//            var configMap = new MapperConfiguration(config => {
//                config.AddProfile(new DomainToViewModelMappingProfile());
//                config.AddProfile(new ViewModelToCommandMappingProfile());
//                config.AddProfile(new CommandToDomainMappingProfile());
//            });

//            _mapper = configMap.CreateMapper();

//            return _mapper;
//        }
//    }
//}
