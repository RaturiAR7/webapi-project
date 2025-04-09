using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        [HttpPost("create")]
        public IActionResult CreateVehicle([FromBody] FastTagVehicle fastTagVehicle)
        {
            _context.FastTagVehicles.Add(fastTagVehicle);
            _context.SaveChanges();
            return Ok("Vehicle created successfully");
        }
        [HttpGet("validate")]
        public IActionResult FastTagValid([FromQuery] string reg_number)
        {
            var vehicle = _context.FastTagVehicles.FirstOrDefault(v => v.RegNumber == reg_number);
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
        [HttpGet("balance")]
        public IActionResult GetBalance([FromQuery] string reg_number)
        {
            var vehicle = _context.FastTagVehicles.FirstOrDefault(v => v.RegNumber == reg_number);
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

    [HttpPut("deduct")]
    public IActionResult DeductBalance([FromQuery] string RegNumber, [FromBody] int Amount)
    {
        var vehicle = _context.FastTagVehicles.FirstOrDefault(v => v.RegNumber == RegNumber);
        if (vehicle == null)
        {
            return NotFound("Vehicle not found");
        }

        if (vehicle.Balance - Amount < 0)
        {
            return BadRequest("Insufficient balance");
        }

        vehicle.Balance -= Amount;
        _context.FastTagVehicles.Update(vehicle);
        _context.SaveChanges();

        return Ok($"Remaining Balance: {vehicle.Balance}");
    }
    }
}