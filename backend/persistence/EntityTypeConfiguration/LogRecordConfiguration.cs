using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfiguration
{
    internal class LogRecordConfiguration : IEntityTypeConfiguration<LogRecord>
    {
        public void Configure(EntityTypeBuilder<LogRecord> builder)
        {
            builder.HasKey(logRecord => logRecord.Guid);
            builder.HasIndex(logRecord => logRecord.Guid).IsUnique();
        }
    }
}
