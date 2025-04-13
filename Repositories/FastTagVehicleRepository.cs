using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;

namespace Repositories
{
    public class FastTagVehicleRepository : IFastTagVehicleRepository
    {
        private readonly ApplicationDBConext _context;
        public FastTagVehicleRepository(ApplicationDBConext conext)
        {
            _context = conext;
        }
        public IEnumerable<FastTagVehicle> GetAll()
        {
            return _context.FastTagVehicles.ToList();
        }
        public FastTagVehicle GetById(string id)
        {
            var vehicle = _context.FastTagVehicles.FirstOrDefault(v => v.RegNumber == id);
            if(vehicle==null)
            {
                throw new Exception("vehicle not found");
            }
            return vehicle;
        }

        public void Insert(FastTagVehicle fastTagVehicle)
        {
            _context.FastTagVehicles.Add(fastTagVehicle);
        }

        public void Update(FastTagVehicle fastTagVehicle)
        {
            var vehicle = _context.FastTagVehicles.FirstOrDefault(v => v.RegNumber == fastTagVehicle.RegNumber);
            if(vehicle!=null)
            {
                vehicle.Balance=fastTagVehicle.Balance;
                vehicle.RegNumber=fastTagVehicle.RegNumber;
            }
            else
            {
                throw new Exception("vehicle not found");
            }
        }

        public void Delete(FastTagVehicle fastTagVehicle)
        {
            // Implementation for deleting a FastTagVehicle
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}