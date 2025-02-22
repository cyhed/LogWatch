using Microsoft.EntityFrameworkCore;
using Domain;
namespace Application.Interface
{
    public interface ILogRecordsDbContext
    {
        DbSet<LogRecord> Logs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
