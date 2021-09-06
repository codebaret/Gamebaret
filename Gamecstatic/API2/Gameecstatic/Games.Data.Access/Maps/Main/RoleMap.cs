using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class RoleMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .ToTable("Roles")
                .HasKey(x => x.Id);
        }
    }
}
