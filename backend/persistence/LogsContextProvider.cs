using Microsoft.EntityFrameworkCore;
using Application.Interface;
using Domain;

namespace Persistence
{
    public class LogsContextProvider : IContextProvider<LogsDbContext>
    {
        public LogsDbContext GetContext(DbConnection connection)
        {
            string srtConnection = $"Server={connection.Server},{connection.Port};Database={connection.Database};Uid={connection.Username};Pwd={connection.Password}; TrustServerCertificate=True";
            var optionsBuilder = new DbContextOptionsBuilder<LogsDbContext>()
                .UseSqlServer(srtConnection).Options;
            return new LogsDbContext(optionsBuilder);
        }
    }
}
