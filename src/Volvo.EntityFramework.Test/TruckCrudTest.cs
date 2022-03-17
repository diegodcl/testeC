using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volvo.Domain.Models;
using Volvo.EntityFramework.Context;
using Volvo.EntityFramework.Repository;
using Xunit;

namespace Volvo.EntityFramework.Test
{
    public class TruckCrudTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public TruckCrudTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }
        [Fact(DisplayName = "Truck Crud")]
        [Trait("CRUD", "Truck")]
        public async Task Truck_Test_Crud()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                BaseRepository<Truck> _repositorio = new BaseRepository<Truck>(context);
                Truck model = new Truck
                {
                    SerialNumber = "POL123NASDSBE",
                    Model = "FM",
                    YearModel = 2022,
                    Manufactured= new DateTime(2022, 01, 12)
                };

                var _newEntry = await _repositorio.CreateAsync(model);
                Assert.NotNull(_newEntry);
                Assert.Equal("POL123NASDSBE",model.SerialNumber);
                Assert.False(model.Id == Guid.Empty);
            }
        }
    }
}