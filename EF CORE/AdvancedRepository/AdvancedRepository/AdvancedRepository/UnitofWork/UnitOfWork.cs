using AdvancedRepository.Models.Data;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.UnitofWork
{

 
    public class UnitOfWork : IUnitOfWork
    {
        SirketContext _db;
        

        public ICategoriesRepos _catRepos { get; private set; } //repository ile ilgili değişiklik yapmıyacağımız için private tanımladık

        public IProductsRepos _proRepos { get; private set; }

        public IUnitsRepos _unitRepos { get; private set; }

        public ISuppliersRepos _suppRepos { get; private set; }

        public IEmployeesRepos _empRepos { get; private set; }

        public ICountiesRepos _countRepos { get; private set; }

        public ICustomersRepos _cusRepos { get; private set; }

        public ICitiesRepos _cityRepos { get; private set; }

        public IFatMasterRepos _fatmRepos { get; private set; }

        public IFatDetailRepos _fatdRepos { get; private set; }

        public IAuthRepos _authRepos { get; private set; }

        public IBasketMasterRepos _bmRepos { get; private set; }

        public IBasketDetailRepos _bdRepos { get; private set; }

        public UnitOfWork(SirketContext db,ICategoriesRepos catRepos, IProductsRepos proRepos,IUnitsRepos unitRepos, ISuppliersRepos suppRepos,IEmployeesRepos empRepos, ICountiesRepos countRepos , ICustomersRepos cusRepos, ICitiesRepos cityRepos, IFatMasterRepos fatmRepos,IFatDetailRepos fatdRepos, IAuthRepos authRepos,IBasketMasterRepos bmRepos,IBasketDetailRepos bdRepos)
        {
            _db = db;
            _catRepos = catRepos;
            _proRepos = proRepos;
            _unitRepos = unitRepos;
            _suppRepos = suppRepos;  // new SuppliersRepos(db) -> Startupta new lemek yerine burada newleyebiliriz ama iyi bir yöntem değil.
            _empRepos = empRepos;
            _countRepos = countRepos;
            _cusRepos = cusRepos;
            _cityRepos = cityRepos;
            _fatmRepos = fatmRepos;
            _fatdRepos = fatdRepos;
            _authRepos = authRepos;
            _bmRepos = bmRepos;
            _bdRepos = bdRepos;
           
        }
     

        public void Commit()    // aynı Fatura Tarihine sahip aynı üründen bir kayıt daha olamaz, bunlara dikkat et.
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose(); 
        }
    }
}
