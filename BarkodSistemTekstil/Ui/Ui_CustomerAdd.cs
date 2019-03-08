using BarkodSistemTekstil.Model;
using System;
using System.Windows.Forms;


namespace BarkodSistemTekstil.Ui.Customers
{
    public partial class Ui_CustomerAdd :UserControl
    {
        public Ui_CustomerAdd()
        {
            InitializeComponent();
        }
        BarcodeSystemDataContext Data = new BarcodeSystemDataContext();
        
        Class.Fonksyonlar Fonk = new Class.Fonksyonlar();
      
        private void Ui_CustomerAdd_Load(object sender, EventArgs e)
        {
          
            Fonk.cmboboxReferansDoldur(cmbCustomerRefrence);
           
        }

        private void btncustomerInsert_Click(object sender, EventArgs e)
        {
            if (cmbCustomerRefrence.SelectedValue == null)
            {
                MessageBox.Show("Referans Kısmında Hata Oluştu...\n" +
                    "Muhtemelen Açılır Listede Olmayan Bir Referans Seçtiniz...\n" +
                    "Lütfen Açılır Listeden Referansi Doğru Şekilde Seçiniz...\n" +
                    "Eğer Referans Seçmiyecekseniz Referans Bölümüne 1 Yazmanız Yeterlidir", "Referans Seçim Bloğunda Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cmbCustomerRefrence.Text == "1" )
            {
                Customer cust = new Customer();
                cust.CustomerName = txtcustomerName.Text;
                cust.CustomerSurname = txtSurname.Text;
                cust.CustomerTelephone = txtCustomerTelephone.Text;
                cust.CustomerOccupotion = txtcusomerOccupotion.Text;
                cust.CustomerReference = 1;
                cust.CustomerAccount = Convert.ToDecimal(txtcustomerAccount.Text);
                cust.CustomerAddress = rctxtcustomerAddress.Text;
                cust.CustomerDetails = rctxtcustomerDetail.Text;
                Data.Customer.InsertOnSubmit(cust);
                Data.SubmitChanges();
                MessageBox.Show(txtcustomerName.Text+" "+txtSurname.Text+"\n"+
                                "Adli Müşteri Kaydedildi",
                                "Müsteri Kayıt İşlemi Başarılı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else if (string.IsNullOrWhiteSpace(cmbCustomerRefrence.Text) != true &&
                string.IsNullOrWhiteSpace(txtcustomerName.Text)!=true &&
                string.IsNullOrWhiteSpace(txtSurname.Text)!=true)
            {
                Customer cust = new Customer();
                cust.CustomerName = txtcustomerName.Text;
                cust.CustomerSurname = txtSurname.Text;
                cust.CustomerTelephone = txtCustomerTelephone.Text;
                cust.CustomerOccupotion = txtcusomerOccupotion.Text;
                cust.CustomerReference = (int)cmbCustomerRefrence.SelectedValue;
                cust.CustomerAccount = Convert.ToDecimal(txtcustomerAccount.Text);
                cust.CustomerAddress = rctxtcustomerAddress.Text;
                cust.CustomerDetails = rctxtcustomerDetail.Text;
                cust.CustomerRegistrationDate = DateTime.Now;
                Data.Customer.InsertOnSubmit(cust);
                Data.SubmitChanges();
                MessageBox.Show(txtcustomerName.Text + " " + txtSurname.Text + "\n" +
                              "Adli Müşteri Kaydedildi",
                              "Müsteri Kayıt İşlemi Başarılı",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Yeni Müşteri Ekleme Başarısız Oldu...\n" +
                    "Verileri Doğru Girdiğinizden Emin Olun","Girdilerde Hata Oluştu",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
          

        }

      
    }
}
