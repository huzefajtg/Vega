using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Controllers.Resources
{
    public class MakesResources : KeyValuePairResource
    {
        public ICollection<ModelsResources> Models { get; set; }

        public MakesResources()
        {
            Models = new Collection<ModelsResources>();
        }
    }
}
