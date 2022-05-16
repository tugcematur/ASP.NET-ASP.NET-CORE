using AdvancedRepository.Core;
using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.Data;
using AdvancedRepository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Repository.Classes
{
    public class ProductsRepos : BaseRepository<Products>, IProductsRepos 
    {
        SirketContext _db;
        public ProductsRepos(SirketContext db) : base(db) //Miras aldığı class tandan dbsinin miras alınıp constructor da tanımlanması gerekiyor
        {
            _db = db;
        }

        public List<ProductsList> GetProductList()
        {
          return   Set().Select(x => new ProductsList
            {
                Id = x.Id,
                ProductName = x.ProductName,
                CategoryName = x.Categories.CategoryName,
                CompanyName = x.Suppliers.CompanyName,
                ProductImage = x.ProductImage

            }).ToList();
        }

        public List<ProductsList> GetProductsName(int id)
        {
            return Set().Select(x => new ProductsList
            {
                Id = x.Id,
                ProductName = x.ProductName,
                CategoryName = x.Categories.CategoryName,
                CompanyName = x.Suppliers.CompanyName,
                CategoryId = x.CategoryId
                
                
                
             

            }).Where(x=>x.CategoryId==id).ToList();
        }

        public List<ProductsSelect> GetProductsSelect()
        {
            return Set().Select(x => new ProductsSelect
            {
                Id = x.Id,
                ProductName = x.ProductName,
            

            }).ToList();
        }

    
    }
}
