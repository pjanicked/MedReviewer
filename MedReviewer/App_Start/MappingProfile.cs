using AutoMapper;
using MedReviewer.Core.Models;
using MedReviewer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedReviewer.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Review, ReviewDTO>();
            Mapper.CreateMap<ReviewDTO, Review>();
        }
    }
}