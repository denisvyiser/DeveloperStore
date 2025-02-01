using AutoMapper;
using DevStore.Sales.Application.Commands;
using DevStore.Sales.Domain.Moldes.Entities;

namespace DevStore.Sales.Application.MappingProfiles
{
    public class CommandToDomainMappingProfile
         : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AddSaleCommand, Sale>();
            CreateMap<UpdateSaleCommand, Sale>();
            CreateMap<SaleProductCommand, SaleProduct>();

        }
    }
}
