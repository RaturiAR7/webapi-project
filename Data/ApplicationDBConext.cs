using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ApplicationDBConext:DbContext
    {
        public ApplicationDBConext(DbContextOptions dbContextOptions):base()
        {
            
        }
        public DbSet<FastTagVehicle> FastTagVehicles {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var vehicle1=new FastTagVehicle(){
                Id=1,
                RegNumber="KA-01-AB-1234",
                FastTagSerial=1234567890,
                Balance=1000,
                CreatedAt=DateTime.Now
            };
            modelBuilder.Entity<FastTagVehicle>().HasData(vehicle1);
        }
    }
}