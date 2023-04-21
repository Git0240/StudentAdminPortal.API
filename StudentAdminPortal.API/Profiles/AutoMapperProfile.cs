using AutoMapper;
using StudentAdminPortal.API.DataModels;
using DataModels = StudentAdminPortal.API.DomainModels;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, DataModels.Student>();
            CreateMap<Gender, DataModels.Gender>().ReverseMap();
            CreateMap<Address, DataModels.Address>().ReverseMap();
        }
    }
}
