using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {

        //// buarsı Iproductdal ile aynı sadece product olan yerleri category olarak değiştirirsek olur ama bunu generics
        //List<Category> GetAll(); // ürün listeleme
        //void Add(Category category); // ürün ekleme
        //void Update(Category category); // ürün güncelleme
        //void Delete(Category category); // ürün silme

        //List<Category> GetAllByCategory(int categoryId); // kategoriye göre ürün listeleme
    }
}
