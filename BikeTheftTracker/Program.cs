using System.Text.Json.Serialization;
using Application.Interfaces;
using Application.Services;
using BikeTheftTracker.API.Extensions;
using Infrastructure.Core.Services;

namespace BikeTheftTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            builder.Services.ConfigureBikeIndexApiOptions(builder.Configuration);
            builder.Services.ConfigureInfrastructureServices();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient<IBikeIndexApiClient, BikeIndexApiClient>();
            builder.Services.AddScoped<IBikesService, BikesService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.ConfigureGlobalExceptionHandler();

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}