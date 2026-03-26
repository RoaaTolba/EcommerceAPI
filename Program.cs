
using ecommerceAPI.Infrastructure;
using ecommerceAPI.Infrastructure.Data;
//using ecommerceAPI.Domain;
using ecommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ecommerceAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1?? ??? DbContext ???? connection string ?? appsettings.json
            //builder.Services.AddDbContext<MyDBContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            //);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = service.GetRequiredService<UserManager<User>>();

                await SeedData.intialize(roleManager, userManager);
            }

            // Configure the HTTP request pipeline.  
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
