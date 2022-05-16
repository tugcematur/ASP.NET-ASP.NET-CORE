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
    public  interface IAspNetUserRepos : IBaseRepository<AspNetUser>
    {
        IQueryable<UserList> GetUsers();
        List<AspNetUser> GetUserList();
    }
}
