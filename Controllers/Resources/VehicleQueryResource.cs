using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Controllers.Resources
{
    public class VehicleQueryResource
    {
        public int? Makeid { get; set; }
        public string SortBy { get; set; }
        public bool IsAsce{ get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set; }

    }
}
