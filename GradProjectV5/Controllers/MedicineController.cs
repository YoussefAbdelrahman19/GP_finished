using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GradProjectV5.Models;

namespace GradProjectV5.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Medicine m)
        {
            if (ModelState.IsValid)
            {

                MyProjectDBEntities db = new MyProjectDBEntities();
                Medicine medicine = new Medicine();
                medicine.MedicineName = m.MedicineName;
                medicine.IsDeleted = false;
                medicine.ExpireDate = m.ExpireDate;
                medicine.MedicineDescription = m.MedicineDescription;
                db.Medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("RequestMedicine", "Pharmacy");
            }

            return View(m);
        }


        [HttpGet]
        public dynamic Index()
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            var tmp = db.Medicines.Where(x => x.IsDeleted == false).Select(x => new
            {
                x.ID,
                MedicineName = x.MedicineName == null ?"":x.MedicineName,
                MedicineDescription =x.MedicineDescription == null ?"":x.MedicineDescription,
                eday = x.ExpireDate == null ?0:x.ExpireDate.Value.Day,
                emonth = x.ExpireDate == null ?0:x.ExpireDate.Value.Month,
                eyear = x.ExpireDate == null ?0:x.ExpireDate.Value.Year,

            }).ToList();
            return Json(tmp, JsonRequestBehavior.AllowGet);
        }
    }
}