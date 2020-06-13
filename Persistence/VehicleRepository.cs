using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega2.Models;
using Vega2.Core.Interfaces;
using System.Linq.Expressions;
using Vega2.Persistence.Extensions;

namespace Vega2.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;

        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task<Vehicle> getRep(int id, bool includeFeature = true)
        {
            if (!includeFeature)
                return await context.Vehicle.FindAsync(id);
            else
                return await context.Vehicle
                    .Include(v => v.VehicleFeature)
                        .ThenInclude(vf => vf.Feature)
                    .Include(v => v.Model)
                        .ThenInclude(m => m.Make)
                    .SingleOrDefaultAsync(v => v.Id == id);

        }

        public void Add(Vehicle vehicle)
        {
            context.Vehicle.Add(vehicle);
        }

        public void Remover(Vehicle vehicle)
        {
            context.Vehicle.Remove(vehicle);

        }

        public async Task<QueryResult<Vehicle>> getVehicles(VehicleQuery queryobj)
        {
            var result = new QueryResult<Vehicle>();
            var query=context.Vehicle
                            .Include(v => v.Model)
                                .ThenInclude(m => m.Make)
                            .Include(v => v.VehicleFeature)
                                .ThenInclude(vf => vf.Feature)
                            .AsQueryable();
            if (queryobj.Makeid.HasValue == true)
                query = query.Where(v => v.Model.MakeId == queryobj.Makeid.Value);

            var colsmap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["Make"] = v => v.Model.Make.name,
                ["Model"] = v => v.Model.name,
                ["Contact Name"] = v => v.ConName
            };

            query = query.Sorter(queryobj, colsmap);

            result.totalItems = await query.CountAsync();

            query = query.ApplyPager(queryobj);

            result.Items= await query.ToListAsync();
            return result;

            
        }


    }
}
