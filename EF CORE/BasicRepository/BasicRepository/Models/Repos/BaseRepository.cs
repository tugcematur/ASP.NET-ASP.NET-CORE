using BasicRepository.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Models.Repos                         //   T -> Class   ent-> model
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        PerContext _db;

        public BaseRepository(PerContext db) // Veritabanı bağlantısını tanımlıyoruz
        {
            _db = db;
        }
        public bool Create(T ent)
        {
            try
            {
                Set().Add(ent);         //  1.Yol
                                               //  _db.Entry(ent).State = EntityState.Added;           2.Yol
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
                //_db.Entry(ent).State = EntityState.deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int id)
        {
            return Set().Find(id);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public DbSet<T> Set() ///////////
        {
            return _db.Set<T>();
        }

        public bool Update(T ent)
        {
            try
            {
                Set().Update(ent);
                //_db.Entry(ent).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

              return false;
            }
        }
    }
}
