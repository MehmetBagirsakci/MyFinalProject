using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Bu sınıf için global. Değişken ismi alt çizgi ile başlar.
        public InMemoryProductDal()
        {
            //Bu veriler sanki bir Oracle, Sql Server, Postgres, MongoDb veritabanında gelmiş gibi simüle ediyoruz.
            _products = new List<Product> {
                new Product { ProductId=1, CategoryId=1, ProductName = "Bardak", UnitPrice=15, UnitsInStock=15 },
                new Product { ProductId=2, CategoryId=1, ProductName = "Kamera", UnitPrice=500, UnitsInStock=3 },
                new Product { ProductId=3, CategoryId=2, ProductName = "Telefon", UnitPrice=1500, UnitsInStock=2 },
                new Product { ProductId=4, CategoryId=2, ProductName = "Klavye", UnitPrice=150, UnitsInStock=65 },
                new Product { ProductId=5, CategoryId=2, ProductName = "Fare", UnitPrice=85, UnitsInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //_products.Remove(product); bu şekilde çalışmaz.
            //Çünkü gelen product'ın bellekteki referansı  ile listedeki product'ın referansı farklı
           
            
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
            //SingleOrDefault(): foreach işleminin ta kendisidir.
            //SingleOrDefault(): Genelde Id arama işlemlerinde kullanırız. Çünkü Id tek kayıttır. Bu aramada 2 kayıt gelirse hata verir. 
            //SingleOrDefault alternatifi komutlar şunlardır. First(), FirstOrDefault()
        }

        public Product Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
