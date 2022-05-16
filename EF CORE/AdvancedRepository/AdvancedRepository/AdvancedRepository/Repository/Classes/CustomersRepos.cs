using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class CustomersRepos : BaseRepository<Customers>, ICustomersRepos
    {
        SirketContext _db;

        public CustomersRepos(SirketContext db) : base(db)
        {
            _db = db;
        }



        public List<CustomerSelect> GetCustomerSelect()
        {

           return  Set().Select(x => new CustomerSelect { 
            
            Id = x.Id,
            CompanyName = x.CompanyName
            
            }).ToList();

        }

        public List<CustomersList> GetCustomersList()
        {
            return Set().Select(x => new CustomersList
            {

                Id = x.Id,
                Rating = x.Rating,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName



            }).ToList();
        }
    }
}
