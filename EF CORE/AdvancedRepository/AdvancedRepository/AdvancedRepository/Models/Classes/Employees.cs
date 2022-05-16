using AdvancedRepository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Models.Classes
{
    public class Employees : Base, IAdress
    {
        public Employees()
        {
            Products = new HashSet<Products>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public char Gender { get; set; }
        public decimal Salary { get; set; }
        public int? ManagerId { get; set; }
        public bool IsManager { get; set; }
        public string Street { get; set; }
        public string Avenue { get; set; }
        public int CountyId { get; set; }
        //public int CityId { get; set; }
        public int OutDoorNumber { get; set; }
        public int PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }  //Burada tanımlamak daha doğru, sadece Employees için olduğundan
        [ForeignKey("ManagerId")]
        public Employees Manager { get; set; } // Aynı classta olduğu için public Employees Employees { get; set; } olarak tanımlayamıyoruz.
        [ForeignKey("CountyId")]
        public Counties County { get; set; }


        public ICollection<Products> Products { get; set; }

        //  public List<Employees> Managers { get; set; } // Bir Manager ın altında kaç çalışan var ,Buil failed hatası verdi

        //public List<string> GetAdress()                Burada şuan tanımmlayamayız
        //{
        //    List<string> alist = new List<string>();
        //    alist.Add(Street);
        //    alist.Add(Avenue);
        //    alist.Add(OutDoorNumber.ToString());
        //    alist.Add($"{CountyId} - {CityId}");
        //    return alist;
        //}

        //public string GetTitle()
        //{
        //    if (Gender == 'E')
        //    {
        //        return $"Sayın Bay {Firstname} {Lastname}";
        //    }
        //    else
        //    {
        //        return $"Sayın Bayan {Firstname} {Lastname}";
        //    }
        //}

        //public int GetAge()
        //{



        //    var today = DateTime.Now;
        //    var age = today.Year - DateOfBirth.Year;
        //    var BirthDay = DateOfBirth.AddYears(age);                      //12.08.1996

        //    if (BirthDay>today)
        //    {
        //        age++;
        //    }

        //    return age;

        //}
    }
}
