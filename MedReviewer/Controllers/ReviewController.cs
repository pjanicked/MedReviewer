using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedReviewer.Controllers
{
    public class ReviewController : Controller
    {
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
    }
}