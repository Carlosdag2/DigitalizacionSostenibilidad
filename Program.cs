
using DigitalizacionSostenibilidad.Data;
using DigitalizacionSostenibilidad.Repositories;
using DigitalizacionSostenibilidad.Services;
using Microsoft.EntityFrameworkCore;

namespace DigitalizacionSostenibilidad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DigitalizacionContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IIndicadorRepository, IndicadorRepository>();
            builder.Services.AddScoped<IndicadorService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Dev", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("Dev");

            app.MapControllers();

            app.Run();
        }
    }
}
