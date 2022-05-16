using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Interfaces
{
    public  interface ICustomersRepos :IBaseRepository<Customers>
    {
        List<CustomersList> GetCustomersList();
        List<CustomerSelect> GetCustomerSelect();

    }
}
