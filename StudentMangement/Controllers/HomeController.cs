using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StudentMangement.Models;

namespace StudentMangement.Controllers
{
    public class HomeController : Controller
    {
        public StudentsEntities db = new StudentsEntities();

        public ActionResult Index()
        {
            List<Degree> DegreeList = db.Degrees.ToList();
            ViewBag.ListOfDegree = new SelectList(DegreeList, "DegreeID", "DegreeName");
            return View();
        }

        public JsonResult GetStudentList()
        {
            List<StudentViewModel> StuList = db.Students.Where(x => x.IsDeleted == false).Select(x => new StudentViewModel
            {
                StudentId = x.StudentId,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                DegreeName = x.Degree.DegreeName,
                
            }).ToList();

            return Json(StuList, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetStudentById(int StudentId)
        {
            Student model = db.Students.Where(x => x.StudentId == StudentId).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDataInDatabase(StudentViewModel model)
        {
            var result = false;
            try
            {
                if(model.StudentId > 0)
                {
                    Student Stu = db.Students.SingleOrDefault(x => x.IsDeleted == false && x.StudentId == model.StudentId);
                    Stu.Name = model.Name;
                    Stu.Address = model.Address;
                    Stu.PhoneNumber = model.PhoneNumber;
                    Stu.DegreeID = model.DegreeID;
                    db.SaveChanges();
                    result = true;
                    
                }
                else
                {
                    Student Stu = new Student();
                    Stu.Name = model.Name;
                    Stu.Address = model.Address;
                    Stu.PhoneNumber = model.PhoneNumber;
                    Stu.DegreeID = model.DegreeID;
                    Stu.IsDeleted = false;
                    db.Students.Add(Stu);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteStudentRecord(int StudentId)
        {
            bool result = false;
            Student Stu = db.Students.SingleOrDefault(x => x.IsDeleted == false && x.StudentId == StudentId);
            if (Stu != null)
            {
                Stu.IsDeleted = true;
                db.SaveChanges();
                result = true; 
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

       
    }
}