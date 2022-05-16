using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.UnitofWork
{
    public interface IUnitOfWork
    {
        ICategoriesRepos _catRepos { get; }
        IProductsRepos _proRepos { get; }
        ISuppliersRepos _suppRepos { get; }
        IUnitsRepos _unitRepos { get; }
        IEmployeesRepos _empRepos { get; }

        ICountiesRepos _countRepos { get; }

        ICustomersRepos _cusRepos { get; }
        ICitiesRepos _cityRepos { get; }

        IFatMasterRepos _fatmRepos { get; }


        IFatDetailRepos _fatdRepos { get; }

        IAuthRepos _authRepos { get; }

        IBasketMasterRepos _bmRepos { get; }

        IBasketDetailRepos _bdRepos { get; }


        void Commit();// SaveChanges()
        void Dispose(); // memory de bir şeyler varsa temizler ,anlamı öldürek 
    }
}
