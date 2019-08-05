using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Ui
{
    public partial class Ui_ProductEditPage : UserControl
    {
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        int selectedproductID = 0;
        int selectedCategory = 0;
        MessageDöndür.MessageResult result=MessageDöndür.MessageResult.No;
        public Ui_ProductEditPage()
        {
            InitializeComponent();
        }

        private void Ui_ProductEditPage_Load(object sender, EventArgs e)
        {
            dataProductLoad();
            datagridview1.Columns["ProductID"].Visible = false;
            datagridview1.Columns["ProductBarcode"].HeaderText = "ÜrünBarkodu";
            datagridview1.Columns["ProductName"].HeaderText = "ÜrününAdı";
            datagridview1.Columns["CategoryName"].HeaderText = "Kategori";
            datagridview1.Columns["ProductSize"].HeaderText = "Beden";
            datagridview1.Columns["ProductSalePrice"].HeaderText = "SatışFiyatı";
            datagridview1.Columns["ProductDescription"].HeaderText = "ÜrünDetayı";
            datagridview1.Columns["CategoryID"].Visible = false;
        }

        private void datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedproductID =(int)datagridview1.CurrentRow.Cells["ProductID"].Value;
            if (datagridview1.CurrentRow.Cells["ProductSalePrice"].Value==null)
            {

                txtProductBarcode.Text = datagridview1.CurrentRow.Cells["ProductBarcode"].Value.ToString();
                txtProductName.Text = datagridview1.CurrentRow.Cells["ProductName"].Value.ToString();
                txtProductPrice.Text = "";
                rctxtProductDetails.Text = datagridview1.CurrentRow.Cells["ProductDescription"].Value.ToString();
                cmbProductCategory.SelectedValue = (int)datagridview1.CurrentRow.Cells["CategoryID"].Value;
                cmbProductSize.Text = datagridview1.CurrentRow.Cells["ProductSize"].Value.ToString();
            }
            else
            {
                txtProductBarcode.Text = datagridview1.CurrentRow.Cells["ProductBarcode"].Value.ToString();
                txtProductName.Text = datagridview1.CurrentRow.Cells["ProductName"].Value.ToString();
                txtProductPrice.Text = datagridview1.CurrentRow.Cells["ProductSalePrice"].Value.ToString();
                rctxtProductDetails.Text = datagridview1.CurrentRow.Cells["ProductDescription"].Value.ToString();
                cmbProductCategory.SelectedValue = (int)datagridview1.CurrentRow.Cells["CategoryID"].Value;
                cmbProductSize.Text = datagridview1.CurrentRow.Cells["ProductSize"].Value.ToString();
            }

        }
   

        private void button6_Click(object sender, EventArgs e)
        {
            selectedCategory =(int)cmbProductCategory.SelectedValue;
            if (selectedproductID == 0)
            {
                MessageDöndür.Message("Ürün Seçilmedi Yandaki Tablodan Ürün Seçiniz...", "Seçilen Ürün Numarası Bulunamadı...", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            else if (selectedCategory==0)
            {
                MessageDöndür.Message("Kategori Kısmında Hata Oluştu...", "Hata Oluştu ", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);

            }
            else
            {
                var UpdateProduct = (from q in data.Product
                                         where q.ProductID == selectedproductID
                                         select q).First();
                UpdateProduct.ProductBarcode = txtProductBarcode.Text;
                UpdateProduct.ProductName = txtProductName.Text;
                UpdateProduct.ProductCategorie = selectedCategory;
                UpdateProduct.ProductSize = cmbProductSize.Text;
                UpdateProduct.ProductSalePrice =Convert.ToDouble(txtProductPrice.Text);
                UpdateProduct.ProductDescription = rctxtProductDetails.Text;
                data.SubmitChanges();
                MessageDöndür.Message("Ürün Başarıyla Yeniden Düzenlendi", "Ürün Düzenleme Başarılı", MessageDöndür.MessageIcon.OK, MessageDöndür.MessageButton.OK);
                dataProductLoad();
                

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedproductID == 0)
            {
                MessageDöndür.Message("Ürün Seçilmedi Yandaki Tablodan Ürün Seçiniz", "Seçilen Ürün Numarası Bulunamadı...", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            else
            {
                var DeleteProduct = (from q in data.Product
                                     where q.ProductID == selectedproductID
                                     select q).First();
                var StockFind = (from q in data.Stock
                                 where q.ProductID == DeleteProduct.ProductID
                                 select q).ToList();

                if (StockFind.Count == 0)
                {
                    result = MessageDöndür.Message("Barkod :" + DeleteProduct.ProductBarcode
                                                                    + "\nÜrün Adı :" + DeleteProduct.ProductName
                                                                    + "\nÜrünü Silmek İstiyormusunuz ?", "Silme İşlemi Onay "
                                                                    , MessageDöndür.MessageIcon.Trash
                                                                    , MessageDöndür.MessageButton.YesNo);
                    if (result == MessageDöndür.MessageResult.Yes)
                    {
                        DeleteProduct.ProductDelete = false;
                        data.SubmitChanges();
                        MessageDöndür.Message("Barkod :" + DeleteProduct.ProductBarcode
                                             + "\nÜrün Adi :" + DeleteProduct.ProductName
                                             + "\nÜrün Silindi..", "Silme İşlemi Başarılı",
                                             MessageDöndür.MessageIcon.OK,
                                             MessageDöndür.MessageButton.OK);
                    }
                    else
                    {
                        MessageDöndür.Message("Silme İşlemi Durduruldu", "Silme İşlemi İptal Edildi",
                                         MessageDöndür.MessageIcon.Eror,
                                         MessageDöndür.MessageButton.OK);
                    }
                }
                else if (StockFind.Count > 0)
                {
                    result = MessageDöndür.Message("Barkod :" + DeleteProduct.ProductBarcode
                                                   + "\nÜrün Adı :" + DeleteProduct.ProductName
                                                   + "\nBu Ürünün Stokta Kaydı Bulundu.."
                                                   + "\n Stoktaki Kayıtlarla Beraber Silinmesini Onaylıyormusunuz ?", "Silme İşlemi Onay "
                                                   , MessageDöndür.MessageIcon.Trash
                                                   , MessageDöndür.MessageButton.YesNo);
                    if (result == MessageDöndür.MessageResult.Yes)
                    {//Silme İşlemi Onaylandı
                        DeleteProduct.ProductDelete = false;
                        data.SubmitChanges();
                        MessageDöndür.Message("Barkod :" + DeleteProduct.ProductBarcode
                                             + "\nÜrün Adi :" + DeleteProduct.ProductName
                                             + "\nÜrün Silindi..", "Silme İşlemi Başarılı",
                                             MessageDöndür.MessageIcon.OK,
                                             MessageDöndür.MessageButton.OK);
                    }
                    else
                    {
                        MessageDöndür.Message("Silme İşlemi Durduruldu", "Silme İşlemi İptal Edildi",
                                         MessageDöndür.MessageIcon.Eror,
                                         MessageDöndür.MessageButton.OK);
                    }
                }
            }
            dataProductLoad();
        }

      
     /* var ProductName = (from cat in data.Categories
                                   join q in data.Product
                                   on cat.CategoryID equals q.ProductCategorie
                                   where q.ProductName.StartsWith(textBox2.Text) && q.ProductBarcode.StartsWith(textBox1.Text) && q.ProductDelete == true
                                   select new
                                   {
                                       q.ProductID,
                                       q.ProductBarcode,
                                       q.ProductName,
                                       cat.CategoryName,
                                       cat.CategoryID,
                                       q.ProductSize,
                                       q.ProductSalePrice,
                                       q.ProductDescription,
                                   }).ToList();
                datagridview1.DataSource = ProductName;*/

        

        void dataProductLoad()
        {
            var products = from cat in data.SubTboCategories
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

            cmbProductCategory.DataSource = data.SubTboCategories;
            cmbProductCategory.DisplayMember = "CategoryName";
            cmbProductCategory.ValueMember = "CategoryID";
            cmbProductSize.DataSource = from q in data.Product
                                        select q.ProductSize;
            datagridview1.DataSource = products;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                var Barcode = (from cat in data.SubTboCategories
                               join q in data.Product
                               on cat.CategoryID equals q.ProductCategorie
                               where q.ProductBarcode.StartsWith(textBox1.Text) && q.ProductDelete == false
                               select new
                               {
                                   q.ProductID,
                                   q.ProductBarcode,
                                   q.ProductName,
                                   cat.CategoryName,
                                   cat.CategoryID,
                                   q.ProductSize,
                                   q.ProductSalePrice,
                                   q.ProductDescription,
                               }).ToList();
                datagridview1.DataSource = Barcode;
            }
            else if (textBox1.Text == "")
            {
                var ProductName = (from cat in data.SubTboCategories
                                   join q in data.Product
                                   on cat.CategoryID equals q.ProductCategorie
                                   where q.ProductName.StartsWith(textBox2.Text) && q.ProductDelete == true
                                   select new
                                   {
                                       q.ProductID,
                                       q.ProductBarcode,
                                       q.ProductName,
                                       cat.CategoryName,
                                       cat.CategoryID,
                                       q.ProductSize,
                                       q.ProductSalePrice,
                                       q.ProductDescription,
                                   }).ToList();
                datagridview1.DataSource = ProductName;
            }
            else
            {
                var ProductName = (from cat in data.SubTboCategories
                                   join q in data.Product
                                   on cat.CategoryID equals q.ProductCategorie
                                   where q.ProductName.StartsWith(textBox2.Text) && q.ProductBarcode.StartsWith(textBox1.Text) && q.ProductDelete == true
                                   select new
                                   {
                                       q.ProductID,
                                       q.ProductBarcode,
                                       q.ProductName,
                                       cat.CategoryName,
                                       cat.CategoryID,
                                       q.ProductSize,
                                       q.ProductSalePrice,
                                       q.ProductDescription,
                                   }).ToList();
                datagridview1.DataSource = ProductName;
            }

        }
    }
}
