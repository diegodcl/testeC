using Microsoft.Extensions.DependencyInjection;
using Volvo.Domain.Interface.Service;
using Volvo.Service.Service;

namespace Volvo.Infrastructure.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependencyService (IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITruckService, TruckService>();
        }
    }
}