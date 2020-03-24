using MedReviewer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.InterfaceRepository
{
    interface IReviewRepository: IGenericRepository<Review>
    {
        IList<object> GetReviews(int? medicineId);
    }
}
