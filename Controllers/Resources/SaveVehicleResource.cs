using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Controllers.Resources
{
    public class SaveVehicleResource    //used for whatever data we get direct from vehicle table
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public ContactResource Contact { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<int> VehicleFeature { get; set; }

        public SaveVehicleResource()
        {
            VehicleFeature = new Collection<int>();
        }
    }
}
