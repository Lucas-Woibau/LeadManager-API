using LeadManager.Application.Services;
using LeadManager.Infrastructure.Persistance;
using LeadManager.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LeadManager
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<LeadManagerDbContext>(
                options => options.UseSqlServer(connString));

            builder.Services.AddScoped<ILeadService, LeadService>();
            builder.Services.AddSingleton<IEmailService, EmailService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy => policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAngular");

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LeadManagerDbContext>();
                await dbContext.Database.MigrateAsync();

                await LeadManagerDbContextSeed.SeedAsync(dbContext);
            }

            app.Run();
        }
    }
}
