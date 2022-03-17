using Volvo.Domain.Models;

namespace Volvo.Domain.Interface.Service
{
    public interface ITruckService
    {
         Task<Truck> Get(Guid id);
         Task<IEnumerable<Truck>> Get();
         Task<Truck> Post(TruckDto truck);
         Task<Truck> Put(TruckDto truck);
         Task<bool> Delete(Guid id);
    }
}