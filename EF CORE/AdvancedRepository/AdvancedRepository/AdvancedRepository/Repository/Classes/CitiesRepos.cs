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
    public class CitiesRepos : BaseRepository<Cities> , ICitiesRepos
    {
        SirketContext _db;

        public CitiesRepos(SirketContext db) : base(db)
        {
            _db = db;
        }

        public List<CitiesList> GetCities()
        {
            return Set().Select(x => new CitiesList
            {

                Id = x.Id,
                CityName = x.CityName

            }).ToList();
        }
    }
}
