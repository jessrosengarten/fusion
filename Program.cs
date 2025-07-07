using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TicketStatusAPI.Data;

namespace TicketStatusAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            var app = builder.Build();
            app.MapControllers(); // Maps the controllers to the app

            app.Run();
        }
    }

}
