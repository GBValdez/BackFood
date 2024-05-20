using AutoMapper;
using Nuevo.modules.foods;
using Nuevo.modules.orders.dto;
using project.modules.foods;
using project.modules.orders.models;
using project.roles;
using project.roles.dto;
using project.users;
using project.users.dto;

namespace project.utils.autoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<userEntity, userDto>()
            .ForMember(userDtoId => userDtoId.isActive, options => options.MapFrom(src => src.deleteAt == null));
            ;

            CreateMap<rolEntity, rolDto>();
            CreateMap<rolCreationDto, rolEntity>();

            //Extras
            CreateMap<Food, foodDto>();
            CreateMap<foodDto, Food>();

            CreateMap<orderDto, Order>();
            CreateMap<orderItemCreationDto, orderItem>();
        }

    }
}