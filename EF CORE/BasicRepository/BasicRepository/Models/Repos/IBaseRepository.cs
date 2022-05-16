using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicRepository.Models.Repos
{
  public  interface IBaseRepository<T> where T: class
    {                                                          //Interface de erişim belirteçleri yazılmaz, class ta yazılır
        bool Update(T ent); //bu daha doğru ama (int id)  olabilir  
        bool Create(T ent); //boş göndermiyoruz çünkü Post u için lazım
        bool Delete(T ent); //bu daha doğru ama (int id)  olabilir

        T Find(int id);

        List<T> List();

        void Save();

        DbSet<T> Set();
    }
}
