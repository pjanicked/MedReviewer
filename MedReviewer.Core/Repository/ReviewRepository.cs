﻿using MedReviewer.Core.InterfaceRepository;
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
    }
}
