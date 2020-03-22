using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string UserEmail { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string OktaUserId { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string OktaUserName { get; set; }

        public DateTime? UserCreatedDate { get; set; }

        public DateTime? UserUpdatedDate { get; set; }
    }
}
