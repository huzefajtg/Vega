using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Controllers.Resources
{
    public class QueryResultResources<T>
    {
        public int totalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
