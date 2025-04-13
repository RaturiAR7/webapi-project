using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IFastTagVehicleRepository
    {
        IEnumerable<FastTagVehicle> GetAll();
        FastTagVehicle GetById(string regNumber);
        void Insert(FastTagVehicle vehicle);
        void Update(FastTagVehicle vehicle);
        void Delete(FastTagVehicle vehicle);
        void Save();
    }
}