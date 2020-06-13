using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega2.Persistence.Extensions;

namespace Vega2.Models
{
    public class VehicleQuery : IQueryObjects
    {
        public int? Makeid { get; set; }
        public string SortBy { get; set; }
        public bool IsAsce { get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
