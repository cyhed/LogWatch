using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace WebApi
{
    public class Program
    {   
        
    
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");

            // добавляем контекст ApplicationContext в качестве сервиса в приложение
            builder.Services.AddDbContext<LogsDbContext>(options => options.UseSqlServer(connection));

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
