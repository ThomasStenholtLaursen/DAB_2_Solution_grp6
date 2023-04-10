using AutoMapper;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response;
using DAB_2_Solution_grp6.DataAccess.Entities;

namespace DAB_2_Solution_grp6.Api.MapperProfiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, DailyMenuResponse>()
                .ForMember(x => x.Warm, opt => opt.MapFrom(src => src.WarmDishName))
                .ForMember(x => x.Street, opt => opt.MapFrom(src => src.StreetFoodName));
        }
    }
}
