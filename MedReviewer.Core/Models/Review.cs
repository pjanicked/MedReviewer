using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string ReviewTitle { get; set; }

        [Required]
        public double ReviewRating { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string ReviewPros { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string ReviewCons { get; set; }
            
        public DateTime? ReviewCreatedDate { get; set; }

        public DateTime? ReviewUpdatedDate { get; set; }

        public int ReviewCreatedBy { get; set; }

        public int ReviewUpdatedBy { get; set; }

        [Required]
        public int PillboxMedicineId { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string PillboxMedicineName { get; set; }
    }
}
