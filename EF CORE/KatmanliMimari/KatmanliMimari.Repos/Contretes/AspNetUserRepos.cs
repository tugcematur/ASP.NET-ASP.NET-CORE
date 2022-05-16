using KatmanliMimari.Core;
using KatmanliMimari.Dal.Users;
using KatmanliMimari.DTO;
using KatmanliMimari.Repos.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Repos.Contretes
{
    public  class AspNetUserRepos : BaseRepository<AspNetUser>, IAspNetUserRepos
    {
        public AspNetUserRepos(KatmanliDbContext kdb) : base(kdb)
        {

        }

        public List<AspNetUser> GetUserList()
        {
            return Set().Include(x => x.Roles).ToList();  // AspNetUser.cs te Roles   Roles = new HashSet<AspNetRole>(); ve public virtual ICollection<AspNetRole> Roles { get; set; }
        } 

        public IQueryable<UserList> GetUsers()
        {
            return Set().Select(x=> new UserList { 
            
            Id = x.Id,
            UserName = x.UserName
            
            });
        }
    }
}
