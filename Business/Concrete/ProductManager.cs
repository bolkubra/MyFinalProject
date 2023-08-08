using Business.Abstract;
using Business.CCS;
using Business.Constanst;
using Business.ValitadionRules.FluentValitadion;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
        ILogger _logger;

        public ProductManager(IProductDal productDal, ILogger logger)
        {
            _ProductDal = productDal;
            _logger = logger;

        }
        //[ValidationAspect(typeof(ProductValidator))]
        public IResult  Add(Product product)
        {
            //business kod
            //validation - doğrulama kod
            //if (product.ProductName.Length<2) // min 2 karakter
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            _logger.Log();
            try
            {
                _ProductDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception exception)
            {

                _logger.Log();
            }
            return new ErrorResult();
           
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
