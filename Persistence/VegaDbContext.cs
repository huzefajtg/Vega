using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega2.Models;

namespace Vega2.Persistence
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Make> Make { get; set; }
        public DbSet<Features> Feature { get; set; }
        public DbSet<Vehicle> Vehicle{ get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<VehicleFeature>().HasKey
                (vf => new { vf.VehicleId, vf.FeatureId });
        }
    }
}
