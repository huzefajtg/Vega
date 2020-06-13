using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }

    public class VehicleResource
    {
        public int Id { get; set; }

        public KeyValuePairResource Model { get; set; }
        public ContactResource Contact { get; set; }
        public KeyValuePairResource Make { get; set; }

        public bool IsRegistered { get; set; }
        
        public DateTime LastUpdate { get; set; }

        public ICollection<KeyValuePairResource> Features { get; set; }
        //we are only initializing collections

        public VehicleResource()
        {
            Features = new Collection<KeyValuePairResource>();
        }
    }
}
