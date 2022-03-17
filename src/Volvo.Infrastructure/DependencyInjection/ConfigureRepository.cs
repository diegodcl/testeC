using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volvo.Domain.Interface;
using Volvo.EntityFramework.Context;
using Volvo.EntityFramework.Repository;

namespace Volvo.Infrastructure.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependencyService (IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof (IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<MyContext> (
                options => options.UseMySql("server=localhost; database=Volvo; user=diego; password=PHCfoco2019;",new MySqlServerVersion(new Version(8, 0, 28)))
            );
        }
    }
}