using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //IProductDal: Benim Product ile ilgili veri tabanında yapacağım operasyonları içeren interface
    //Operasyonlar: Ekle, Sil, Güncelle, Listele, Filtrele vb..
    public interface IProductDal:IEntityRepository<Product>
    {

    }
}
