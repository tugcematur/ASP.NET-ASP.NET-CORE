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
    public class CategoryRepos : BaseRepository<Category>, ICategoryRepos
    {
        KatmanliDbContext _kdb;
        public CategoryRepos(KatmanliDbContext kdb) : base(kdb)
        {
            _kdb = kdb;
        }

        public IQueryable<CategorySelect> GetCategory()
        {
            return Set().Select(x=> new CategorySelect {
            
            Id = x.Id,
            CategoryName = x.CategoryName
            
            });
        }
    }
}
