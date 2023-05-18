using AutoMapper;
using WishListWebAPI.DTO;
using WishListWebAPI.Model;


namespace WishListWebAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        // SignupDTO = ApplicationUser
        public AutoMapperConfig()
        {
            CreateMap<ApplicationUser, SignUpDTO>().ReverseMap()
            .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));
           
        }
    }
}
