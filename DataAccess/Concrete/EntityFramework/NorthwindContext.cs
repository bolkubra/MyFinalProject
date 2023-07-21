using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // context : db tabloları ile proje classlarımızı bağlamak 
    public class NorthwindContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // hangi veritabanı ile çalışacağımızı burada belirteceğiz
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = master; Trusted_Connection = true");
        }
        public DbSet<Product> Products { get; set; } // benim hangi clasım hangi tabloya karşılık geliyor
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
