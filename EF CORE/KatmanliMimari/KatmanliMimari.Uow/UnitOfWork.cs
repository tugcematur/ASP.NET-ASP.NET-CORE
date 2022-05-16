using KatmanliMimari.Dal;
using KatmanliMimari.Dal.Users;
using KatmanliMimari.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private KatmanliDbContext _kdb; // private tanımlamak daha iyi

        public UnitOfWork(KatmanliDbContext kdb,ICategoryRepos catRepos, IProductRepos proRepos, IAspNetRoleRepos roleRepos, IAspNetUserRepos userRepos)
        {
            _catRepos = catRepos;
            _proRepos = proRepos;
            _userRepos= userRepos;  
            _roleRepos = roleRepos; 
            _kdb = kdb;
        }

        public ICategoryRepos _catRepos { get; private set; }
        public IProductRepos _proRepos { get; private set; }

        public IAspNetRoleRepos _roleRepos { get; private set; }

        public IAspNetUserRepos _userRepos { get; private set; }

        public void Commit()
        {
            _kdb.SaveChanges(); ;
        }
    }
}
