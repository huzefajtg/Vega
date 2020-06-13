using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega2.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(25)]
        public string ConName { get; set; }

        [Required]
        [StringLength(25)]
        public string ConPhone { get; set; }

        [StringLength(50)]
        public string ConEmail { get; set; }

        public DateTime LastUpdate { get; set; }

        public Model Model { get; set; }
        public ICollection<VehicleFeature> VehicleFeature { get; set; }

        public Vehicle() {
            VehicleFeature = new Collection<VehicleFeature>();
        }
    }
}
