using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaData
{
    public class Staff
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Biography { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        // Relationships
        public virtual ICollection<Participation> Participations { get; set; }
    }
}
