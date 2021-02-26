using MediKeeper.Domain;
using MediKeeper.Persistence.Items.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace MediKeeper.Persistence
{
    public class MediKeeperDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        
        public MediKeeperDbContext(DbContextOptions<MediKeeperDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemConfig());
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() }));
        }

    }
}
