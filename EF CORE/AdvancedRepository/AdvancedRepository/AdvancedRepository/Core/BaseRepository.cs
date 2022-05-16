using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class  //Deleted i getirmek için Base yazmıştık softdeleted projesinde ,  kısıtlayacaksak class yazarız . Fakat hata verdi FatDEtail da bu yüzden tekrar class tan kalıtıyor
    {
        SirketContext _db;
        public BaseRepository(SirketContext db)
        {
            _db = db;
        }
        public bool Create(T ent)
        {
            try
            {
                //ent.CreateDate = DateTime.Now;
                //ent.WhoUpdated = "Tuğçe";//session
                Set().Add(ent);
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public bool Delete(T ent)
        {
            try
            {
                Set().Remove(ent);
                
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int id)
        {
           return  Set().Find(id);
          
        }



        public T Find(int Id, int pId)  //Find() Overload  ,IBaseRepositoryde tanımlamalıyız 
        {
            return Set().Find(Id , pId);

        }



        //public List<T> List()
        //{
        //    return Set().ToList();
        //}

        public IQueryable<T> Query()
        {
            return Set().AsQueryable();
        }





        //public void Save()
        //{
        //     _db.SaveChanges();
        //}

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T ent)
        {
            try
            {
                //ent.LastUpdated = DateTime.Now;
                //ent.WhoUpdated = "Hüseyin"; // Session
                Set().Update(ent);
               
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          
        }
    }
}
