using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega2.Controllers.Resources;
using Vega2.Models;
using Vega2.Core.Interfaces;

namespace Vega2.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository IRep;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository IRep, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.IRep = IRep;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicles([FromBody]SaveVehicleResource vehicleResource)
        {
            var vehicles = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicles.LastUpdate = DateTime.Now;
            IRep.Add(vehicles);
            await unitOfWork.SaverAsync();

            vehicles = await IRep.getRep(vehicles.Id,true);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicles);


            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicles(int id ,[FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(vehicleResource);

            var vehicles = await IRep.getRep(id, true);

            //we include the features table in the vehicles variable 
            //so that we can make changes to the features in mapping

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicles);
            vehicles.LastUpdate = DateTime.Now;
            await unitOfWork.SaverAsync();


            vehicles = await IRep.getRep(id, true);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicles);

            return Ok(vehicleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(id);

            var vehicle = await IRep.getRep(id, includeFeature: false);
            IRep.Remover(vehicle);
            await unitOfWork.SaverAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(id);

            var vehicle = await IRep.getRep(id,true);


            if (vehicle == null)
                return BadRequest(id);

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpGet]
        //Get Vehicles
        public async Task<QueryResultResources<VehicleResource>> getList(VehicleQueryResource queryObj)
        {
            var query = mapper.Map<VehicleQueryResource, VehicleQuery>(queryObj);
            var queryResultobj = await IRep.getVehicles(query);

            return mapper.Map<QueryResult<Vehicle>, QueryResultResources<VehicleResource>>(queryResultobj);
        }

    }
}