using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using MVCwithData.Models.Classes;

namespace MVCwithData.Controllers
{
    public class UnvanController : Controller
    {
        // GET: Unvan

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
        public ActionResult List()
        {

            string query = "Select *from Unvan";
            var unvanList = con.Query<Unvan>(query).ToList();

            return View(unvanList);
        }




        [HttpGet]
        public ActionResult Delete(int id)
        {
            string qry = $"Select * from Unvan where UnvanId ='{id}'  ";
            var unvan = con.Query<Unvan>(qry).First();
            return View(unvan);
        }

        [HttpPost]

        public ActionResult Delete(Unvan model)
        {
            string qry = "Delete from Unvan where UnvanId=@UnvanId";
              con.ExecuteScalar<int>(qry, model);
            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult Create()  //property'leri boş olarak gönderiyor
        {
            Unvan u = new Unvan();
            return View(u);

        }


        [HttpPost]

        public ActionResult Create(Unvan model)
        {
            string qry = "insert into Unvan(UnvanAd) VALUES (@UnvanAd) ";
            con.ExecuteScalar<int>(qry, model);
            return RedirectToAction("List");   //List metoduna geridönüyor

        }


        [HttpGet]    // Defaultu GEt yazmazsan , her metodun üstüde yazman lazım.

        public ActionResult Update(string id)   //id yi alır.
        {
            string qry = $"select UnvanId , UnvanAd from Unvan where UnvanId = '{id}'";//id değişken oldu için {} içinde yazılır.Değişken Char is '' içinde yazmayı unutma!!!!!
            var unvan = con.Query<Unvan>(qry).First();
            return View(unvan);
        }


        [HttpPost]
        public ActionResult Update(Unvan model)
        {                                             //@ parametredemek

            string qry = $"Update Unvan set UnvanAd= @UnvanAd where UnvanId = @UnvanId";
            //1.Yol

            // var ulke = con.ExecuteScalar<int>(qry,model); // Tipi int çünkü kaç tane row düzeltildiğini söylüyor.  //kısa yol  Parametreyi model olarak verirsek UlkeAd a modeldekini yani  @UlkeAd ı attık

            //2.Yol(Uzun Yol)

            DynamicParameters par = new DynamicParameters();
            par.Add("@UnvanAd", model.UnvanAd);
            par.Add("@UnvanId", model.UnvanId);
           con.ExecuteScalar<int>(qry, par);//kaç kayıt silindiğini söyler

            return RedirectToAction("List");  //Eğer o id başka tabloda varsa silinemez,kullanılmayan ı siler.
        }

    }


}
