using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ecommerceAPI.Domain;
using ecommerceAPI.Domain.Entities;

namespace ecommerceAPI.Domain
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDBContext>();

            optionsBuilder.UseSqlServer("Server=DESKTOP-LVA4E65\\MSSQLSERVER01;Database=EcommerceApi;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MyDBContext(optionsBuilder.Options);
        }
    }
}