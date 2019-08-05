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
using BarkodSistemTekstil.Controller;

namespace BarkodSistemTekstil.Ui
{
    public partial class Ui_ProductAddPage : UserControl
    {
        ProductConnectComponent PCC = new ProductConnectComponent();
        public Ui_ProductAddPage()
        {
            InitializeComponent();
        }

        private void Ui_ProductAddPage_Load(object sender, EventArgs e)
        {
            ProductConnectComponent PCC = new ProductConnectComponent();
            PCC.KategoriListesi(cmbProductCategory);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class.Routing.AddPage(new Ui.AddStockPage());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PCC.UrunEkle(txtProductBarcode, txtProductName, cmbProductCategory, rctxtProductDetails, NumericSatisFiyat);
        }
    }
}
