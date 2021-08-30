using Gamecstatic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gamecstatic.Contexts
{
    public class GameIndexFileContext : DbContext
    {
        public GameIndexFileContext(DbContextOptions<GameIndexFileContext> options) : base(options)
        {

        }
        public DbSet<GameIndexFile> GameIndexFile { get; set; }
    }
}
