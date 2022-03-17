using Microsoft.EntityFrameworkCore;
using Volvo.Domain.Models;

namespace Volvo.EntityFramework.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base (options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     var connectionString= "server=localhost; database=Volvo; user=diego; password=PHCfoco2019;";
        //     var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        //     optionsBuilder.UseMySql(
        //         connectionString, 
        //         serverVersion
        //     );
        // }
    }
}