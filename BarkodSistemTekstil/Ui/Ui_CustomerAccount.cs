using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarkodSistemTekstil.Controller;

namespace BarkodSistemTekstil.Ui
{
    public partial class Ui_CustomerAccount : UserControl
    {
        public Ui_CustomerAccount()
        {
            InitializeComponent();
        }
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        decimal amount = 0;
        int SelectedCustomerID=0;
        CustomerConnectComponent fonk = new CustomerConnectComponent();
        private void Ui_CustomerAccount_Load(object sender, EventArgs e)
        {
            var ProccesType = from q in data.SubTboProccesList
                              select new { q.ProccesID,q.ProccesName};
            fonk.musterileriDoldur(datagridview1);
            cmbProccesType.DataSource = ProccesType;
            cmbProccesType.DisplayMember = "ProccesName";
            cmbProccesType.ValueMember = "ProccesID";
            datagridview1.Columns["CustomerRegistrationDate"].Visible = false;
            datagridview1.Columns["RefUserName"].Visible = false;
            datagridview1.Columns["RefUserSurname"].Visible = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedCustomerID!=0&& txtAmount.Text!="")
            {
                var customer = (from q in data.Customer
                                where q.CustomerID == SelectedCustomerID
                                select q).First();
                amount = Convert.ToDecimal(txtAmount.Text);
               
                Model.CustomerProcces cstmrProcces = new Model.CustomerProcces();
                  if (((int)cmbProccesType.SelectedValue) == 1)
                {
                    //TODO:Ürün Bedeli Hizmet Veriyorum Ödeme Alıyorum Ozaman Accounta Ekle
                    cstmrProcces.CustomerID = SelectedCustomerID;
                    cstmrProcces.ProccesDate = DateTime.Now;
                    cstmrProcces.ProccesPrice = amount;
                    cstmrProcces.ProccesType = 1;
                    customer.CustomerAccount += amount;
                    data.CustomerProcces.InsertOnSubmit(cstmrProcces);
                    data.SubmitChanges();
                    MessageDöndür.Message(customer.CustomerName + " " + customer.CustomerSurname + " Adlı Müşterinin Hesabına +" + amount + " TL İşlem Yapıldı.", "Ürün Bedeli Hizmet Verildi", MessageDöndür.MessageIcon.Information, MessageDöndür.MessageButton.OK);
                    amount = 0;
                }
                else if (((int)cmbProccesType.SelectedValue) == 2)
                {
                    //TODO:Müşteriye Yapılan Geri Ödeme  Ozaman Accountan Düş
                    cstmrProcces.CustomerID = SelectedCustomerID;
                    cstmrProcces.ProccesDate = DateTime.Now;
                    cstmrProcces.ProccesPrice = amount;
                    cstmrProcces.ProccesType = 2;
                    customer.CustomerAccount -= amount;
                    data.CustomerProcces.InsertOnSubmit(cstmrProcces);
                    data.SubmitChanges();
                    MessageDöndür.Message(customer.CustomerName + " " + customer.CustomerSurname + " Adlı Müşterinin Hesabına -" + amount + " TL İşlem Yapıldı.", "Müşteriye Ödeme Yapıldı ", MessageDöndür.MessageIcon.Information, MessageDöndür.MessageButton.OK);
                    amount = 0;
                }
               else  if (((int)cmbProccesType.SelectedValue) == 3)
                {
                    //TODO:Ödeme Alıyorum Ozaman Accountdan Düş
                    //TODO:Ürün Bedeli Hizmet Veriyorum Ödeme Alıyorum Ozaman Accounta Ekle
                    cstmrProcces.CustomerID = SelectedCustomerID;
                    cstmrProcces.ProccesDate = DateTime.Now;
                    cstmrProcces.ProccesPrice = amount;
                    cstmrProcces.ProccesType = 3;
                    customer.CustomerAccount -= amount;
                    data.CustomerProcces.InsertOnSubmit(cstmrProcces);
                    data.SubmitChanges();
                    MessageDöndür.Message(customer.CustomerName + " " + customer.CustomerSurname + " Adlı Müşterinin Hesabına -" + amount + " TL İşlem Yapıldı.", "Müşteriye Ödeme Yapıldı ", MessageDöndür.MessageIcon.Information, MessageDöndür.MessageButton.OK);
                    amount = 0;

                }
                else if (((int)cmbProccesType.SelectedValue) == 4)
                {
                    //TODO:Taksit Alıyorum Ozaman Accounta düş
                    //TODO:Ürün Bedeli Hizmet Veriyorum Ödeme Alıyorum Ozaman Accounta Ekle
                    cstmrProcces.CustomerID = SelectedCustomerID;
                    cstmrProcces.ProccesDate = DateTime.Now;
                    cstmrProcces.ProccesPrice = amount;
                    cstmrProcces.ProccesType = 4;
                    customer.CustomerAccount += amount;
                    data.CustomerProcces.InsertOnSubmit(cstmrProcces);
                    data.SubmitChanges();
                    MessageDöndür.Message(customer.CustomerName + " " + customer.CustomerSurname + " Adlı Müşterinin Hesabına +" + amount + " TL İşlem Yapıldı.", "Müşteriye Ödeme Yapıldı ", MessageDöndür.MessageIcon.Information, MessageDöndür.MessageButton.OK);
                    amount = 0;
                }
                else
                {
                    MessageDöndür.Message("Ödeme Şekli Seçilmedi.", "Hata", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                }
            }
            else
            {
                MessageDöndür.Message("Müşteri Seçilmedi Yeniden Müşteri Seçiniz.", "Hata", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            fonk.musterileriDoldur(datagridview1);
            
        }

        private void datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedCustomerID = (int)(datagridview1.CurrentRow.Cells["CustomerID"].Value);
            txtcustomerName.Text = datagridview1.CurrentRow.Cells["CustomerName"].Value.ToString();
            txtcustomerSurname.Text = datagridview1.CurrentRow.Cells["CustomerSurName"].Value.ToString();
        }

        private void txtSearchCustomerName_TextChanged(object sender, EventArgs e)
        {
            fonk.musterileriDoldur(datagridview1, txtSearchCustomerName.Text);
        }

        private void txtSearchCustomerSurName_TextChanged(object sender, EventArgs e)
        {
            fonk.musterileriDoldur(datagridview1, txtSearchCustomerName.Text, txtSearchCustomerSurName.Text);
        }

       
    }
}
