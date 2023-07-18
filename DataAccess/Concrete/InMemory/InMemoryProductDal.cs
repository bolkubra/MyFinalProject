using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        
        List<Product> _products;
        public InMemoryProductDal() 
        {
            _products = new List<Product> {
            new Product {ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnıtsInStock=5 },
            new Product {ProductId=2, CategoryId=1, ProductName="Fincan", UnitPrice=35, UnıtsInStock=22 },
            new Product {ProductId=3, CategoryId=2, ProductName="Kamera", UnitPrice=1500, UnıtsInStock=18 },
            new Product {ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=300, UnıtsInStock=5 },
            new Product {ProductId=5, CategoryId=2, ProductName="Mouse", UnitPrice=115, UnıtsInStock=42 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            //LINQ -- language ıntegrated query
            //_products.Remove(product);//referanslar aynı olmadığı için SİLMEZ
            
            //foreach (var p in _products)
            //{
            //    if(product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); // productsı tek tek dolaşmayı sağlar 
            _products.Remove(productToDelete);
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
           return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
           Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductId= product.ProductId;
        }
    }
}
