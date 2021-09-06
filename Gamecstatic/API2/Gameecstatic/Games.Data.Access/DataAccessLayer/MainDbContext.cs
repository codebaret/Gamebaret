using Games.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Games.Data.Access.DataAccessLayer
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mappings = MappingsHelper.GetMainMappings();

            foreach (var mapping in mappings)
            {
                mapping.Visit(modelBuilder);
            }
            modelBuilder.Entity<Tag>()
              .HasData(
               new Tag { Id = 1, Name = "Strategy" });
        }
    }
}