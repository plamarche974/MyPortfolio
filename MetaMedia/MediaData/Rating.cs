using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaData
{
    public class Rating
    {
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int WorkID { get; set; }

        [Range(1, 10)]
        public int Score { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        public DateTime RatingDate { get; set; }

        // Relationships
        public virtual User User { get; set; }
        public virtual Work Work { get; set; }
    }
}
