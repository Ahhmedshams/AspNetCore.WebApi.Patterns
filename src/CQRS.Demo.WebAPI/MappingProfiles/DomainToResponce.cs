using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.WebAPI.MappingProfiles
{
    public class DomainToResponce:Profile
    {
        public DomainToResponce()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.RaceWins));

            CreateMap<Driver, GetDriverResponse>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}" ));



        }
    }
}
