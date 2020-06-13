using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Models
{
    public class QueryResult<T>
    {
        public int totalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
