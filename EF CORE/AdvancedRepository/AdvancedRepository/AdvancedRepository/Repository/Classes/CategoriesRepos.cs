using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class CategoriesRepos : BaseRepository<Categories> , ICategoriesRepos
    {
        SirketContext _db;
        public CategoriesRepos(SirketContext db) :base(db)
        {
            _db = db;
        }

        public List<CategoriesList> GetCategoriesName()
        {
            var clist = Set().Select(x => new CategoriesList
            {
                Id = x.Id,
                CategoryName = x.CategoryName
            }).ToList();

            return (clist);
        }

    }
}
