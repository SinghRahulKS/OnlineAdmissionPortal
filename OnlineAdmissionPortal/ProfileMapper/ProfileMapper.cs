using AutoMapper;
using Entity.User;
using OnlineAdmissionPortal.Models;

namespace OnlineAdmissionPortal.ProfileMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserModel, ApplicationUser>().ReverseMap();
        }
    }
}
