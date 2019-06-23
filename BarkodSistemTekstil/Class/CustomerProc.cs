using BarkodSistemTekstil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BarkodSistemTekstil.Class
{

    class CustomerProc
    {
        BarcodeSystemDataContext Erisim = new BarcodeSystemDataContext();
        /// <summary>
        /// Tüm Müşterileri Listele
        /// </summary>
        /// <returns></returns>
        public IQueryable MusteriListesi()
        {
            List<Customer> musteriListesi = new List<Customer>();
            return  from q in Erisim.Customer
                        select new
                        {
                            q.CustomerID,
                            q.CustomerName,
                            q.CustomerSurname,
                            q.CustomerAccount,
                            q.CustomerTelephone,
                            q.CustomerDetails,
                            q.CustomerAddress,
                            q.CustomerOccupotion,
                            q.CustomerRegistrationDate,
                            q.CustomerReference,
                            q.SubTboRefCustomer.RefUserName,
                            q.SubTboRefCustomer.RefUserSurname
                        };
           
        }
        /// <summary>
        /// Müşterileri Listele Lakin İsme Göre Listele
        /// </summary>
        /// <param name="adi">Müşteri ismini parametre olarak querye geçir Listelenecek</param>
        /// <returns></returns
        public IQueryable MusteriListesi(string adi)
        {
            return from cust in Erisim.Customer
                        orderby cust.CustomerName
                        where cust.CustomerName.StartsWith(adi)
                        select new
                        {
                            cust.CustomerID,
                            cust.CustomerName,
                            cust.CustomerSurname,
                            cust.CustomerTelephone,
                            cust.CustomerAddress,
                            cust.CustomerOccupotion,
                            cust.CustomerDetails,
                            cust.CustomerAccount,
                            cust.CustomerReference,
                            cust.CustomerRegistrationDate,
                            cust.SubTboRefCustomer.RefUserName,
                            cust.SubTboRefCustomer.RefUserSurname
                        };
        }
        /// <summary>
        /// Müşterileri Listele Lakin İsme Göre Listele
        /// </summary>
        /// <param name="adi">Müşteri ismini parametre olarak querye geçir Listelenecek</param>
        /// <param name="soyadi">Müşteri ismini ve soyismini parametre olarak querye geçir Listelenecek</param>
        /// <returns></returns>
        public IQueryable MusteriListesi(string adi, string soyadi)
        {
            List<Customer> musteriListesi = new List<Customer>();
           return  from cust in Erisim.Customer
                        orderby cust.CustomerName
                        where cust.CustomerName.StartsWith(adi) && cust.CustomerSurname.StartsWith(soyadi)
                        select new
                        {
                            cust.CustomerID,
                            cust.CustomerName,
                            cust.CustomerSurname,
                            cust.CustomerTelephone,
                            cust.CustomerAddress,
                            cust.CustomerOccupotion,
                            cust.CustomerDetails,
                            cust.CustomerAccount,
                            cust.CustomerReference,
                            cust.CustomerRegistrationDate,
                            cust.SubTboRefCustomer.RefUserID,
                            cust.SubTboRefCustomer.RefUserName,
                            cust.SubTboRefCustomer.RefUserSurname
                        };
            
        }
        public Dictionary<int,string> ReferanslarListesi()
        {
            Dictionary<int, string> referanslar = new Dictionary<int, string>();
            var sorgu=  from ReferansListe in Erisim.SubTboRefCustomer
                        select new
                        {
                            ReferansListe.RefUserID,
                            ReferansListe.RefUserName,
                            ReferansListe.RefUserSurname
                        };
            foreach (var item in sorgu)
            {
                referanslar.Add(item.RefUserID, item.RefUserName + " " + item.RefUserSurname);
            }
            return referanslar;
        }
        public int MusteriEkle(string musteriadi,string musterisoyadi,string telefon, string meslegi, )
    }
}
