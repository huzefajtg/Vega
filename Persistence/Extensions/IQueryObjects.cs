using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Persistence.Extensions
{
    public interface IQueryObjects
    {
        string SortBy { get; set; }
        bool IsAsce { get; set; }

        int Page { get; set; }
        byte PageSize { get; set; }
    }
}
