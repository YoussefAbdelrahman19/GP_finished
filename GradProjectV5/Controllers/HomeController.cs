using GradProjectV5.Models;
using GradProjectV5.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradProjectV5.Controllers
{

    [SessionState(System.Web.SessionState.SessionStateBehavior.Required)]
    public class HomeController : Controller
    {
        MyProjectDBEntities db = new MyProjectDBEntities();
        public ActionResult Index()
        {
            return View();
        }


      [HttpGet]
        public ActionResult DontatingMedicine()
        {

            return View();
      }
      //[HttpPost]
      //public ActionResult DontatingMedicine(Medicine mdc)
      //{
      //    if (ModelState.IsValid)
      //    {
      //        db.Medicines.Add(mdc);
      //        db.SaveChanges();
      //        return View("DontatingMedicine");
      //    }
      //    else
      //    {
      //        return View(mdc);
      //    }

      //    return View("DontatingMedicine");

      //}
      [HttpGet]
      public ActionResult AskDoctor()
      {
          return View();
      }

      [HttpPost]
      public ActionResult AskDoctor(Complaint comp)
      {
          if (ModelState.IsValid)
          {
              return RedirectToAction("Index");
          }
          return View("AskDoctor",comp);
      }
    public ActionResult AskDoctorData()
        {


            return View();
        }
        

        [HttpPost]
    public ActionResult SaveComplaint(ComplainMember c)
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            ComplainMember complainMember = new ComplainMember();
            Complaint complaint = new Complaint();
            Member member = new Member();
            Gender gender = new Gender(); 
            gender.GenderName = c.Gender.GenderName;
            member.FullName = c.Member.FullName;
            member.Age = c.Member.Age;
            complaint.AvialableRespondNotes = c.Complaint.AvialableRespondNotes;
            complaint.IsDeleted = false;
            complaint.ComplainDate = c.Complaint.ComplainDate;
            complaint.ComplaintDescription = c.Complaint.ComplaintDescription;
            if (Session["ComplaintFile"] != null)
            {
                List<string> ComplaintFiles = (List<string>)Session["ComplaintFile"];
                complaint.ComplaintFilePath = ComplaintFiles[0];
                Session.Remove("ComplaintFile");

            }
            if (ModelState.IsValid) { 
           
                //db.Entry(member).State = EntityState.Added;
                //db.Entry(gender).State = EntityState.Added;
                //db.Entry(complaint).State = EntityState.Added;
                db.Members.Add(member);
                db.Complaints.Add(complaint);
                db.Genders.Add(gender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //if there error will view the ViewScreen Fulled with the corrupted object distributed throw the inputs
            return View("AskDoctorData",c);
            
        }



        #region coursefile





        [HttpPost]
        public void addFiles(dynamic file_name, dynamic respons)
        {



            string File_Name = respons.ToString();
            


            List<string> DicFile = new List<string>();
            if (Session["ComplaintFile"] != null)
            {

                DicFile = (List<string>)Session["ComplaintFile"];
                if (DicFile.Any(a => a == File_Name))
                    DicFile.Remove(File_Name);
            }

            DicFile.Add(File_Name);
            Session.Add("ComplaintFile", DicFile);

        }



        [HttpPost]
        public void Remove_This_FileName(dynamic filename)
        {
            string canceledFile = filename.ToString();
            List<string> AllFiles = (List<string>)Session["ComplaintFile"];
            if (AllFiles != null)
            {
                for (int i = 0; i < AllFiles.Count; i++)
                {


                    if (AllFiles[i].Contains(canceledFile))
                    {
                        AllFiles.Remove(AllFiles[i]);
                    }

                }


                Session["ComplaintFile"] = AllFiles;



            }

        }
  

        #endregion
        //for Pharmacy View
   
        public ActionResult GetPharamacyData()
        {

            return View();
        }

    }
    
}