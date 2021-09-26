using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Dikkat edilirse EfProductDal, IProductDal'ı implemente etmiş. Ama metotlar yok.
    //EfProductDal, EfEntityRepositoryBase<TEntity,TContext> sınıfını miras almış.
    //EfEntityRepositoryBase<TEntity,TContext> sınıfı IEntityRepository<TEntity> interface'ini implemente etmiş
    //IProductDal'da IEntityRepository<TEntity> interface'ini implemente etmiş
    //Sonuç olarak IProductDal'ın istediği metotlar EfEntityRepositoryBase<TEntity,TContext> sınıfından miras yoluyla gelmiş
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
