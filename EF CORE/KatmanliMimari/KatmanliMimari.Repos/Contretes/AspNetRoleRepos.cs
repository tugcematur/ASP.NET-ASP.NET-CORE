using KatmanliMimari.Core;
using KatmanliMimari.Dal.Users;
using KatmanliMimari.DTO;
using KatmanliMimari.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Repos.Contretes
{
   public  class AspNetRoleRepos : BaseRepository<AspNetRole>, IAspNetRoleRepos
    {
        public AspNetRoleRepos(KatmanliDbContext kdb) : base(kdb)
        {

        }

        public IQueryable<RoleSelect> GetRole()
        {
            return Set().Select(x=> new RoleSelect { 
            
             Id = x.Id,
           Name = x.Name
            
            });
        }
    }
}
