using KatmanliMimari.Core;
using KatmanliMimari.Dal.Users;
using KatmanliMimari.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Repos.Abstracts
{
    public interface IAspNetRoleRepos : IBaseRepository<AspNetRole>
    {
        IQueryable<RoleSelect> GetRole();
    }
}
