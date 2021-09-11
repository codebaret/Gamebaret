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
            string[] categoryNames = new string[]
            {
                "Simulation","Strategy","Shooter","Action","Adventure","Platformer","Puzzle","Tower Defense","Idle","Sandbox","RPG","Racing","Fighter"
            };
            string[] tagNames = new string[]
            {
                "Puzzle","Music","Upgrades","Isometric","Mouse","War","Flight","5 Minute","Arcade","Pixel","Funny","Escape","Fantasy",
                "Horror","Card","Sports","Space","Zombie","Alien","Science Fiction","Relaxing","Turn Based","Maze","Dungeon","Quiz","Challenging",
                "Survival","Dating","Text Based"
            };
            Tag[] tags = new Tag[tagNames.Length];
            for (int i = 0; i < tagNames.Length; i++) tags[i] = new Tag { Id = i+1, Name = tagNames[i] };
            Category[] categories = new Category[categoryNames.Length];
            for (int i = 0; i < categoryNames.Length; i++) categories[i] = new Category { Id = i+1, Name = categoryNames[i] };
            modelBuilder.Entity<Tag>()
              .HasData(tags);
            modelBuilder.Entity<Category>()
              .HasData(categories);
        }
    }
}