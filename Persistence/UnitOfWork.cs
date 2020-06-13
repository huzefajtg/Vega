using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega2.Core.Interfaces;

namespace Vega2.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly VegaDbContext context;
        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task SaverAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
