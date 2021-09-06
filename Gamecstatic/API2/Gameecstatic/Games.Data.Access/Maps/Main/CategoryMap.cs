using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class CategoryMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .ToTable("Categories")
                .HasKey(x => x.Id);
        }
    }
}
