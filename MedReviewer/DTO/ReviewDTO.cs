using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedReviewer.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }

        public string ReviewTitle { get; set; }

        public double ReviewRating { get; set; }

        public string ReviewPros { get; set; }

        public string ReviewCons { get; set; }

        public DateTime? ReviewCreatedDate { get; set; }

        public DateTime? ReviewUpdatedDate { get; set; }

        public int ReviewCreatedBy { get; set; }

        public int ReviewUpdatedBy { get; set; }

        public int PillboxMedicineId { get; set; }

        public string PillboxMedicineName { get; set; }
    }
}