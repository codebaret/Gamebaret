using Games.Data.Access.Maps.Common;
using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.Maps.Main
{
    public class AdditionalGameFileMap : IMap
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<AdditionalGameFile>()
                .ToTable("AdditionalGameFiles")
                .HasKey(x => x.Id);
        }
    }
}
