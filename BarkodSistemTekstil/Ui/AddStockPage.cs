using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Ui
{
    public partial class AddStockPage : UserControl
    {
        public AddStockPage()
        {
            InitializeComponent();
        }
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        private void AddStockPage_Load(object sender, EventArgs e)
        {
            var products = (from q in data.Product
                            where q.ProductDelete == true
                            select new
                            {
                                q.ProductID,
                                q.ProductBarcode,
                                q.ProductName,
                                q.SubTboCategories.CategoryName,
                                q.ProductSize,
                                q.ProductSalePrice,
                                q.ProductDescription,
                                q.ProductPiece,
                            }).ToList();
            datagridview1.DataSource = products;
            datagridview1.Columns["ProductID"].Visible = false;
            datagridview1.Columns["ProductName"].HeaderText = "ÜrünAdı";
            datagridview1.Columns["ProductBarcode"].HeaderText = "Barkod";
            datagridview1.Columns["CategoryName"].HeaderText = "Kategorisi";
            datagridview1.Columns["ProductSize"].HeaderText = "Beden/Ölçü";
            datagridview1.Columns["ProductSalePrice"].HeaderText = "SatışFiyatı";
            datagridview1.Columns["ProductDescription"].HeaderText = "ÜrünDetayları";
            datagridview1.Columns["ProductPiece"].HeaderText = "StoktakiÜrünMiktari";
        }
        int selectedproductID;
        private void datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedproductID = (int)datagridview1.CurrentRow.Cells["ProductID"].Value;
            txtBarcode.Text = datagridview1.CurrentRow.Cells["ProductBarcode"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Stock stok = new Model.Stock();
            if (selectedproductID != 0 && txtBarcode.Text!=""&&txtPiece.Text!=""&&txtPurchasePrice.Text!=""&&rcManufacturer.Text!="")
            {
                var ara = (from q in data.Stock
                           where q.ProductID == selectedproductID
                           select q).ToList();
                var findproduct = (from q in data.Product
                                  where q.ProductID == selectedproductID
                                  select q).FirstOrDefault();
                if (findproduct.ProductPiece==null)
                {
                    findproduct.ProductPiece = Convert.ToInt32(txtPiece.Text);
                }
                else
                {
                    findproduct.ProductPiece = findproduct.ProductPiece + Convert.ToInt32(txtPiece.Text);
                }
                
               
                stok.ProductID = selectedproductID;
                    stok.ProductManufacturer = rcManufacturer.Text;
                    stok.PurchasePrice = Convert.ToDecimal(txtPurchasePrice.Text);
                    stok.Piece = Convert.ToInt32(txtPiece.Text);
                    stok.StockEntryDate = DateTime.Now;
                    data.Stock.InsertOnSubmit(stok);
                    data.SubmitChanges();
                    MessageDöndür.Message(datagridview1.CurrentRow.Cells["ProductName"].Value.ToString() + " Adlı Ürün\n"
                        + rcManufacturer.Text + " Üreticisinden "
                        + txtPiece.Text + " Parça Eklendi\n"
                        + "Alış Fiyatı :" + txtPurchasePrice.Text
                        + " TL Olarak Belirlendi.",
                        "Stoğa Ürün Eklendi.",
                        MessageDöndür.MessageIcon.OK,
                        MessageDöndür.MessageButton.OK);
            }
            else
            {
                MessageDöndür.Message("Hata Algılandı Muhemelen Yan Taraftaki Açılır Listeden Ürün Seçmediniz.\n" +
                    "Yada Doldurulması Gereken Alanları Yanlış veya Boş Bir Şekilde Doldurdunuz.", "Bir Hata Algılandı", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            var products = (from q in data.Product
                            where q.ProductDelete == true
                            select new
                            {
                                q.ProductID,
                                q.ProductBarcode,
                                q.ProductName,
                                q.SubTboCategories.CategoryName,
                                q.ProductSize,
                                q.ProductSalePrice,
                                q.ProductDescription,
                                q.ProductPiece,
                            }).ToList();
            datagridview1.DataSource = products;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            var search = (from q in data.Product
                          where q.ProductBarcode.StartsWith(textBox4.Text) && q.ProductDelete == true
                          select new
                          {
                              q.ProductID,
                              q.ProductBarcode,
                              q.ProductName,
                              q.SubTboCategories.CategoryName,
                              q.ProductSize,
                              q.ProductSalePrice,
                              q.ProductDescription,
                              q.ProductPiece,
                          }).ToList();
            datagridview1.DataSource = search;

        }
    }
}
