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
    public class EmployeesRepos : BaseRepository<Employees>, IEmployeesRepos
    {
        SirketContext _db;
        public EmployeesRepos(SirketContext db) : base(db)
        {
            _db = db;
        }

        public string FullName(int id)
        {
            Employees emp = Find(id);
            return emp.Firstname + " " + emp.Lastname;
        }

        public int GetAge(int id)
        {
            Employees emp = Find(id);

            var today = DateTime.Now;
            var age = today.Year - emp.DateOfBirth.Year;
            var BirthDay = emp.DateOfBirth.AddYears(age);                      //12.08.1996

            if (BirthDay > today)
            {
                age++;
            }

            return age;
        }

        public EmployeeDetails GetEmployeeDetails(int id)
        {
           EmployeeDetails employeeDetails = new EmployeeDetails();
            // var emp = Find(id);
            //employeeDetails.FullName = emp.Firstname + emp.Lastname;
            employeeDetails.Id = id;
            employeeDetails.FullName = FullName(id);
            employeeDetails.Salary = GetSalary(id);
            employeeDetails.Header = $"{GetTitle(id)} {GetAge(id)}";
            return employeeDetails;
        }

        public List<EmployeesList> GetEmployeesList()
        {
            return Set().Select(x => new EmployeesList
            {
                Id = x.Id,
                FullName = x.Firstname + " " + x.Lastname,   /*FullName(x.Id),*/
                ManagerName = x.Manager.Firstname + " " + x.Manager.Lastname,  // Kendi kendine inner join yaptık     Select ManagerName from Employees e inner join Employees m (m.Id == e.ManagerId)
                Salary = x.Salary


            }).ToList();
        }

        public List<ManagersList> GetManagersList()
        {
            return Set().Select(x => new ManagersList
            {
                 Id = x.Id,
                 Fullname = x.Firstname + " " + x.Lastname,
                 IsManager = x.IsManager

            }).Where(x=>x.IsManager== true).ToList();
        }

        public string GetTitle(int id)
        {
            Employees emp = Find(id);
            if (emp.Gender == 'E')
            {
                return "Sn Bay " + " " + emp.Firstname + " " + emp.Lastname;
            }

            else
            {

                return "Sayın Bayan" +" " + emp.Firstname + " " + emp.Lastname;


            }

           
        }

        public decimal GetSalary(int id)
        {
            Employees emp = Find(id);
            return emp.Salary;

        }
    }
}
