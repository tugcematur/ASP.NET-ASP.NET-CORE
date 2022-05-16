using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Interfaces
{
    public interface ICategoriesRepos : IBaseRepository<Categories>
    {
       List<CategoriesList> GetCategoriesName();
    
        
    }
}
