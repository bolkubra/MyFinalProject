using Business.Abstract;
using Business.Constanst;
using Business.ValitadionRules.FluentValitadion;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
            //business kod
            //validation - doğrulama kod
            //if (product.ProductName.Length<2) // min 2 karakter
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            _ProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        
        public IDataResult< List<Product>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>( _ProductDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _ProductDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _ProductDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max)); // iki fiyat aralığında ki datayı getirir
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
           return new  SuccessDataResult<List<ProductDetailDto>>( _ProductDal.GetProductDetails());
        }
    }
}
