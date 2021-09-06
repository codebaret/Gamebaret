using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class TagMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Tag>()
                .ToTable("Tags")
                .HasKey(x => x.Id);
        }
    }
}
