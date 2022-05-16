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
    public class CountiesRepos : BaseRepository<Counties>, ICountiesRepos
    {
        SirketContext _db;
        public CountiesRepos(SirketContext db) : base(db)
        {
            _db = db;
        }

       

        public List<CountiesList> GetCounties()
        {
            return Set().Select(x => new CountiesList
            {

                Id = x.Id,
                CountyName = x.CountyName,
                CityName = x.Cities.CityName,
                CityId = x.CityId



            }).ToList();
        }

        //public List<CountiesList> GetCounties(int id)
        //{
        //    return Set().Select(x => new CountiesList {

        //        Id = x.Id,
        //        CountyName = x.CountyName,
        //        CityName = x.Cities.CityName,
        //        CityId = x.CityId



        //    }).Where(x => x.CityId == id).ToList();
        //}

    }

}
