using AdvancedRepository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
     abstract public class Base : ITable   // abstract tanımladık base class olduğu için
    {
        //public Base()     //BaseRepository oluşturunca eklicez.
        //{
        //    LastUpdated = DateTime.Now;

        //}
        //Properties ler implemente edildi

        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set ; }
        public DateTime LastUpdated { get; set ; }
        public string WhoUpdated { get;  set ; }
     
    }
}
