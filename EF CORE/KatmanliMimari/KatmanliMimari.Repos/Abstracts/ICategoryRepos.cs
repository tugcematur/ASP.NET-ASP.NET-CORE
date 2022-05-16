using KatmanliMimari.Core;
using KatmanliMimari.Dal.Users;
using KatmanliMimari.DTO;
using KatmanliMimari.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Repos.Abstracts
{
    public interface ICategoryRepos : IBaseRepository<Category>
    {
        IQueryable<CategorySelect> GetCategory();
    }
}
