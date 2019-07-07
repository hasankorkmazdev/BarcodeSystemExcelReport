using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;




namespace BarkodSistemTekstil.Ui
{
    public partial class SalePage : UserControl
    {
        public SalePage()
        {
            InitializeComponent();
           
        }
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        int datagridviewID = 1;
        DataGridViewRow selectedrow;
        DataGridViewRow[] waitlist;
        decimal totalPrice = 0;
        decimal totalDiscount = 0;
        decimal productDiscount = 0;
        bool totaleindirimyapildimi = false;
        bool beklemedeurunvarmi = false;
        decimal waitTotalDiscount;

        private void SalePage_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Add("ListID", "Sıra");
            dataGridView1.Columns.Add("ProductID", "Ürün Numarası");
            dataGridView1.Columns.Add("ProductBarcode", "Barkod");
            dataGridView1.Columns.Add("ProductName", "Ürün Adı");
            dataGridView1.Columns.Add("ProductCategorie", "Kategori");
            dataGridView1.Columns.Add("ProductSize", "Beden");
            dataGridView1.Columns.Add("ProductSalePrice", "Satış Fiyatı");
            dataGridView1.Columns.Add("ProductDiscount", "Ürün İskontosu");
            dataGridView1.Columns.Add("ProductDetails", "Ürün Detayı");
            dataGridView1.Columns["ProductID"].Visible = false;
            btnWaitListReturn.Visible = false;
            txtBarcodeSearch.Focus();
         
        }
        //Buttons Event
        private void btnNakit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Model.Sale satis = new Model.Sale();
                satis.SaleDate = DateTime.Now.Date;
                satis.PaymentMethodSale = 1;
                satis.TotalPrice = totalPrice;
                satis.TotalDiscount = Convert.ToDecimal(totalDiscount);
                data.Sale.InsertOnSubmit(satis);
                data.SubmitChanges();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {//TODO:Ürün Stokta Varmı Yokmu Kontrol Edilecek++

                    Model.BarcodeSystemDataContext pdata = new Model.BarcodeSystemDataContext();
                    Model.OpeationProduct satilanurunler = new Model.OpeationProduct();
                    satilanurunler.SaleProduct = (from q in data.Sale
                                                  orderby q.SaleID descending
                                                  select q).First().SaleID;
                    satilanurunler.ProductID = (int)(row.Cells["ProductID"].Value);
                    satilanurunler.ProductDiscount = Convert.ToDecimal(row.Cells["ProductDiscount"].Value);
                    satilanurunler.ProductPrice = Convert.ToDecimal((row.Cells["ProductSalePrice"].Value.ToString().Split(' ')[0]));
                    pdata.OpeationProduct.InsertOnSubmit(satilanurunler);
                    pdata.SubmitChanges();
                    totalDiscount = 0;
                    totalPrice = 0;
                    productDiscount = 0;
                    lblName.Text = "Ürün Adı : null";
                    lblPrice.Text = "Ürün Fiyat : null";
                    lblTotal.Text = "Toplam Fiyat : null";
                }
                datagridviewID = 1;
                dataGridView1.Rows.Clear();
                MessageDöndür.Message("Satış İşlemi başarıyla Gerçekleştirildi.", "İşlem Onaylandı", MessageDöndür.MessageIcon.OK, MessageDöndür.MessageButton.OK);
            }
            else
            {
                MessageDöndür.Message("Listede Ürün Yok Satış İşlemi Gerçekleştirilemiyor.", "Satış işlemi İptal Edildi", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            }
        private void btnKredi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                Model.Sale satis = new Model.Sale();
                satis.SaleDate = DateTime.Now.Date;
                satis.PaymentMethodSale = 2;
                satis.TotalPrice = totalPrice;
                satis.TotalDiscount = Convert.ToDecimal(totalDiscount);
                data.Sale.InsertOnSubmit(satis);
                data.SubmitChanges();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {//TODO:Ürün Stokta Varmı Yokmu Kontrol Edilecek++

                    Model.BarcodeSystemDataContext pdata = new Model.BarcodeSystemDataContext();
                    Model.OpeationProduct satilanurunler = new Model.OpeationProduct();
                    satilanurunler.SaleProduct = (from q in data.Sale
                                                  orderby q.SaleID descending
                                                  select q).First().SaleID;
                    satilanurunler.ProductID = (int)(row.Cells["ProductID"].Value);
                    satilanurunler.ProductDiscount = Convert.ToDecimal(row.Cells["ProductDiscount"].Value);
                    satilanurunler.ProductPrice = Convert.ToDecimal((row.Cells["ProductSalePrice"].Value.ToString().Split(' ')[0]));
                    pdata.OpeationProduct.InsertOnSubmit(satilanurunler);
                    pdata.SubmitChanges();
                    totalDiscount = 0;
                    totalPrice = 0;
                    productDiscount = 0;
                    lblName.Text = "Ürün Adı : null";
                    lblPrice.Text = "Ürün Fiyat : null";
                    lblTotal.Text = "Toplam Fiyat : null";
                }
                datagridviewID = 1;
                dataGridView1.Rows.Clear();
                MessageDöndür.Message("Satış İşlemi başarıyla Gerçekleştirildi.", "İşlem Onaylandı", MessageDöndür.MessageIcon.OK, MessageDöndür.MessageButton.OK);
            }
            else
            {
                MessageDöndür.Message("Listede Ürün Yok Satış İşlemi Gerçekleştirilemiyor.", "Satış işlemi İptal Edildi", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
        }
        private void registeredCustomer_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.Rows.Count<=0))
            {
                int customerID = SelectCustomer.Show();
                
                if (!(customerID==-1))
                {
                    var query = (from q in data.Customer
                                 where q.CustomerID == customerID
                                 select q).First();
                    MessageDöndür.MessageResult messageResult= MessageDöndür.Message("Müsteri :" + query.CustomerName + " " + query.CustomerSurname+"\nAdlı Müşteriye "+totalPrice+" TL Tutarında işlem Yapmayı Onaylıyormusunuz","Satış Onayı",MessageDöndür.MessageIcon.Information,MessageDöndür.MessageButton.YesNoCancel);
                    if (MessageDöndür.MessageResult.Yes==messageResult)
                    {
                        Model.Sale satis = new Model.Sale();
                        satis.SaleDate = DateTime.Now.Date;
                        satis.PaymentMethodSale = 3;
                        satis.TotalPrice = totalPrice;
                        satis.CustomerID = query.CustomerID;
                        satis.TotalDiscount = Convert.ToDecimal(totalDiscount);
                        data.Sale.InsertOnSubmit(satis);
                        data.SubmitChanges();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {//TODO:Ürün Stokta Varmı Yokmu Kontrol Edilecek++

                            Model.BarcodeSystemDataContext pdata = new Model.BarcodeSystemDataContext();
                            Model.OpeationProduct satilanurunler = new Model.OpeationProduct();
                            
                            satilanurunler.SaleProduct = (from q in data.Sale
                                                          orderby q.SaleID descending
                                                          select q).First().SaleID;
                            satilanurunler.ProductID = (int)(row.Cells["ProductID"].Value);
                            satilanurunler.ProductDiscount = Convert.ToDecimal(row.Cells["ProductDiscount"].Value);
                            satilanurunler.ProductPrice = Convert.ToDecimal((row.Cells["ProductSalePrice"].Value.ToString().Split(' ')[0]));
                            pdata.OpeationProduct.InsertOnSubmit(satilanurunler);
                            pdata.SubmitChanges();
                          
                        }
                        Model.CustomerProcces satisislemi = new Model.CustomerProcces();
                        satisislemi.CustomerID = query.CustomerID;
                        satisislemi.ProccesDate = DateTime.Now;
                        satisislemi.ProccesType = 1;
                        satisislemi.ProccesPrice = totalPrice;
                        query.CustomerAccount += totalPrice;
                        data.CustomerProcces.InsertOnSubmit(satisislemi);
                        data.SubmitChanges();
                        totalDiscount = 0;
                        totalPrice = 0;
                        productDiscount = 0;
                        lblName.Text = "Ürün Adı : null";
                        lblPrice.Text = "Ürün Fiyat : null";
                        lblTotal.Text = "Toplam Fiyat : null";
                        datagridviewID = 1;
                        dataGridView1.Rows.Clear();
                        MessageDöndür.Message("Satış İşlemi başarıyla Gerçekleştirildi.", "İşlem Onaylandı", MessageDöndür.MessageIcon.OK, MessageDöndür.MessageButton.OK);
                    }
                }
                else
                {
                    MessageDöndür.Message("Müşteri Seçimi Başarısız Oldu !", "Müşteri Seçim Başarısız .", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                }
                
            }
            else
            {
                MessageDöndür.Message("Ürün Listesi Boş Olduğu İçin Çıkış yapılamıyor", "DataGridView Boş", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            selectedrow = dataGridView1.CurrentRow;
            if (selectedrow != null)
            {
                totalPrice = totalPrice - Convert.ToDecimal((dataGridView1.CurrentRow.Cells["ProductSalePrice"].Value.ToString().Split(' '))[0]);
                lblTotal.Text = "Toplam Fiyat : " + totalPrice + " TL";
                dataGridView1.Rows.Remove(selectedrow);
                lblName.Text = "Ürün Adı : null";
                lblPrice.Text = "Ürün Fiyat : null";
                button10.BackColor = Color.Red;
            }
            else
            {
                MessageDöndür.Message("Olmayan Ürünü Silemezsiniz.\nListeden Önce Ürün Seçiniz.", "Silme İşlemi Yanlış Yapıldı.", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            txtBarcodeSearch.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            totalPrice = 0;
            productDiscount = 0;
            totalDiscount = 0;
            datagridviewID = 1;
            dataGridView1.Rows.Clear();
            button10.BackColor = Color.Red;
            lblPrice.Text = "Fiyat : null";
            lblTotal.Text = "Toplam Fiyat : null";
            lblName.Text = "Ürün Adı : null";
            txtBarcodeSearch.Focus();
        }
        private void btnTotaliskonto_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0 || dataGridView1.RowCount == null)
            {
                MessageDöndür.Message("İndirim Yapabilmek için Önce Birkaç Veriye Sahip Olmalısınız.\n" +
                    "Listede Veri Yok", "Datagridviewde Veri Tespit Edilemedi"
                    , MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            else
            {
                if (totaleindirimyapildimi==false)
                {
                    totalDiscount = Discount.Show();
                 if (totalDiscount > totalPrice)
                    {
                        MessageDöndür.Message("Eğer Bu İndirimi Yaparsanız Sizin Müşteriye Para Ödemeniz Lazım.\nNe Yaptığınızın Farkındamısınız Siz ?\nYaptığınız İndirim Toplam Tutarı Aşıyor !\nİşlem İptal Edildi", "Girdiler Yanlış Hata Oluştu", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                    }
                    else
                    {
                        totalPrice = totalPrice - totalDiscount;
                        lblTotal.Text = "Toplam Fiyat : " + totalPrice + " TL";
                        totaleindirimyapildimi = true;
                    }
                }
                else
                {
                    MessageDöndür.MessageResult result = MessageDöndür.Message("Zaten Toplam Tutara Bir İndirim Yapıldı.\nTekrar Bir İndirim Yapacaksanız Toplam Tutar İlk Haline Çevirilecektir !\nYeniden İndirim Yapmak İstiyormusunuz ?", "İndirim Tekrar Yeniden Yapılsın mı ?", MessageDöndür.MessageIcon.Information, MessageDöndür.MessageButton.YesNo);
                    if (result == MessageDöndür.MessageResult.Yes)
                    {
                        totalPrice = totalPrice + totalDiscount;
                        lblTotal.Text = "Toplam Fiyat : " + totalPrice + " TL";
                        totaleindirimyapildimi = false;
                        MessageDöndür.Message("Toplam Tutar İlk Hale Geri Getirildi ! \nYeniden İndirim Yapabilirsiniz.", "Yeniden Düzenlendi", MessageDöndür.MessageIcon.OK, MessageDöndür.MessageButton.OK);
                    }
                    else if (result == MessageDöndür.MessageResult.No)
                    {
                        MessageDöndür.Message("Yeniden İndirim Yapılması Kullanıcı Tarafından Reddedildi.", "Yeniden İndirim Yapılmadı", MessageDöndür.MessageIcon.Information, MessageDöndür.MessageButton.OK);
                    }
                    txtBarcodeSearch.Focus();
                }
            }
        }
        private void btnProductDiscount_Click(object sender, EventArgs e)
        {
            //TODO: Product Discount Denetlenecek 2.kez İndirim Yapılırsa Uyarı Verilecek++++++
            if (dataGridView1.Rows.Count <= 0) //Listede Veri Varmı ? Yoksa Mesaj Ver
            {
                MessageDöndür.Message("İndirim Yapabilmek İçin Önce Listeye Bir Kaç Veri Ekleyin !", "Kullanıcı Veri Eklemediği İçin Hata Oluştu...", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            else
            {
                productDiscount = Discount.Show();
                if (Convert.ToDecimal((dataGridView1.CurrentRow.Cells["ProductSalePrice"].Value.ToString().Split(' '))[0]) < productDiscount)
                {
                    MessageDöndür.Message("Siz Ne Yaptığınızın Farkındamısınız ?\nÜrün İndirimi Ürünün Fiyatını Aşıyor !", "Ürün İskontosu Fiyattan Daha Fazla", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                }
                else
                {
                    dataGridView1.CurrentRow.Cells["ProductDiscount"].Value = productDiscount;
                    dataGridView1.CurrentRow.Cells["ProductSalePrice"].Value = Convert.ToDecimal((dataGridView1.CurrentRow.Cells["ProductSalePrice"].Value.ToString().Split(' '))[0]) - productDiscount + " TL";
                    totalPrice = totalPrice - productDiscount;
                    lblTotal.Text = "Toplam Fiyat : " + totalPrice + " TL";
                }
            }
            txtBarcodeSearch.Focus();
        }
        private void btnWaitList_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0 || dataGridView1.RowCount == null)
            {
                MessageDöndür.Message("Listede Veri Yok Bekleme İşlemi Yapılamıyor.", "Datagridview Nesnesi Boş", 
                    MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            else
            { 
                int indis = 0;
                waitlist = new DataGridViewRow[dataGridView1.Rows.Count + 5];
                if (beklemedeurunvarmi == false)
                {
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        waitlist[indis] = item;
                        indis++;
                    }
                    beklemedeurunvarmi = true;
                    btnWaitList.Visible = false;
                    btnWaitListReturn.Visible = true;
                    waitTotalDiscount = totalDiscount;
                    dataGridView1.Rows.Clear();
                    totalDiscount = 0;
                    totalPrice = 0;
                    productDiscount = 0;
                    lblName.Text = "Ürün Adı : null";
                    lblPrice.Text = "Ürün Fiyat : null";
                    lblTotal.Text = "Toplam Fiyat : null";
                  
                }
                else
                {
                    MessageDöndür.Message("Beklemede Zaten Bir Ürün Listesi Mevcut .\n Eski Liste Temizlensin mi?", "Halihazırda bir ürün listesi mevcut", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.YesNo);
                }
            }
            txtBarcodeSearch.Focus();
        }
        private void btnWaitListReturn_Click(object sender, EventArgs e)
        {
            int indis = 0;
            foreach (var item in waitlist)
            {
                if (waitlist[indis] == null)
                {
                    break;
                }
                dataGridView1.Rows.Add(waitlist[indis]);
                totalPrice += Convert.ToDecimal((waitlist[indis].Cells[6].Value.ToString().Split(' '))[0]);
                indis++;
            }
            totalPrice -= waitTotalDiscount;
            waitTotalDiscount = 0;
            lblTotal.Text = "Toplam Fiyat : " + totalPrice.ToString() + " TL";
            beklemedeurunvarmi = false;
            btnWaitList.Visible = true;
            btnWaitListReturn.Visible = false;
            waitlist = new DataGridViewRow[300];
            datagridviewID = dataGridView1.Rows.Count+1;
            lblName.Text ="Ürün Adı : "+ dataGridView1.CurrentRow.Cells["ProductName"].Value.ToString();
            lblPrice.Text ="Ürün Fiyat : "+ dataGridView1.CurrentRow.Cells["ProductSalePrice"].Value.ToString();
            txtBarcodeSearch.Focus();

        }
        private void txtBarcodeSearch_TextChanged(object sender, EventArgs e)
        { 
            if (txtBarcodeSearch.Text == "" || txtBarcodeSearch.TextLength < 8)
            {
            }
            else
            {
                var search = (from q in data.Product
                              where q.ProductBarcode == txtBarcodeSearch.Text  && q.ProductDelete == true
                              select q).ToList();
                if (search.Count == 0)
                {
                    button10.BackColor = Color.FromArgb(255, 0, 0);
                    MessageDöndür.Message("Ürün Bulunamadı!\nBu ürün ya kayıtlı değil yada silinmiş.\nEğer elinizde böyle bir ürün bulunuyorsa önce bunu sisteme eklemelisiniz.\n", "Hata", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                }
                else
                {
                    foreach (var item in search)
                    {
                        if (0>=item.ProductPiece|| item.ProductPiece==null)
                        {
                            MessageDöndür.MessageResult result = MessageDöndür.Message(item.ProductBarcode + " Barkodlu " + item.ProductName + " Adli Ürün Ürün Stokta Olmadığı için Stoktatan Çıkış Yapılamıyor.Ürün Sayısı :"+item.ProductPiece+"\n" +
                                    "Elinizde Bu Ürün Varsa ve işlemin Devam Etmesinide İstiyorsanız Onay Verin.\n" +
                                    "Stokta bu ürün 0 ın Altına Düşecek.\nBu İşlemi Onaylıyormusunuz?", "Depoda Ürün Yok İşlem Bekleniyor", MessageDöndür.MessageIcon.Information, MessageDöndür.MessageButton.YesNo);
                            if (MessageDöndür.MessageResult.Yes==result)
                            {

                            }
                            else if (MessageDöndür.MessageResult.No == result)
                            {
                                continue;
                            }
                        }
                        button10.BackColor = Color.FromArgb(153, 255, 51);
                        dataGridView1.Rows.Add(datagridviewID, item.ProductID, item.ProductBarcode, item.ProductName, item.SubTboCategories.CategoryName, item.ProductSize, item.ProductSalePrice + "  TL", 0, item.ProductDescription);
                        dataGridView1.Columns["ProductID"].Visible = false;
                        lblPrice.Text = "Ürün Fiyat : " + item.ProductSalePrice + " TL";
                        lblName.Text = "Ürün Adı : " + item.ProductName;
                        totalPrice = totalPrice + (decimal)item.ProductSalePrice;
                        lblTotal.Text = "Toplam Fiyat : " + totalPrice + " TL";
                        txtBarcodeSearch.Clear();
                        datagridviewID++;
                        txtBarcodeSearch.Clear();
                    }
                }
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblPrice.Text = "Ürün Fiyat : " + dataGridView1.CurrentRow.Cells["ProductSalePrice"].Value;
            lblName.Text = "Ürün Adı : " + dataGridView1.CurrentRow.Cells["ProductName"].Value;
            txtBarcodeSearch.Focus();
        }
        
       

    }
}




