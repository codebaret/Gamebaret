using Gamecstatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamecstatic.Context
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalFile>()
                .HasKey(c => new { c.Id, c.GetPath });
        }
        public DbSet<AdditionalFile> AdditionalFile { get; set; }
    }
}
