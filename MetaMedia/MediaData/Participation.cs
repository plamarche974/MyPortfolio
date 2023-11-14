using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaData
{
    public class Participation
    {
        public int ID { get; set; }

        [Required]
        public int WorkID { get; set; }

        [Required]
        public int StaffID { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } // e.g., Actor, Director

        // Relationships
        public virtual Work Work { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
