using BarkodSistemTekstil.Controller;
using ExcelReport;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace BarkodSistemTekstil.Ui
{
    public partial class Ui_Wizard : UserControl
    {
        public Ui_Wizard()
        {
            InitializeComponent();
        }
        int level = 0;
        int deepUno;
        int deepDos;
        int deepTres;

       
        DataGridView dgv = new DataGridView();
        CustomerConnectComponent fonk = new CustomerConnectComponent();
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        
        private void Ui_Wizard_Load(object sender, EventArgs e)
        {
            panelOperationHead.Visible=false;
            listBox1.Items.Add("Müşteri Raporları");
            listBox1.Items.Add("Ürün Raporları");
            listBox1.Items.Add("Günlük Raporlar");
            lblSteps.Text = "Raporlar";
            lblStatus.Text = "Durum : Beklemede";
            progressBar1.Visible = false;
            progressBar1.Step = 1;
            btnBack.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Class.Routing.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (level==1 &&( deepUno==0 || deepUno==1 || deepUno==2))
            {
                btnBack.Visible = false;
                listBox1.Visible = true;
                progressBar1.Visible = false;
                dgv.Visible = false;
                panelOperationHead.Visible = false;


                listBox1.Items.Clear();
                listBox1.Items.Add("Müşteri Raporları");
                listBox1.Items.Add("Ürün Raporları");
                listBox1.Items.Add("Günlük Raporlar");
                lblSteps.Text = "Raporlar";
                deepUno = -1;
                deepDos = -1;
                deepTres = -1;
            }
           
            else if (level==2 && deepUno==0 && (deepDos==0 || deepDos==1))
            {
                lblSteps.Text = "Raporlar -> Müşteri Raporları ";
                listBox1.Items.Clear();
                listBox1.Items.Add("Müşteri Listesi");
                listBox1.Items.Add("Müşteri Dökümleri");
                listBox1.Visible = true;
                progressBar1.Visible = false;
                dgv.Visible = false;
                panelOperationHead.Visible = false;

                deepDos = -1;

            }

            else if (level==2 && deepUno==1 && deepDos==0)
            {

                lblSteps.Text = "Raporlar -> Ürün Raporları";
                listBox1.Items.Clear();
                listBox1.Items.Add("Ürünlerin Listesi");
                listBox1.Items.Add("Ürün Raporu");
                listBox1.Visible = true;

                progressBar1.Visible = false;
                dgv.Visible = false;
                panelOperationHead.Visible = false;

                deepDos = -1;


            }
            else if (level==2 && deepUno==2 && (deepDos==0 || deepUno==1))
            {

                lblSteps.Text = "Raporlar -> Günlük Raporlar";
                listBox1.Items.Clear();
                listBox1.Items.Add("24 Saatlik Satış");
                listBox1.Items.Add("Günlük Satılan Ürün Detayı");
                listBox1.Visible = true;
                progressBar1.Visible = false;
                dgv.Visible = false;
                panelOperationHead.Visible = false;
                deepDos = -1;


            }
            level--;
                
            
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            btnBack.Visible = true;
            if (level==0)
            {
                deepUno =-1;
                deepUno = listBox1.SelectedIndex;
            }
            else if (level==1)
            {
                deepDos = -1;
                deepDos = listBox1.SelectedIndex;
            }
            else if (level==2)
            {
                deepTres = -1;
                deepTres = listBox1.SelectedIndex;
            }
             if (level==0 && deepUno == 0)
            {
                lblSteps.Text = "Raporlar -> Müşteri Raporları ";
                listBox1.Items.Clear();
                listBox1.Items.Add("Müşteri Listesi");
                listBox1.Items.Add("Müşteri Dökümleri");
              
            }
            else if (level == 0 && deepUno == 1)
            {
                lblSteps.Text = "Raporlar -> Ürün Raporları";
                listBox1.Items.Clear();
                listBox1.Items.Add("Ürünlerin Listesi");
                listBox1.Items.Add("Ürünleri");
               
            }
            else if (level == 0 && deepUno == 2)
            {
                lblSteps.Text = "Raporlar -> Günlük Raporlar";
                listBox1.Items.Clear();
                listBox1.Items.Add("24 Saatlik Satış");
                listBox1.Items.Add("Günlük Satılan Ürün Detayı");
            }

            //Müşteri Listesi
            else if (level == 1 && deepUno == 0 && deepDos == 0)
            {
                lblSteps.Text = "Raporlar -> Müşteri Raporları -> Müşteri Listesi";

                Report rpt = new Report();

                var query = from q in data.Customer select q;
                rpt.NewApp("CustomerList");
                rpt.CenterHeaderText("Müşteri Listesi");
                rpt.Visibility = true;
                rpt.Border = true;
                rpt.PageMarginLeft = 10;
                rpt.PageMarginRight = 10;
               


                rpt.ColumnsTitle(0, 0, true, "Müşteri Adı Soyadi");
                rpt.ColumnsTitle(0, 1, true, "Müşteri Telefonu");
                rpt.ColumnsTitle(0, 2, true, "Müşterinin Referansı");
                rpt.ColumnsTitle(0, 3, true, "Müşterinin Bakiyesi");
                rpt.ColumnsTitle(0, 4, true, "Müşterinin Mesleği");



                progressBar1.Visible = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = query.Count();

                int row = 1;
                foreach (var item in query)
                {
                    rpt.WriteCell(row, 0, item.CustomerName + " " + item.CustomerSurname);
                    rpt.WriteCell(row, 1, item.CustomerTelephone);
                    rpt.WriteCell(row, 2, item.SubTboRefCustomer.RefUserName + " " + item.SubTboRefCustomer.RefUserSurname);
                    rpt.WriteCell(row, 3, item.CustomerAccount.ToString() + " TL");
                    rpt.WriteCell(row, 4, item.CustomerOccupotion);
                    progressBar1.PerformStep();
                    
                    row++;

                }
                rpt.SaveAs(Application.StartupPath + "Customer.xlsx");
                rpt.RamClose();
            }
            //Müşteri Dökümleri Step 1
            else if (level == 1 && deepUno == 0 && deepDos == 1)
            {
                lblSteps.Text = "Raporlar -> Müşteri Raporları -> Müşteri";
                panelOperationHead.Visible = true;
                dgv.Visible = true;
                listBox1.Visible = false;
                panelOperation.Controls.Add(dgv);
                dgv.Dock = DockStyle.Bottom;
                dgv.Height = 245;
                fonk.musterileriDoldur(dgv);
            }
            //Ürünlerin Listesi
            else if (level == 1 && deepUno == 1 && deepDos == 0)
            {
                lblSteps.Text= "Raporlar -> Ürün Raporları -> Ürün Listesi";
                Report rpt = new Report();
                var query = from q in data.Product
                            where q.ProductDelete == true
                            select q;

                rpt.NewApp("CustomerList");
                rpt.CenterHeaderText("Ürün Listesi");
                rpt.Visibility = true;
                rpt.Border = true;
                rpt.PageMarginLeft = 10;
                rpt.PageMarginRight = 10;

                progressBar1.Visible = true;
                progressBar1.Maximum = query.Count();

                rpt.ColumnsTitle(0, 0, true, "Ürünün Barkodu");
                rpt.ColumnsTitle(0, 1, true, "Ürünün Adı");
                rpt.ColumnsTitle(0, 2, true, "Ürünün Bedeni ");
                rpt.ColumnsTitle(0, 3, true, "Ürünün Satış Fiyatı");
                rpt.ColumnsTitle(0, 4, true, "Ürünün Stoğu");
               
                int row = 1;
                foreach (var item in query)
                {
                    rpt.WriteCell(row, 0, item.ProductBarcode);
                    rpt.WriteCell(row, 1, item.ProductName);
                    rpt.WriteCell(row, 2, item.ProductSize);
                    rpt.WriteCell(row, 3, item.ProductSalePrice.ToString());
                    rpt.WriteCell(row, 4, item.ProductPiece.ToString());
                    row++;
                    progressBar1.PerformStep();
                }
                rpt.RamClose();
            }
            else if(level==1 && deepUno==1 && deepDos==1)
            {

            }
            else if (level == 1 && deepUno == 2 && deepDos == 0)
            {
                lblSteps.Text="Raporlar -> Günlük Raporlar -> 24 Saatlik Satış";
                
            }
            else if (level == 1 && deepUno == 2 && deepDos == 1)
            {
                ///TODO : Günlük Satılan Ürün Operasyonu
            }
            //Müşteri Dökümleri Step-2
           else  if (level == 2 && deepUno == 0 && deepDos == 1)
            {
                lblSteps.Text = "Raporlar -> Müşteri Raporları -> Müşteri -> Dökümleri";
                lblStatus.Text = "Durum : İşlem Bekleniyor";

                decimal ürünHizmetBedeli = 0;
                decimal MüsteriyeYapılanGeriOdeme = 0;
                decimal MüsterininYaptigiOdeme = 0;
                decimal sonbakiye=0;
                
                if (dgv.SelectedRows.Count <= 0)
                {
                    MessageDöndür.Message("Listeden Seçim Yapılmadı...!", "Seçim işlemi Başarısız", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                }
                else
                {
                    var query = from q in data.CustomerProcces
                                where q.CustomerID == (int)dgv.CurrentRow.Cells["CustomerID"].Value
                                select new
                                {
                                    q.Customer.CustomerName,
                                    q.Customer.CustomerSurname,
                                    q.Customer.CustomerAccount,
                                    q.SubTboProccesList.ProccesName,
                                    q.SubTboProccesList.ProccesID,
                                    q.ProccesPrice,
                                    q.ProccesDate
                                };

                    //ProgressBar'ı gelen verilere göre ayarlama
                    progressBar1.Maximum = query.Count();
                    progressBar1.Visible = true;

                    if (query.Count() <= 0)
                    {
                        MessageDöndür.Message("Bu Müşterinin Hiç İşlemi Bulunmamaktadir.", "Hata Oluştu", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                    }
                    else
                    {
                        Report rpt = new Report();
                        rpt.NewApp("CustomerProcces");
                        rpt.Visibility = true;
                        rpt.Border = true;
                        rpt.PageMarginLeft = 10;
                        rpt.PageMarginRight = 10;
                        rpt.ColumnsTitle(0, 0, true, "İşlem Tarihi");
                        rpt.ColumnsTitle(0, 1, true, "İşlem Tipi");
                        rpt.ColumnsTitle(0, 2, true, "İşlem Tutarı");
                        int row = 1;
                        foreach (var item in query)
                        {
                            rpt.CenterHeaderText(item.CustomerName + " " + item.CustomerSurname + " İşlem Dökümü");
                            if (item.ProccesID==1)
                            {
                                ürünHizmetBedeli += item.ProccesPrice;
                            }
                            else if (item.ProccesID == 2)
                            {
                                MüsteriyeYapılanGeriOdeme += item.ProccesPrice;
                            }
                            else if (item.ProccesID == 3)
                            {
                                MüsterininYaptigiOdeme += item.ProccesPrice;
                            }
                            rpt.WriteCell(row, 0, item.ProccesDate.ToString());
                            rpt.WriteCell(row, 1, item.ProccesName);
                            rpt.WriteCell(row, 2, item.ProccesPrice.ToString());
                            row++;
                            sonbakiye =((decimal)item.CustomerAccount);

                            progressBar1.PerformStep();
                        }
                        rpt.MergeCell(row + 1, 0, row + 1, 2);
                        rpt.WriteRange(row + 1, 0, row + 1, 2, "Genel İşlemler");
                        rpt.WriteCell(row+2, 0, "Ürün Hizmet Bedeli :" + ürünHizmetBedeli);
                        rpt.WriteCell(row+2, 1, "Müşteri Ödemesi :" + MüsterininYaptigiOdeme);
                        rpt.WriteCell(row+3, 0, "Müşteriye Geri Ödeme :" + MüsteriyeYapılanGeriOdeme);
                        rpt.WriteCell(row + 3, 1, "Müşterinin Kalan Borcu :" + sonbakiye);
                        rpt.SaveAs(Application.StartupPath + "CustomerProcces.xlsx");
                        rpt.RamClose();
                    }
                }
            }
            else
            {
                MessageDöndür.Message("Listeden Seçim Yapılmadı", "Boş Değer Döndü..", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                btnBack.Visible = false;
                level--;
            }
                level++;
        }
        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            fonk.musterileriDoldur(dgv, txtCustomerName.Text);
        }
        private void txtCustomerSurname_TextChanged(object sender, EventArgs e)
        {
            fonk.musterileriDoldur(dgv, txtCustomerName.Text, txtCustomerSurname.Text);
        }
    }


    
}

