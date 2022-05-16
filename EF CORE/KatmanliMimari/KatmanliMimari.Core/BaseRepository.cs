using KatmanliMimari.Dal;
using KatmanliMimari.Dal.Users;
//using KatmanliMimari.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        KatmanliDbContext _kdb;
        public BaseRepository(KatmanliDbContext kdb) 
        {

            _kdb = kdb;
        }

        public bool Create(T ent)
        {
            try
            {
                Set().Add(ent);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public T Find(int id)//altını yeşil çizerse silent yap.
        {
            return Set().Find(id);

        }

        public T Find(int key1, int key2)
        {
            return Set().Find(key1, key2);

        }

        public T Find(string id)
        {
            return Set().Find(id);
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Qry()
        {
            return Set().AsQueryable();

        }
        public DbSet<T> Set()
        {
            return _kdb.Set<T>();
        }

        public bool Update(T ent)
        {
            try
            {
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
