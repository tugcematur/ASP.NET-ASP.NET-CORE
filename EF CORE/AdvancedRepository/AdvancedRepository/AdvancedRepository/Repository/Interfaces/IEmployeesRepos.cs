using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Interfaces
{
    public interface IEmployeesRepos : IBaseRepository<Employees>
    {
        List<EmployeesList> GetEmployeesList();

        string GetTitle(int id);
        int GetAge(int id);
        string FullName(int id);
        List<ManagersList> GetManagersList();

        EmployeeDetails GetEmployeeDetails(int id);
    }
}
