using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class GameTagMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<GameTag>()
                .ToTable("GameTags")
                .HasKey(x => x.Id);
        }
    }
}
