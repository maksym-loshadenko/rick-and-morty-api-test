using UpSwot.Business.Services;
using UpSwot.Business.Services.Interfaces;
using UpSwot.Data.ExternalApis;
using UpSwot.Data.ExternalApis.Interfaces;

namespace UpSwot.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddMemoryCache();

            builder.Services.AddSingleton<IRickAndMortyApi, RickAndMortyApi>();
            builder.Services.AddSingleton<IRickAndMortyService, RickAndMortyService>();
            builder.Services.AddSingleton<IRickAndMortyCacheService, RickAndMortyCacheService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}