using AutoMapper;
using PomiaryEsp32.Data.Models;
using PomiaryEsp32.Dto;

namespace PomiaryEsp32.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MeasurementDTO, Measurement>();
            CreateMap<UserDto, User>();
        }
    }
}
