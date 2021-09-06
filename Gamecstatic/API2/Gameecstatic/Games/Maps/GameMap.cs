using AutoMapper;
using Games.API.Models.Games;
using Games.API.Models.Users;
using Games.Data.Model;
using System.Linq;

namespace Games.Maps
{
    public class GameMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<Game, GameModel>();
            map.ForMember(x => x.UserName, x => x.MapFrom(u => u.User.Username));
            map.ForMember(x => x.Tags, x => x.MapFrom(u => u.Tags.Select(r => r.Tag.Name).ToArray()));
            map.ForMember(x => x.Categories, x => x.MapFrom(u => u.Categories.Select(r => r.Category.Name).ToArray()));

            var map2 = configuration.CreateMap<Game, GameMenuModel>();
            map2.ForMember(x => x.UserName, x => x.MapFrom(u => u.User.Username));
            map2.ForMember(x => x.Tags, x => x.MapFrom(u => u.Tags.Select(r => r.Tag.Name).ToArray()));
            map2.ForMember(x => x.Categories, x => x.MapFrom(u => u.Categories.Select(r => r.Category.Name).ToArray()));

        }
    }
}
