using AutoMapper;
using MedReviewer.Core.Models;
using MedReviewer.Core.Operation;
using MedReviewer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedReviewer.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewOperation _reviewOperation;

        public ReviewController()
        {
            _reviewOperation = new ReviewOperation();
        }

        //[Authorize]
        [HttpGet]
        [Route("/Review/FindYourMed")]
        public ActionResult FindYourMed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TestData()
        {
            return Json(new
            {
                MedicineName = "A",
                MedicineType = "B",
                MedicineQuantity = "C",
                MedicinePrice = 23
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("/Review/AddReview")]
        public ActionResult AddReview(ReviewDTO reviewDTO)
        {
            try
            {
                var result = _reviewOperation.AddReview(Mapper.Map<ReviewDTO, Review>(reviewDTO));
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}