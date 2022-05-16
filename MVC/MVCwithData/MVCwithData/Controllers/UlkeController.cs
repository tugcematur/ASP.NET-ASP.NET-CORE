using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MVCwithData.Models.Classes;

namespace MVCwithData.Controllers
{
    public class UlkeController : Controller
    {
        // GET: Ulke


        // SqlConnection con = new SqlConnection("Server=SQLEXPRESS;Database=perdb2;Integrated Security = True");

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString); //properties çift tıkla , create one tıkla, Setting - Connection :String-App ->browse tıkla ->Microsoft SQL Server (SqlClient) ı seç -> sonra Server ve veritabanı nismini gir ok de . Web.config de      <add name="Baglanti" connectionString="Data Source=DESKTOP-HRRA875\SQLEXPRESS;Initial Catalog=perdb2;Integrated Security=True" kısmında name i baglanti yap

        public ActionResult List()
        {
            string qry = "select UlkeId , UlkeAd from Ulke";  //class taki ile aynı olmalı isim.
            var ulkeList = con.Query<Ulke>(qry).ToList(); //Ulke = class bütün değerlerin gelmesi için ToList () kullanılır.

            //var UlkeList = ulkeList;
            //ViewBag.ulist = ulkeList;  1.Yöntem
            return View(ulkeList);     //Daha iyi olan  yöntem
        }
        [HttpGet]    // Defaultu GEt yazmazsan , her metodun üstüde yazman lazım.

        public ActionResult Update(string id)   //id yi alır.
        {
            string qry = $"select UlkeId , UlkeAd from Ulke where UlkeId = '{id}'";//id değişken oldu için {} içinde yazılır.Değişken Char is '' içinde yazmayı unutma!!!!!
            var ulke = con.Query<Ulke>(qry).First();
            return View(ulke);
        }                                                     //İki metodun adı da aynı olmalı => Update gibi
        [HttpPost]
        public ActionResult Update(Ulke model)
        {                                             //@ parametredemek

            string qry = $"Update Ulke set UlkeAd= @UlkeAd where UlkeId = @UlkeId";
            //1.Yol

            // var ulke = con.ExecuteScalar<int>(qry,model); // Tipi int çünkü kaç tane row düzeltildiğini söylüyor.  //kısa yol  Parametreyi model olarak verirsek UlkeAd a modeldekini yani  @UlkeAd ı attık

            //2.Yol(Uzun Yol)

            DynamicParameters par = new DynamicParameters();
            par.Add("@UlkeAd", model.UlkeAd);
            par.Add("@UlkeId", model.UlkeId);
             con.ExecuteScalar<int>(qry, par);//kaç kayıt silindiğini söyler

            return RedirectToAction("List");  //Eğer o id başka tabloda varsa silinemez,kullanılmayan ı siler.
        }

        //[HttpGet]    //1.Yol  Direkt siler.

        //public ActionResult Delete(string id)   //id yi alır.
        //{
        //    string qry = $"Delete  from Ulke where UlkeId = '{id}'";//id değişken oldu için {} içinde yazılır.Değişken Char is '' içinde yazmayı unutma!!!!!
        //    var ulke = con.ExecuteScalar<int>(qry);
        //    return RedirectToAction("List");
        //}


        [HttpGet] // 2.Yol      Update gibi ikaydı getirir biz sileriz

        public ActionResult Delete(string id)   //id yi alır.
        {
            string qry = $"select * from Ulke where UlkeId = '{id}'";//id değişken oldu için {} içinde yazılır.Değişken Char is '' içinde yazmayı unutma!!!!!
            var ulke = con.Query<Ulke>(qry).First();
            return View(ulke);
        }

   

        [HttpPost] //Post olsa bile Get yazmalı

        public ActionResult Delete(Ulke Model2)   //id yi alır.
        {
            string qry = $"Delete from Ulke where UlkeId = @UlkeId";//id değişken oldu için {} içinde yazılır.Değişken Char is '' içinde yazmayı unutma!!!!!
             con.ExecuteScalar<int>(qry,Model2);
            return RedirectToAction("List");

      
        }


        [HttpGet]
        public ActionResult Create()  //property'leri boş olarak gönderiyor
        {
            Ulke u = new Ulke();
            return View(u);

        }




        [HttpPost]

        public ActionResult Create(Ulke model)
        {
            string qry = "insert into Ulke(UlkeId,UlkeAd) VALUES (@UlkeId,@Ulkead) ";
            con.ExecuteScalar<int>(qry, model);
            return RedirectToAction("List");   //List metoduna geridönüyor

        }




    }
}