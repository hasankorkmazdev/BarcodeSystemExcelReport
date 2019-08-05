using BarkodSistemTekstil.Model;
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
        Product proc;
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
        public IQueryable UrunleriListele(string Barkod)
        {
            var ara = (from q in Erisim.Product
                       where q.ProductBarcode == Barkod && q.ProductDelete == false
                       select q);

            if (ara.Equals(null))
            {
                return null;
            }
            else
            {
                return ara;
            }
        }
        public Model.Product UrunAra(string barkod)
        {
            var ara = (from q in Erisim.Product
                       where q.ProductBarcode == barkod && q.ProductDelete == false
                       select q).FirstOrDefault();

            if (ara.Equals(null))
            {
                return null;
            }
            else
            {
                return (Model.Product)ara;
            }

        }
        public int UrunEkle(string Barkod, string name, int kategoriIDs, string descriptioni, double satisfiyat)
        {
            //Geri Dönüş Değeri 1 ise İşlem Başarılı bir şekilde gerçekleştirimiştir
            //-1 ise Veritabanına Girişte Hata vardır
            //-2 ise Ürün Zaten Veritabanında mevcut

            //Ürün Veritabanında Var
            if ( !(UrunAra(Barkod)==null))
            {
                return -2;
            }
          
          //Ürün Veritabanında yok ekle   
            proc = new Product()
            {
                ProductBarcode = Barkod,
                ProductName = name,
                ProductCategorie = kategoriIDs,
                ProductDescription = descriptioni,
                ProductSalePrice = satisfiyat,
                ProductDelete = false
                };
                Erisim.Product.InsertOnSubmit(proc);
                Erisim.SubmitChanges();
                return 1;
        }
        public int UrunDuzenle(string Barkod, string name, int kategoriIDs, string descriptioni, double satisfiyat)
        {

            try
            {
                if (!UrunAra(Barkod).Equals(null))
                {
                    proc = UrunAra(Barkod);
                    proc.ProductName = name;
                    proc.ProductBarcode = Barkod;
                    proc.ProductCategorie = kategoriIDs;
                    proc.ProductDescription = descriptioni;
                    proc.ProductSalePrice = satisfiyat;
                    Erisim.SubmitChanges();

                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            catch (Exception)
            {
                return -1;
                throw;

            }
        }
        public int UrunSil(string Barkod)
        {
            try
            {
                proc = UrunAra(Barkod);
                proc.ProductDelete = true;
                Erisim.SubmitChanges();
                return 1;

            }
            catch (Exception)
            {
                return -1;
                throw;
            }


        }
        public IQueryable KategoriListesi()
        {
            return Erisim.SubTboCategories;
        }
    }

}
