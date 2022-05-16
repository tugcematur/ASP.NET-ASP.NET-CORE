using AdvancedRepository.Core;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class BasketMasterRepos : BaseRepository<BasketMaster>, IBasketMasterRepos
    {
        SirketContext _db;
        public BasketMasterRepos(SirketContext db) : base(db)
        {
            _db = db;
        }
    }
}
