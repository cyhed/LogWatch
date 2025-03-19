using Microsoft.EntityFrameworkCore;
using Application.Interface;
using Domain;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace Persistence
{
    public class LogsContextProvider : IContextProvider<LogsDbContext>
    {
        public LogsDbContext GetContext(DbConnection connection)
        {
            string srtConnection = $"Server={connection.Server},{connection.Port};Database={connection.Database};Uid={connection.Username};Pwd={connection.Password}; TrustServerCertificate=True";
            var optionsBuilder = new DbContextOptionsBuilder<LogsDbContext>()
                .UseSqlServer(srtConnection)
                .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
            
            return new LogsDbContext(optionsBuilder.Options);
        }
    }
}
