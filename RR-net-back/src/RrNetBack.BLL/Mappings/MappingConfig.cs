using AutoMapper;
using RrNetBack.BLL.Mappings.Profiles;

namespace RrNetBack.BLL.Mappings
{
    public class MappingConfig
    {
        private static readonly MapperConfiguration Config = new MapperConfiguration(config =>
        {
            config.AddProfile<UserMapperProfile>();
        });

        public static IMapper GetMapper()
        {
            Config.AssertConfigurationIsValid();
            return Config.CreateMapper();
        }
    }
}