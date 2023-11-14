using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaData
{
    internal class Work
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le titre ne peut pas dépasser 100 caractères.")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Url]
        public string ImageURL { get; set; }

        // Relationships
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Participation> Participations { get; set; }
    }
}
