using AutoMapper;
using Core.Entities;
using Web.Models.Company;
using Web.Models.User;

namespace Web.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserModel>();
            CreateMap<CreateUserModel, User>();
            CreateMap<UpdateUserModel, User>();

            CreateMap<Company, CompanyModel>();
            CreateMap<CreateCompanyModel, Company>();
            CreateMap<UpdateCompanyModel, Company>();
        }
    }
}
