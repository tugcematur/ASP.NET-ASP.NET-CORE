using PersonelDbFirst.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelDbFirst.Connection
{//Devamlı memory de durması için(statik olması için)
    //Single tone yaklaşımı
    //İki ayrı işlem yaparken hangi connectşonı kullanacağını bilemediği için  tek bir connection tanımlamak daha iyi,performansı etkilemez.
    public static class DbSingleTone
    {
       static perdb2Entities db;

        public static  perdb2Entities GetConnection()
        {
            if (db==null)
            {
                db = new perdb2Entities();
            }

            return db;
        }
    }
}