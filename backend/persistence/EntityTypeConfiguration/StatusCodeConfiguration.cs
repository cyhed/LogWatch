using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfiguration
{
    internal class StatusCodeConfiguration : IEntityTypeConfiguration<StatusCode>
    {
        public void Configure(EntityTypeBuilder<StatusCode> builder)
        {
            builder.HasKey(record => record.Status);
            builder.HasIndex(record => record.Status).IsUnique();
        }
    }
}
