using Microsoft.EntityFrameworkCore;
using Application.Interface;
using Domain;
using Persistence.EntityTypeConfiguration;
namespace Persistence
{
    public class LogsDbContext : DbContext, ILogRecordsDbContext, IStatusCodeDbContext, IAreaDbContext
    {
        public DbSet<LogRecord> Logs { get; set; }
        public DbSet<StatusCode> LogsStatusCodes { get; set; }
        public DbSet<Area> AreaNumbers { get; set; }
        public LogsDbContext(DbContextOptions<LogsDbContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogRecordConfiguration());
            modelBuilder.ApplyConfiguration(new StatusCodeConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
