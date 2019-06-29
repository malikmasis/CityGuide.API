using System.Linq;
using AutoMapper;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                 {
                     opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                 })
                .ForMember(dest => dest.DateAdded, opt =>
                 {
                     opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).DateAdded.ToString("dddd, dd MMMM yyyy"));
                 })
                ;

            CreateMap<City, CityForDetailDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<PhotoForReturnDto, Photo>(); 

            CreateMap<User, UserForRegisterDto>(); 
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
