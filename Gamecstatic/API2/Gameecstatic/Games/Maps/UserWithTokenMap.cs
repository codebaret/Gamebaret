using AutoMapper;
using Games.API.Models.Users;
using Games.Data.Model;
using Games.Queries.Models;

namespace Games.Maps
{
    public class UserWithTokenMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<UserWithToken, UserWithTokenModel>();
        }
    }
}
