using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class GameCategoryMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {

            builder.Entity<GameCategory>()
                .ToTable("GameCategories")
                .HasKey(x => x.Id);
        }
    }
}