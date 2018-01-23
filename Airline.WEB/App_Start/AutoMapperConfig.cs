using Airline.BLL.Util;
using Airline.WEB.Util;
using AutoMapper;

namespace Airline.WEB
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new BllMappingProfile());
                cfg.AddProfile(new WebMappingProfile());
            });
        }
    }
}