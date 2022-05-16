using OgrenciProjeCodeFirst.Models.Data;
using OgrenciProjeCodeFirst.Models.DTOs;
using OgrenciProjeCodeFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciProjeCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        OgrenciContext db = new OgrenciContext();
        public ActionResult List()
        {
            var slist = db.Set<Student>().Select(x => new StudentDTO

            {
                Id = x.Id,
                Name  = x.Name,
                Surname = x.Surname,
                CityName = x.City.CityName,
                Mothername = x.MotherName


            }).ToList();
           
            return View(slist);
        }

        [HttpGet]


        public ActionResult Create()
        {
            StudentModel model = new StudentModel();
            model.Baslik = "Yeni Kayıt İşlemi";
            model.BtnVal = "Ekle";
            model.BtnClass = "btn btn-primary";
            model.InputType = "text";
            model.Student = new Student();
            model.CityList = GetCityList();


            return View("Crud", model);
        }

        private List<CityDTO> GetCityList()
        {
            return db.Set<City>().Select(x => new CityDTO
            {
                CityId = x.CityId,
                CityName = x.CityName

            }).ToList();
        }


        [HttpPost]

        public ActionResult Create(StudentModel model)
        {
            db.Entry(model.Student).State = EntityState.Added;
            Session["cls"] = "alert-success";
            Session["mesaj"] = $"Kayıt işlemi Başarılı";
            db.SaveChanges();

            return RedirectToAction("List");
        }


        [HttpGet]

        public ActionResult Update(int id)
        {
            StudentModel model = new StudentModel();
            model.Baslik = "Güncelleme İşlemi";
            model.BtnVal = "Güncelle";
            model.BtnClass = "btn btn-success";
            model.InputType = "hidden";
            model.Student = db.Set<Student>().Find(id);
            model.CityList = GetCityList();

            return View("Crud", model);
        }


        [HttpPost]

        public ActionResult Update(StudentModel model)
        {
            db.Entry(model.Student).State = EntityState.Modified;
            Session["cls"] = "alert-success";
            Session["mesaj"] = $"Güncelleme İşlemi Başarılı";
            db.SaveChanges();

            return RedirectToAction("List");
        }


        [HttpGet]

        public ActionResult Delete(int id)
        {
            StudentModel model = new StudentModel();
            model.Baslik = "Silme İşlemi";
            model.BtnVal = "Sil";
            model.BtnClass = "btn btn-danger";
            model.InputType = "hidden";
            model.Student = db.Set<Student>().Find(id);
            model.CityList = GetCityList();

            return View("Crud", model);
        }

        [HttpPost]

        public ActionResult Delete(StudentModel model)
        {


           
                db.Entry(model.Student).State = EntityState.Deleted;
                db.SaveChanges();
                Session["cls"] = "alert-success";
                Session["mesaj"] = $"Silme İşlemi Başarılı";
          
     
        

            return RedirectToAction("List");
        }
    }
}