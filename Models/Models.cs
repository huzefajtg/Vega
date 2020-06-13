using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Models//folder Models not file Models.cs
{
    [Table("Models")]
    public class Model
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        public Make Make { get; set; }

        public int MakeId { get; set; }
    }
}
