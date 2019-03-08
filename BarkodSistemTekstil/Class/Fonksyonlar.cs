using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Class
{
    class Fonksyonlar
    {
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
       
        Dictionary<int, string> referanslar = new Dictionary<int, string>();
        /// <summary>
        /// Customer Kopyaları Dictionary'e Dolduruluyor
        /// </summary>
         public Fonksyonlar()
        {
            var sorgu = from custrefCopya in data.SubTboRefCustomer
                        select new
                        {
                            custrefCopya.RefUserID,
                            custrefCopya.RefUserName,
                            custrefCopya.RefUserSurname
                        };
            foreach (var item in sorgu)
            {
                referanslar.Add(item.RefUserID, item.RefUserName + " " + item.RefUserSurname);
            }
        }
        /// <summary>
        /// Gönderilen Combobox'ın DisplayMember Ve ValueMemberlari Ayarlanıp  Dictionaryideki Veriler Combobox'a Dolduruluyor
        /// </summary>
        /// <param name="cmbCustomerRefrence">Doldurulacak Combobox Öğesi</param>
        /// <returns>Combobox Tipinde Geri Dönüş Yapılır </returns>
        public ComboBox cmboboxReferansDoldur(ComboBox cmbCustomerRefrence)
        {
            cmbCustomerRefrence.DataSource = new BindingSource(referanslar, null);
            cmbCustomerRefrence.DisplayMember = "Value";
            cmbCustomerRefrence.ValueMember = "Key";
            return cmbCustomerRefrence;

        }
        ///<summary>
        /// ReferansID Yollayiniz Referans Araması Yapılacak Eğer Referansı Bulursa Adini Soyadini Yollayacak Bulamaz ise -1
        /// </summary>
        /// <param name="refID">Aranacak Referans ID si</param>
        /// <returns>String Öğe Döner</returns>
        public string ReferansAra(int refID)
        {
            bool ReferansVarmi = false;
            string ArananReferansınAdiSoyadi;
            ReferansVarmi =referanslar.TryGetValue(refID, out ArananReferansınAdiSoyadi);
            if (ReferansVarmi == false)
            {
                MessageBox.Show("Böyle Bir Referans Bulunamadi");
                return "-1";
            }
            else
            {
                return ArananReferansınAdiSoyadi;
            }
        }
        public void CustomerRefresh(DataGridView DGV)
        {
            var query = from q in data.Customer
                        select new {
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
            DGV.DataSource = query; ;                            
            //Runtime Sırasında Yeni Satır Ekleme
            DGV.AllowUserToAddRows = false;
            //Seçim Şekli--> Tam Satır Hali 
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Kolon Başlıklarını
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            DGV.Columns["CustomerName"].HeaderText = "Müsteri Adi";
            DGV.Columns["CustomerSurname"].HeaderText = "Müsteri Soyadi";
            DGV.Columns["CustomerAccount"].HeaderText = "Müsterinin Bakiyesi";
            DGV.Columns["CustomerTelephone"].HeaderText = "Müsterinin Telefonu";
            DGV.Columns["CustomerDetails"].HeaderText = "Müsterinin Detaylari";
            DGV.Columns["CustomerAddress"].HeaderText = "Müsterinin Adresi";
            DGV.Columns["CustomerOccupotion"].HeaderText = "Müsterinin Mesleği";
            DGV.Columns["CustomerReference"].HeaderText = "Müsterinin Referansının ID'si";
            DGV.Columns["CustomerRegistrationDate"].HeaderText = "Müsterinin KayıtTarihi";
            DGV.Columns["RefUserName"].HeaderText = "Müsterinin Referansının Adi";
            DGV.Columns["RefUserSurname"].HeaderText = "Müsterinin Referansının Soyadi";
            DGV.Columns["CustomerID"].Visible = false;
            DGV.Columns["CustomerReference"].Visible = false;






        }
        public void CustomerAra(DataGridView DGV,string adi)
        {
            DGV.DataSource = from cust in data.Customer
                         
                             orderby cust.CustomerName where cust.CustomerName.StartsWith(adi) 
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

            //Runtime Sırasında Yeni Satır Ekleme
            DGV.AllowUserToAddRows = false;
            //Seçim Şekli--> Tam Satır Hali 
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Kolon Başlıklarını
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            DGV.Columns["CustomerName"].HeaderText = "Müsteri Adi";
            DGV.Columns["CustomerSurname"].HeaderText = "Müsteri Soyadi";
            DGV.Columns["CustomerAccount"].HeaderText = "Müsterinin Bakiyesi";
            DGV.Columns["CustomerTelephone"].HeaderText = "Müsterinin Telefonu";
            DGV.Columns["CustomerDetails"].HeaderText = "Müsterinin Detaylari";
            DGV.Columns["CustomerAddress"].HeaderText = "Müsterinin Adresi";
            DGV.Columns["CustomerOccupotion"].HeaderText = "Müsterinin Mesleği";
            DGV.Columns["CustomerReference"].HeaderText = "Müsterinin Referansının ID'si";
            DGV.Columns["CustomerRegistrationDate"].HeaderText = "Müsterinin KayıtTarihi";
            DGV.Columns["RefUserName"].HeaderText = "Müsterinin Referansının Adi";
            DGV.Columns["RefUserSurname"].HeaderText = "Müsterinin Referansının Soyadi";
            DGV.Columns["CustomerID"].Visible = false;
            DGV.Columns["CustomerReference"].Visible = false;


        }
        public void CustomerAra(DataGridView DGV, string adi,string soyadi)
        {
            DGV.DataSource = from cust in data.Customer
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
                                 cust.SubTboRefCustomer.RefUserName,
                                 cust.SubTboRefCustomer.RefUserSurname
                             };

            //Runtime Sırasında Yeni Satır Ekleme
            DGV.AllowUserToAddRows = false;
            //Seçim Şekli--> Tam Satır Hali 
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Kolon Başlıklarını
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            DGV.Columns["CustomerName"].HeaderText = "Müsteri Adi";
            DGV.Columns["CustomerSurname"].HeaderText = "Müsteri Soyadi";
            DGV.Columns["CustomerAccount"].HeaderText = "Müsterinin Bakiyesi";
            DGV.Columns["CustomerTelephone"].HeaderText = "Müsterinin Telefonu";
            DGV.Columns["CustomerDetails"].HeaderText = "Müsterinin Detaylari";
            DGV.Columns["CustomerAddress"].HeaderText = "Müsterinin Adresi";
            DGV.Columns["CustomerOccupotion"].HeaderText = "Müsterinin Mesleği";
            DGV.Columns["CustomerReference"].HeaderText = "Müsterinin Referansının ID'si";
            DGV.Columns["CustomerRegistrationDate"].HeaderText = "Müsterinin KayıtTarihi";
            DGV.Columns["RefUserName"].HeaderText = "Müsterinin Referansının Adi";
            DGV.Columns["RefUserSurname"].HeaderText = "Müsterinin Referansının Soyadi";
            DGV.Columns["CustomerID"].Visible = false;
            DGV.Columns["CustomerReference"].Visible = false;


        }
        public void productRefresh(DataGridView DGV)
        {
            DGV.DataSource =from cat in data.SubTboCategories
                                 join pro in data.Product
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
            DGV.Columns["ProductID"].Visible = false;
            DGV.Columns["ProductBarcode"].HeaderText = "ÜrünBarkodu";
            DGV.Columns["ProductName"].HeaderText = "ÜrününAdı";
            DGV.Columns["CategoryName"].HeaderText = "Kategori";
            DGV.Columns["ProductSize"].HeaderText = "Beden";
            DGV.Columns["ProductSalePrice"].HeaderText = "SatışFiyatı";
            DGV.Columns["ProductDescription"].HeaderText = "ÜrünDetayı";
            DGV.Columns["CategoryID"].Visible = false;

        }
        
   


    }
}
