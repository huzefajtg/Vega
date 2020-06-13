using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vega2.Models
{
    [Table("Make")]
    public class Make
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        public ICollection<Model> Models { get; set; }

        public Make()
        {
            Models = new Collection<Model>();
        }


    }
}
