using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController:ControllerBase
    {
        private readonly ApplicationDBConext _context;
        public VehicleController(ApplicationDBConext context)
        {
            _context=context;
        }
        [HttpGet]
        public IActionResult FastTagValid([FromBody] string reg_number)
        {
            var vehicle=_context.FastTagVehicles.Find(reg_number);
            if(vehicle==null)
            {
                var result = NotFound("vehicle not found");
                result.StatusCode = 404;
                return result;
            }
            var output=Ok(vehicle);
            output.StatusCode=200;
            return output;
        }
        [HttpGet]
        public IActionResult GetBalance([FromBody] string reg_number)
        {
            var vehicle=_context.FastTagVehicles.Find(reg_number);
            if(vehicle==null)
            {
                var result = NotFound("vehicle not found");
                result.StatusCode = 404;
                return result;
            }
            var output=Ok(vehicle.Balance);
            output.StatusCode=200;
            return output;
        }
        [HttpPut]
        public IActionResult DeductBalance([FromBody] string reg_number)
        {
            var vehicle=_context.FastTagVehicles.Find(reg_number);
            if(vehicle==null)
            {
                var result = NotFound("vehicle not found");
                result.StatusCode = 404;
                return result;
            }
            vehicle.Balance-=100;
            if(vehicle.Balance<0)
            {
                var result = BadRequest("Insufficient balance");
                result.StatusCode = 400;
                return result;
            }
            _context.FastTagVehicles.Update(vehicle);
            _context.SaveChanges();
            return Ok("Remaining Balance:"+vehicle.Balance);
        }
    }
}