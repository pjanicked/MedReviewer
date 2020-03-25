using AutoMapper;
using MedReviewer.Core.Helpers;
using MedReviewer.Core.Models;
using MedReviewer.Core.Operation;
using MedReviewer.DTO;
using MedReviewer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedReviewer.Controllers
{
    [CustomActionFilter]
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
            ViewBag.OktaUserID = HelperClass.UserSession.OktaUserId;
            return View();
        }

        [HttpGet]
        [Route("/Review/SeeReview")]
        public ActionResult SeeReview(string medicineId)
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

        //[Authorize] //--- CORS error ---//
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

        [HttpPost]
        public ActionResult GetReviews(int? medicineID)
        {
            try
            {
                var result = _reviewOperation.GetReviews(medicineID);
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult GetAllReviewsByMedicineID(int medicineId)
        {
            try
            {
                var result = HelperClass.classToJson(_reviewOperation.GetAllReviewsByMedicineID(medicineId));
                return Json(result, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}