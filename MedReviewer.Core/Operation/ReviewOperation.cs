using MedReviewer.Core.Models;
using MedReviewer.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.Operation
{
    public class ReviewOperation
    {
        private readonly ReviewRepository _reviewRepository;

        public ReviewOperation()
        {
            _reviewRepository = new ReviewRepository();
        }

        public object AddReview(Review review)
        {
            try
            {
                if(review != null)
                {
                    fillProperty(review, true);
                    return _reviewRepository.Add(review);
                }
                else
                {
                    throw new Exception("Parameter cannot be null");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void fillProperty(Review review, bool isAdd)
        {
            if(isAdd)
            {
                review.ReviewCreatedDate = DateTime.Now;
            }
            else
            {
                review.ReviewUpdatedDate = DateTime.Now;
            }
        }
    }
}
