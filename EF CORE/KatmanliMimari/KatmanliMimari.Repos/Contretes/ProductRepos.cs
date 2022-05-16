using KatmanliMimari.Core;
using KatmanliMimari.Dal.Users;
using KatmanliMimari.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimari.Repos.Contretes
{
    public  class ProductRepos : BaseRepository<Product>, IProductRepos
    {
        KatmanliDbContext _kdb;

        public ProductRepos(KatmanliDbContext kdb) : base(kdb)
        {
            _kdb = kdb;
        }
    }
}
