using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TicketStatusAPI.Data;
using Microsoft.OpenApi.Models;


namespace TicketStatusAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            // Add the database context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddControllers();

            // Add swagger docs and UI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Ticket Status API", 
                    Version = "v1",
                    Description = "Returns description for a TicketID using the Lookup table"
                });
            });

            var app = builder.Build();

            // Show Swagger UI when running in development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Status API v1");
                    c.RoutePrefix = string.Empty; // load swagger
                });
            }

            app.MapControllers(); 

            app.Run();
        }
    }

}
