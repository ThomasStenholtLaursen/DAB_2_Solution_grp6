using AutoMapper;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query4;
using DAB_2_Solution_grp6.DataAccess.Entities;

namespace DAB_2_Solution_grp6.Api.MapperProfiles
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, SimpleMeal>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.MealName));
        }
    }
}
