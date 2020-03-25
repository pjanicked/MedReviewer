using MedReviewer.Core.Helpers;
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
        private readonly AccountRepository _acRepository;

        public ReviewOperation()
        {
            _reviewRepository = new ReviewRepository();
            _acRepository = new AccountRepository();
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
            var myUserID = _acRepository.GetData(x => x.OktaUserId == HelperClass.UserSession.OktaUserId);
            if(isAdd)
            {
                review.ReviewCreatedDate = DateTime.Now;
                //review.ReviewCreatedBy = Convert.ToInt32(HelperClass.UserSession.OktaUserId);
                review.ReviewCreatedBy = myUserID[0].UserId;
            }
            else
            {
                review.ReviewUpdatedDate = DateTime.Now;
                //review.ReviewUpdatedBy = Convert.ToInt32(HelperClass.UserSession.OktaUserId);
                review.ReviewUpdatedBy = myUserID[0].UserId;
            }
        }

        public List<object> GetReviews(int? medicineId)
        {
            try
            {
                return _reviewRepository.GetReviews(medicineId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<object> GetAllReviewsByMedicineID(int medicineId)
        {
            try
            {
                return _reviewRepository.GetAllReviewsByMedicineID(medicineId).ToList<object>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
