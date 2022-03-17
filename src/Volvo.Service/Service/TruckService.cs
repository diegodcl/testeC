using Volvo.Domain.Interface;
using Volvo.Domain.Interface.Service;
using Volvo.Domain.Models;

namespace Volvo.Service.Service
{
    public class TruckService : ITruckService
    {
        private IRepository<Truck> _repository;

        public TruckService(IRepository<Truck> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Truck> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Truck>> Get()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Truck> Post(TruckDto truck)
        {
            string year = DateTime.Now.Year.ToString();
            if (this.validateDate(truck.Manufactured) && this.validateModel(truck.Model)!=null && truck.YearModel == year) 
            {
                Truck newTruck = new Truck();
                newTruck.SerialNumber = truck.SerialNumber;
                newTruck.Manufactured = DateTime.ParseExact(truck.Manufactured, "dd/MM/yyyy", null);
                newTruck.Model = truck.Model;
                return await _repository.CreateAsync(newTruck);
            }else{
                return null;
            }
        }

        public async Task<Truck> Put(TruckDto truck)
        {
            if (this.validateDate(truck.Manufactured) && this.validateModel(truck.Model)!=null)
            {
                Truck newTruck = new Truck();
                newTruck.Id = truck.Id;
                newTruck.SerialNumber = truck.SerialNumber;
                newTruck.Manufactured = DateTime.ParseExact(truck.Manufactured, "dd/MM/yyyy", null);
                newTruck.Model = truck.Model;
                return await _repository.UpdateAsync(newTruck);
            }else{
                return null;
            }
        }

        public bool validateDate(string date) 
        {   
                try
                {
                    DateTime.ParseExact(date, "dd/MM/yyyy", null);
                    return true;
                }
                catch (Exception exception)
                {
                    return false;
                }
        }

        public string validateModel(string model)
        {
            if ((model=="FM" || model=="FH"))
            {
                return model;
            }else{
                return null;
            }
        }
    }
}