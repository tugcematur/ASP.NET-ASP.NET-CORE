using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using AdvancedRepository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class FatDetailRepos : BaseRepository<FatDetail>, IFatDetailRepos
    {
        SirketContext _db;
        public FatDetailRepos(SirketContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<FatDetailList> GetFatDetailList(int id)
        {
            var list = Query();
            list = list.Where(x => x.Id == id);


           return list.Select(x => new FatDetailList // IQueryable<FatDetailList>   //Yeni bir liste oluşturduk.
            {
                ProductId = x.ProductId,
                ProductName = x.Product.ProductName,
                ProductImage = x.Product.ProductImage,
                Amount = x.Amount,
                UnitPrice = x.UnitPrice,
                Total = x.UnitPrice * x.Amount,
                Id = id

            });

       




            //return Set().Select(x => new FatDetailList
            //{

            //    Id = x.Id,
            //    ProductId = x.ProductId,
            //    ProductName = x.Product.ProductName,
            //    ProductImage = x.Product.ProductImage,
            //    UnitPrice = x.UnitPrice,
            //    Amount = x.Amount,
            //    Total = x.Amount * x.UnitPrice

            //}).Where(x => x.Id == id).ToList();
        }

        public string Total(IQueryable<FatDetailList> fd)
        {
            decimal Total = fd.Sum(x => x.Amount * x.UnitPrice);
            int Count = fd.Count();

            return $" Number of Product together with total amount of {Count}   Invoice Total: {Total} ";
        }
    }
}
