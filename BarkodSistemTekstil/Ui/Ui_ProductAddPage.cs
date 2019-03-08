using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarkodSistemTekstil.Model;
using BarkodSistemTekstil.Ui;

namespace BarkodSistemTekstil.Ui
{
    public partial class Ui_ProductAddPage : UserControl
    {
       
        BarcodeSystemDataContext data = new BarcodeSystemDataContext();
        Product prdc = new Product();
        public Ui_ProductAddPage()
        {
            InitializeComponent();
        }

        private void Ui_ProductAddPage_Load(object sender, EventArgs e)
        {
            cmbProductCategory.DataSource = data.SubTboCategories;
            cmbProductCategory.DisplayMember = "CategoryName";
            cmbProductCategory.ValueMember = "CategoryID";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class.Routing.AddPage(new Ui.AddStockPage());
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            data = new BarcodeSystemDataContext();
            prdc = new Product();
            var ara = (from q in data.Product
                       where q.ProductBarcode == txtProductBarcode.Text
                       select q).FirstOrDefault();
            if (ara==null)
            {
                prdc.ProductBarcode = txtProductBarcode.Text;
                prdc.ProductName = txtProductName.Text;
                prdc.ProductCategorie = Convert.ToInt32(cmbProductCategory.SelectedValue);
                prdc.ProductSize = cmbProductSize.Text;
                prdc.ProductSalePrice = Convert.ToDouble(txtProductPrice.Text);
                prdc.ProductDescription = rctxtProductDetails.Text;
                prdc.ProductDelete = true;
                prdc.ProductPiece = 0;
                data.Product.InsertOnSubmit(prdc);
                data.SubmitChanges();
                MessageDöndür.Message("Ürününüz Başırılı Bir Şekilde Eklendi", "Bilgilendirme", MessageDöndür.MessageIcon.OK, MessageDöndür.MessageButton.OK);
            }
            else
            {
                MessageDöndür.Message(txtProductBarcode.Text + " Barkodlu Ürün Bulundu \nBu Yüzden Kayıt Yapılamıyor !", "Aynı Barkodlu Ürün Bulundu", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
        }
    }
}
