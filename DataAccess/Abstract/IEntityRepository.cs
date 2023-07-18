using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class,IEntity
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // ürün listeleme // Expression - filnet null demek filtre de vermeyebilirsin tüm datayı getir

        T Get(Expression<Func<T, bool>> filter ); // tek bir filtreleme yaparsak filter zorunlu olur

        void Add(T entity); // ürün ekleme
        void Update(T entity); // ürün güncelleme
        void Delete(T entity); // ürün silme

        //List<T> GetAllByCategory(int categoryId); // kategoriye göre ürün listeleme Expression kullanınca buna ihtiyaç kalmıyor
    }
}
