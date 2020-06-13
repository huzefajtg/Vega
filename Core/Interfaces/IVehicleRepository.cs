using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega2.Models;

namespace Vega2.Core.Interfaces

{
    public interface IVehicleRepository
    {
        Task<Vehicle> getRep(int id, bool includeFeature);
        void Add(Vehicle vehicle);
        void Remover(Vehicle vehicle);
        Task<QueryResult<Vehicle>> getVehicles(VehicleQuery queryobj);
    }
}
