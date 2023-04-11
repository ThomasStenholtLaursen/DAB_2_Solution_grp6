using AutoMapper;
using DAB_2_Solution_grp6.Api.Controllers.CanteenApp.Response.Query7;
using DAB_2_Solution_grp6.DataAccess.Entities;

namespace DAB_2_Solution_grp6.Api.MapperProfiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, StaffResponse>();
        }
    }
}
