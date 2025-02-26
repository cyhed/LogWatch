using Application.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Data;
namespace WebApi
{
    public class Program
    {   
        
    
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddSingleton<LogsContextProvider, LogsContextProvider>();
            builder.Services.AddSingleton<IDbConnectionStorage, DbConnnectionStorage>();

            builder.Services.AddControllers();

            var app = builder.Build();


            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });

            app.Run();
        }
    }
}
