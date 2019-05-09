using AutoMapper;
using UsersApi.Data.Model;
using UsersApi.ViewModels;

namespace UsersApi.Infra.Mapping
{
    public class UserMapping
    {
        internal static void InitMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ApplicationUser, UserProfileViewModel>().ReverseMap();
            cfg.CreateMap<ApplicationUser, AddOrUpdateUserViewModel>().ReverseMap();
        }
    }
}
