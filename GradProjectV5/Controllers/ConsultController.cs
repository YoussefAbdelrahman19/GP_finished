using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GradProjectV5.Models;
using Microsoft.AspNet.Identity;

namespace GradProjectV5.Controllers
{
    [Authorize]
    [SessionState(System.Web.SessionState.SessionStateBehavior.Required)]
    public class ConsultController : Controller
    {
        [HttpGet]
        public ActionResult AddConsultType()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddConsultType(ConsultType c)
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            ConsultType consultType = new ConsultType();
            consultType.ConsultTypeName = c.ConsultTypeName;
            db.ConsultTypes.Add(consultType);
            db.SaveChanges();
            return RedirectToAction("Create");
        }


        
        [HttpGet]
        public dynamic LoadConsultType()
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            var tmp = db.ConsultTypes.Select(x => new
            {
                x.ID,
                x.ConsultTypeName
            }).ToList();
            return Json(tmp , JsonRequestBehavior.AllowGet) ;
        }
        // GET: DoctorQuestions
        [HttpGet]
        public dynamic Index()
        {
            return View();
        }


        [HttpGet]
        public dynamic LoadQuestionsView()
        {
            return View();
        }

        [HttpGet]
        public dynamic LoadQuestionsForAnswer()
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            var userid = User.Identity.GetUserId();
            var member = db.Members.FirstOrDefault(x => x.UserId == userid);
            var tmp = db.Consults.Where(x => x.IsDeleted == false && x.ConsultAnswers.FirstOrDefault(c =>c.AnsweredById ==member.ID)== null).Select(x => new
            {
                x.ID,
                AvailableFilePath = x.AvailableFilePath == null ? "" : x.AvailableFilePath,
                ConsultQuestionTitle = x.ConsultQuestionTitle == null ? "" : x.ConsultQuestionTitle,
                ConsultQuestionName = x.ConsultQuestionName == null ? "" : x.ConsultQuestionName,
                ConsultTypeName = x.ConsultTypeId == null ? "" : x.ConsultType.ConsultTypeName,
                QuestionerName= x.QuestionerId == null ?"":x.Member.FullName,
                Age = x.QuestionerId == null ?"": x.Member.Age,
                GenderName = x.QuestionerId == null ?"": x.Member.Gender.GenderName,

                Qday = x.QuestionDate == null ?0: x.QuestionDate.Value.Day,
                Qmonth = x.QuestionDate == null ?0: x.QuestionDate.Value.Month,
                Qyear = x.QuestionDate == null ?0: x.QuestionDate.Value.Year
               

            }).ToList();

            return Json(tmp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public dynamic LoadQuestionsWithAnswers()
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            var tmp = db.Consults.Where(x => x.IsDeleted == false).Select(x => new
            {

                AvailableFilePath = x.AvailableFilePath == null ? "" : x.AvailableFilePath,
                ConsultQuestionTitle = x.ConsultQuestionTitle == null ? "" : x.ConsultQuestionTitle,
                ConsultQuestionName = x.ConsultQuestionName == null ? "" : x.ConsultQuestionName,
                ConsultTypeName = x.ConsultTypeId == null ? "" : x.ConsultType.ConsultTypeName,
                QuestionerName= x.QuestionerId == null ?"":x.Member.FullName,
                Age = x.QuestionerId == null ?"": x.Member.Age,
                GenderName = x.QuestionerId == null ?"": x.Member.Gender.GenderName,

                Qday = x.QuestionDate == null ?0: x.QuestionDate.Value.Day,
                Qmonth = x.QuestionDate == null ?0: x.QuestionDate.Value.Month,
                Qyear = x.QuestionDate == null ?0: x.QuestionDate.Value.Year,
                ConsultAnswersResult =x.ConsultAnswers.Where(q =>q.IsDeleted == false && q.ConsultId == x.ID).Select(q =>new
                {
                    ResponderName= x.QuestionerId == null ?"":q.Member.FullName,
                    Rday = q.AnswerDate == null ?0: q.AnswerDate.Value.Day,
                    Rmonth = q.AnswerDate == null ?0: q.AnswerDate.Value.Month,
                    Ryear = q.AnswerDate == null ?0: q.AnswerDate.Value.Year,
                    Answer=q.Answer == null ?"":q.Answer
                })


            }).ToList();

            return Json(tmp, JsonRequestBehavior.AllowGet);
        }


        // GET: DoctorQuestions
        public ActionResult Create()
        {
            return View();
        }


       [HttpPost]
        public ActionResult Create(Consult c)
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            Consult consult = new Consult();
            var userid = User.Identity.GetUserId();
            var member = db.Members.FirstOrDefault(x => x.UserId == userid);
            if (member != null)
                consult.QuestionerId = member.ID;
            if (Session["ConsultFile"] != null)
            {
                List<string>consultfileList = (List<string>) Session["ConsultFile"];
                consult.AvailableFilePath = consultfileList[0];
                Session.Remove("ConsultFile");

            }

            consult.ConsultQuestionName = c.ConsultQuestionName;
            consult.ConsultQuestionTitle = c.ConsultQuestionTitle;
            consult.ConsultTypeId = c.ConsultTypeId;
            consult.IsDeleted = false;
            consult.QuestionDate = DateTime.Now;
            db.Consults.Add(consult);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public dynamic SaveConsultAnswer(int consultid, string answer)
        {
            MyProjectDBEntities db = new MyProjectDBEntities();
            var userid = User.Identity.GetUserId();
            var member = db.Members.FirstOrDefault(x => x.UserId == userid);
            ConsultAnswer consultAnswer = new ConsultAnswer();
            consultAnswer.AnswerDate = DateTime.Now;
            consultAnswer.IsDeleted = false;
            consultAnswer.Answer = answer;
            consultAnswer.ConsultId = consultid;
            if (member != null)
                consultAnswer.AnsweredById = member.ID;
            db.ConsultAnswers.Add(consultAnswer);
            db.SaveChanges();
            return "تم تسجيل ردك بنجاح";
        }

        #region consult_files





        [HttpPost]
        public void addFiles(dynamic file_name, dynamic respons)
        {



            string File_Name = respons.ToString();
            ;


            List<string> DicFile = new List<string>();
            if (Session["ConsultFile"] != null)
            {

                DicFile = (List<string>)Session["ConsultFile"];
                if (DicFile.Any(a => a == File_Name))
                    DicFile.Remove(File_Name);
            }

            DicFile.Add(File_Name);
            Session.Add("ConsultFile", DicFile);

        }



        [HttpPost]
        public void Remove_This_FileName(dynamic filename)
        {
            string canceledFile = filename.ToString();
            List<string> AllFiles = (List<string>)Session["ConsultFile"];
            if (AllFiles != null)
            {
                for (int i = 0; i < AllFiles.Count; i++)
                {


                    if (AllFiles[i].Contains(canceledFile))
                    {
                        AllFiles.Remove(AllFiles[i]);
                    }

                }


                Session["ConsultFile"] = AllFiles;



            }

        }
  

        #endregion

    }

}