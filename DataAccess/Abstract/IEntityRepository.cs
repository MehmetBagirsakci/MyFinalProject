using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic Constraint: T'yi sınırlandırmalıyım.
    //Yani herkes istediği T yi yazamasın.
    //T olarak sadece veritabanı nesneleri yazılabilmeli
    //class() : Class olabilir demek değil. Referans tip olabilir demek.
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new()   : new'lenebilir olmalı. Unutma interface'ler newlenemez. 
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //filter=null filtre verebilirim de vermeyebilirim de.
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
