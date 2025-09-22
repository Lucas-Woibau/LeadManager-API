using LeadManager.Application.Services;
using LeadManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LeadManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LeadManagerDbContext>(
                options => options.UseInMemoryDatabase("Default"));

            builder.Services.AddScoped<ILeadService, LeadService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
