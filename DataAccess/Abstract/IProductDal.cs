using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //IProductDal: Benim Product ile ilgili veri tabanında yapacağım operasyonları içeren interface
    //Operasyonlar: Ekle, Sil, Güncelle, Listele, Filtrele vb..
    public interface IProductDal
    {
        List<Product> GetAll();
        Product Get();
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<Product> GetAllByCategory(int categoryId);
    }
}
