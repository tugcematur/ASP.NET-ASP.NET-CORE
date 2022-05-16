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
    public class UnitsRepos : BaseRepository<Units>, IUnitsRepos
    {
        SirketContext _db;
        public UnitsRepos(SirketContext db) : base(db)
        {
            _db = db;
        }

       
        public List<UnitsList> GetUnitsList()
        {
            var ulist = Set().Select(x => new UnitsList
            {
                Id = x.Id,
                UnitName = x.UnitName
            }).ToList();

            return (ulist);
        }
    }
}
