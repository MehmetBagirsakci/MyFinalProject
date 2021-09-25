using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Constructor injection
        //Bir iş sınıfı başka sınıfları new'lemez.

        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            //iş kodları (Ürün adı en az 2 karakter mi?.....)
            //if ler
            //Yetkisi var mı?
            return _productDal.GetAll();
        }
    }
}
