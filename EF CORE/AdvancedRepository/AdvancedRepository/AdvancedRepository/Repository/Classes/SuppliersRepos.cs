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
    public class SuppliersRepos : BaseRepository<Suppliers>, ISuppliersRepos
    {
        SirketContext _db;
        public SuppliersRepos(SirketContext db) : base(db)
        {
            _db = db;
        }

        public List<SuppliersList> GetSuppliersList()
        {
            var slist = Set().Select(x => new SuppliersList
            {
                Id = x.Id,
                CompanyName = x.CompanyName
            }).ToList();

            return (slist);
        }


     
    }
}
