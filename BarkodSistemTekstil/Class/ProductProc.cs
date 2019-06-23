using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodSistemTekstil.Class
{
    
    class ProductProc
    {
        Model.BarcodeSystemDataContext Erisim = new Model.BarcodeSystemDataContext();
        public IQueryable UrunleriListele()
        {
            return from cat in Erisim.SubTboCategories
            join pro in Erisim.Product
            on cat.CategoryID equals pro.ProductCategorie
            where pro.ProductDelete == true
            orderby pro.ProductName
            select new
            {
                pro.ProductID,
                pro.ProductBarcode,
                pro.ProductName,
                cat.CategoryName,
                cat.CategoryID,
                pro.ProductSize,
                pro.ProductSalePrice,
                pro.ProductDescription,
            };
        }
    }
}
