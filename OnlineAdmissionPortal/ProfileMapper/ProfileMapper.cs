using AutoMapper;
using Entity.Institute;
using Entity.Student;
using Entity.User;
using OnlineAdmissionPortal.Models;

namespace OnlineAdmissionPortal.ProfileMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<StudentModel, StudentInfo>().ReverseMap();
            CreateMap<InstituteModel, Institute>().ReverseMap();
        }
    }
}
