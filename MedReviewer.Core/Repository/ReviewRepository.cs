using MedReviewer.Core.DatabaseContext;
using MedReviewer.Core.InterfaceRepository;
using MedReviewer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.Repository
{
    public class ReviewRepository: GenericRepository<Review>, IReviewRepository
    {
        public IList<object> GetReviews(int? medicineId)
        {
            try
            {
                using (var DbContext = new DataContext())
                {
                    var query = (from r in DbContext.Reviews
                                 group r by new
                                 {
                                     r.PillboxMedicineId,
                                     r.PillboxMedicineName
                                 } into grp
                                 select new
                                 {
                                     grp.Key.PillboxMedicineId,
                                     grp.Key.PillboxMedicineName,
                                     noOfReviews = grp.Count(),
                                     avgRating = grp.Average(x => x.ReviewRating)
                                 });

                    if(medicineId != null && medicineId > 0)
                    {
                        query = query.Where(x => x.PillboxMedicineId == medicineId);
                    }

                    return query.ToList<object>();
                        
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<object> GetAllReviewsByMedicineID(int medicineId)
        {
            try
            {
                using (var DbContext = new DataContext())
                {
                    return (from r in DbContext.Reviews
                            join u in DbContext.Users on r.ReviewCreatedBy equals u.UserId
                            where r.PillboxMedicineId == medicineId
                            select new
                            {
                            r.ReviewId,
                            r.ReviewTitle,
                            r.ReviewRating,
                            r.ReviewPros,
                            r.ReviewCons,
                            r.PillboxMedicineId,
                            r.PillboxMedicineName,
                            r.ReviewCreatedBy,
                            CreatedByName = u.OktaUserName,
                            r.ReviewCreatedDate,
                            r.ReviewUpdatedBy,
                            r.ReviewUpdatedDate
                            }).ToList<object>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
