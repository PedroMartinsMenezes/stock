using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stock.Domain;
using Stock.Repository;
using Stock.Repository.Data.Seed;

namespace Stock.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Controllers
            builder.Services.AddControllers();

            //Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Bootstrap
            builder.Services.RegisterStockRepository(builder.Configuration);
            builder.Services.RegisterStockDomain();

            //App
            var app = builder.Build();

            #region Seed Data
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            SeedProduto.Initialize(services);
            #endregion

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
