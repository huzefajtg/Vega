using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega2.Persistence;

namespace Vega2.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaverAsync();
    }
}
