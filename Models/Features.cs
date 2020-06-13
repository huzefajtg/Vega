using System.ComponentModel.DataAnnotations;

namespace Vega2.Models
{
    public class Features
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}