using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public IResult  Add(Product product)
        {
            _ProductDal.Add(product);
            return new SuccessResult();
        }

        public List<Product> GetAll()
        {
            //iş kodları
           return _ProductDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _ProductDal.GetAll(p=>p.CategoryId==id);
        }

        public Product GetById(int productId)
        {
            return _ProductDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max); // iki fiyat aralığında ki datayı getirir
        }

        public List<ProductDetailDto> GetProductDetails()
        {
           return _ProductDal.GetProductDetails();
        }
    }
}
