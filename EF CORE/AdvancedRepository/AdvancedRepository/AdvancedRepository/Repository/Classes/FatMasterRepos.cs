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
    public class FatMasterRepos : BaseRepository<FatMaster>, IFatMasterRepos
    {
        SirketContext _db;
        public FatMasterRepos(SirketContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<FatMasterList> GetFatMasterList()
        {

            return Set().Select(x => new FatMasterList
            {

                Id = x.Id,
                Date = x.Date,
                CompanyName = x.Customers.CompanyName
                


            }); 


        }



    }
}
