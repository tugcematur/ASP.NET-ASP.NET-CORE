using KatmanliMimari.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Uow
{
    public interface IUnitOfWork
    {
        ICategoryRepos _catRepos { get; }
        IProductRepos _proRepos { get; }

        IAspNetRoleRepos _roleRepos { get; }

        IAspNetUserRepos _userRepos { get; }

        void Commit();

    }
}
