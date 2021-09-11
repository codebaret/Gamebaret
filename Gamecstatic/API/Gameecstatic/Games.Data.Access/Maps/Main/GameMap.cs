using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class GameMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Game>()
                .ToTable("Games")
                .HasKey(x => x.Id);
        }
    }
}
