using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherProfile.Models;

namespace TeacherProfile.Controllers
{
    public class TeacherController : Controller
    {
        db_TeacherProfileEntities db = new db_TeacherProfileEntities();
        // GET: Teacher
        public ActionResult Index()
        {
            var data = db.tbl_Teacher.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(tbl_Teacher t)
        {
            db.tbl_Teacher.Add(t);
           int a= db.SaveChanges();
            if (a > 0)
            {
                TempData["InsertMessage"] = "<script> alert('Data Inserted')  </Script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "<script> alert('Data Not Inserted')  </Script>";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.tbl_Teacher.Where(x => x.id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(tbl_Teacher t)
        {
            db.Entry(t).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script> alert('Data Updated')  </Script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorUpdateMessage"] = "<script> alert('Data Not Updated')  </Script>";
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var Deleterow = db.tbl_Teacher.Where(x => x.id == id).FirstOrDefault();
            return View(Deleterow);
        }
        [HttpPost]
        public ActionResult Delete(tbl_Teacher t)
        {
            db.Entry(t).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script> alert('Data Deleted')  </Script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorUpdateMessage"] = "<script> alert('Data Not Updated')  </Script>";
            }
            return View();
        }
    }
}