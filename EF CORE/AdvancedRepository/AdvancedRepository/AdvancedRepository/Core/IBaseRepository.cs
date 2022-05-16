using AdvancedRepository.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Core
{
  
        public interface IBaseRepository<T> where T : class
        {
            bool Update(T ent); 
            bool Create(T ent); 
            bool Delete(T ent); 
            T Find(int id);

         //   List<T> List();

            //void Save();  // Commit ten dolayı kaldırdık
            DbSet<T> Set();

            IQueryable<T> Query();


        T Find(int Id,int pId);

        }
    }
