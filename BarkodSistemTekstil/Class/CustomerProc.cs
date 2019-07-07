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
        Customer cust = new Customer();
        /// <summary>
        /// Tüm Müşterileri Listele
        /// </summary>
        /// <returns></returns>
        public IQueryable MusteriListesi()
        {
            var q = (from cust in Erisim.Customer
                     orderby cust.CustomerName
                     select new
                     {
                         cust.CustomerID,
                         cust.CustomerName,
                         cust.CustomerSurname,
                         cust.CustomerTelephone,
                         cust.CustomerAddress,
                         cust.CustomerDetails,
                         cust.CustomerAccount,
                         cust.CustomerOccupotion,
                         cust.CustomerReference,
                         cust.CustomerRegistrationDate,
                         cust.SubTboRefCustomer.RefUserName,
                         cust.SubTboRefCustomer.RefUserSurname
                     }
                                      );
            return q;

        }
        /// <summary>
        /// Müşterileri Listele Lakin İsme Göre Listele
        /// </summary>
        /// <param name="adi">Müşteri ismini parametre olarak querye geçir Listelenecek</param>
        /// <returns></returns
        public IQueryable MusteriListesi(string adi)
        {

            IQueryable q = (from cust in Erisim.Customer
                            orderby cust.CustomerName
                            where cust.CustomerName.StartsWith(adi)
                            select new
                            {
                                cust.CustomerID,
                                cust.CustomerName,
                                cust.CustomerSurname,
                                cust.CustomerTelephone,
                                cust.CustomerAddress,
                                cust.CustomerDetails,
                                cust.CustomerAccount,
                                cust.CustomerOccupotion,
                                cust.CustomerReference,
                                cust.CustomerRegistrationDate,
                                cust.SubTboRefCustomer.RefUserName,
                                cust.SubTboRefCustomer.RefUserSurname
                            });
            return q;
        }
        /// <summary>
        /// Müşterileri Listele Lakin İsme Göre Listele
        /// </summary>
        /// <param name="adi">Müşteri ismini parametre olarak querye geçir Listelenecek</param>
        /// <param name="soyadi">Müşteri ismini ve soyismini parametre olarak querye geçir Listelenecek</param>
        /// <returns></returns>
        public IQueryable MusteriListesi(string adi, string soyadi)
        {
            var q = (from cust in Erisim.Customer
                     where cust.CustomerName.StartsWith(adi) && cust.CustomerSurname.StartsWith(soyadi)
                     orderby cust.CustomerName
                     select new
                     {
                         cust.CustomerID,
                         cust.CustomerName,
                         cust.CustomerSurname,
                         cust.CustomerTelephone,
                         cust.CustomerAddress,
                         cust.CustomerDetails,
                         cust.CustomerAccount,
                         cust.CustomerOccupotion,
                         cust.CustomerReference,
                         cust.CustomerRegistrationDate,
                         cust.SubTboRefCustomer.RefUserName,
                         cust.SubTboRefCustomer.RefUserSurname
                     });
            return q;

        }
        public List<Customer> MusteriListesiLinked()
        {
            List<Customer> musteriler = new List<Customer>();
            musteriler = (from cust in Erisim.Customer select cust).ToList();

            return musteriler;
        }
        public Customer MusteriIDyeGöreAra(int mID)
        {
            cust = (from q in Erisim.Customer
                    where q.CustomerID == mID
                    select q).First();
            return cust;

        }
        public SubTboRefCustomer ReferansAra(int refID)
        {
            var copycust = (from r in Erisim.SubTboRefCustomer
                            where r.RefUserID == refID
                            select

                                r).First();


            return copycust;

        }
        public Dictionary<int, string> ReferanslarListesi()
        {
            Dictionary<int, string> referanslar = new Dictionary<int, string>();
            var sorgu = from ReferansListe in Erisim.SubTboRefCustomer
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
        public int MusteriEkleProc(string musteriadi, string musterisoyadi, string telefon, string meslegi, int referans, string bakiye, string adres, string detay)
        {
            try
            {
                Customer cust = new Customer();
                cust.CustomerName = musteriadi;
                cust.CustomerSurname = musterisoyadi;
                cust.CustomerTelephone = telefon;
                cust.CustomerOccupotion = meslegi;
                cust.CustomerReference = (int)referans;
                cust.CustomerAccount = Convert.ToDecimal(bakiye);
                cust.CustomerAddress = adres;
                cust.CustomerDetails = detay;
                cust.CustomerRegistrationDate = DateTime.Now;
                Erisim.Customer.InsertOnSubmit(cust);
                Erisim.SubmitChanges();
                return 1;
            }
            catch (Exception e)
            {

                CustomMessage.CustomMsg.Message(e.Message.ToString(), "Hata", CustomMessage.CustomMsg.MessageIcon.Eror, CustomMessage.CustomMsg.MessageButton.OK);
                return -1;
            }


        }
        public int MusteriSil(Customer mus)
        {
            Erisim.Customer.DeleteOnSubmit(mus);
            Erisim.SubmitChanges();
            return 1;
        }
        public int MusteriDuzenle(Customer cust, SubTboRefCustomer copycust, string musteriadi, string musterisoyadi, string telefon, string meslegi, int refid, decimal bakiye, string adres, string detay)
        {
            try
            {
                cust.CustomerName = musteriadi;
                cust.CustomerSurname = musterisoyadi;
                cust.CustomerTelephone = telefon;
                cust.CustomerOccupotion = meslegi;
                cust.CustomerAddress = adres;
                cust.CustomerDetails = detay;
                cust.CustomerAccount = bakiye;
                cust.CustomerReference = refid;
                copycust.RefUserName = musteriadi;
                copycust.RefUserSurname = musterisoyadi;
                Erisim.SubmitChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }


        }

    }
}
