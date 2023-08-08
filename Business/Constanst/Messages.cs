using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Business.Constanst
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductameAlreadyExists="Aynı isimde ürün bulunmaktadır";
        public static string CategoryLimitExceded = "Kategori Limiti Dolu olduğu için yeni ürün eklenemiyor";
    }
}
