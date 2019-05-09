using AutoMapper;

namespace UsersApi.Infra.Mapping
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                UserMapping.InitMap(cfg);
            });
        }
    }
}
