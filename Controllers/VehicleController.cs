using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController:ControllerBase
    {
        private readonly IFastTagVehicleRepository _vehicleRepository;
        public VehicleController(IFastTagVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet("all")]
        public IActionResult GetAllVehicles()
        {
            var vehciles=_vehicleRepository.GetAll();
            return Ok(vehciles);
        }

        [HttpPost("create")]
        public IActionResult CreateVehicle([FromBody] FastTagVehicle fastTagVehicle)
        {
            _vehicleRepository.Insert(fastTagVehicle);
            _vehicleRepository.Save();
            return Ok("Vehicle created successfully");
        }
        [HttpGet("validate")]
        public IActionResult FastTagValid([FromQuery] string reg_number)
        {
            var vehicle=_vehicleRepository.GetById(reg_number);
            return Ok(vehicle);
        }
        [HttpGet("balance")]
        public IActionResult GetBalance([FromQuery] string reg_number)
        {
            var vehicle=_vehicleRepository.GetById(reg_number);
            return Ok(vehicle.Balance);
        }

    [HttpPut("deduct")]
    public IActionResult DeductBalance([FromQuery] string RegNumber, [FromBody] int Amount)
    {
        var vehicle = _vehicleRepository.GetById(RegNumber);
        if (vehicle == null)
        {
            return NotFound("Vehicle not found");
        }
        if (vehicle.Balance < Amount)
        {
            return BadRequest("Insufficient balance");
        }
        vehicle.Balance -= Amount;
        _vehicleRepository.Update(vehicle);
        _vehicleRepository.Save();
        return Ok($"Remaining Balance: {vehicle.Balance}");
    }
    }
}