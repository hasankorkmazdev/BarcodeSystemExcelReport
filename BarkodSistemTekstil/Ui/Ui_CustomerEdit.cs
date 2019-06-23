using BarkodSistemTekstil.Controller;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Ui
{
    public partial class Ui_CustomerEdit : UserControl
    {
        public Ui_CustomerEdit()
        {
            InitializeComponent();
        }
        Model.Customer cust = new Model.Customer();
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        private void Ui_CustomerEdit_Load(object sender, EventArgs e)
        {
            CustomerConnectComponent fonk = new CustomerConnectComponent();
            fonk.cmboboxReferansDoldur(cmbcustomerReference);
            fonk.musterileriDoldur(datagridview1);
            datagridview1.AllowUserToAddRows = false;
         
        }
      

        #region Buton-Sil 
        private void btncustomerDelete_Click(object sender, EventArgs e)
        {
            CustomerConnectComponent fonk = new CustomerConnectComponent();
            int custID = (int)datagridview1.CurrentRow.Cells["CustomerID"].Value;
            
            var ara = (from q in data.Customer
                       where q.CustomerID == custID
                       select q).First();
            DialogResult result = MessageBox.Show(ara.CustomerName+" " +ara.CustomerSurname+ " Müsteriyi Silmek Üzeresiniz..."
                                                    + ara.CustomerName + ara.CustomerSurname + " İsmindeki Müşterinin Borç durumu: "
                                                 + ara.CustomerAccount + "\n\nYinede Silmeye Devam Edilsinmi ?",
                                                "Silme İşlemi Yetkilendirilmesi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(ara.CustomerName+" " +ara.CustomerSurname + " Adindaki Müsteri Silindi", "Müsteri Silme İşlemi", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    data.Customer.DeleteOnSubmit(ara);
                    data.SubmitChanges();
                }
            else
            {
                MessageBox.Show("Müşteri Silme İşlemi İptal Edildi..", "Müsteri Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            fonk.musterileriDoldur(datagridview1);
        }
        #endregion

        #region Buton-Düzenle
        private void btncustomerEdit_Click(object sender, EventArgs e)
        {
            CustomerConnectComponent fonk = new CustomerConnectComponent();

            //TODO: DATAGRİDVİEVDEN GELEN VERİ VARMI KONTROL EDİLECEK
            if (cmbcustomerReference.SelectedValue == null)
            {
                MessageDöndür.Message("Referans Kısmında Hata Oluştu...\n" +
                    "Muhtemelen Açılır Listede Olmayan Bir Referans Seçtiniz...\n" +
                    "Lütfen Açılır Listeden Referansi Doğru Şekilde Seçiniz...\n" +
                    "Eğer Referans Seçmiyecekseniz Referans Bölümüne 1 Yazmanız Yeterlidir", "Referans Seçim Bloğunda Hata Oluştu", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);

            }
            else if (cmbcustomerReference.Text == "1")
            {
                int custİD = (int)datagridview1.CurrentRow.Cells["CustomerID"].Value;
                var custEdit = (from c in data.Customer
                                where c.CustomerID == custİD
                                select c).First();
                var refEdit = (from r in data.SubTboRefCustomer
                               where r.RefUserID == custEdit.CustomerID
                               select r).First();
                
                custEdit.CustomerName = txtcustomerName.Text;
                custEdit.CustomerSurname = txtCustomerSurname.Text;
                custEdit.CustomerTelephone = txtcustomerTelephone.Text;
                custEdit.CustomerOccupotion = txtcustomerOccupotion.Text;
                custEdit.CustomerAddress = rctxtcustomerAddress.Text;
                custEdit.CustomerDetails = rctxtcustomerDetails.Text;
                custEdit.CustomerOccupotion = txtcustomerOccupotion.Text;
                custEdit.CustomerAccount = Convert.ToDecimal(txtcustomerAccount.Text);
                custEdit.CustomerReference = (int)cmbcustomerReference.SelectedValue;
                refEdit.RefUserName = txtcustomerName.Text ;
                refEdit.RefUserSurname = txtCustomerSurname.Text;
                data.SubmitChanges();
                fonk.musterileriDoldur(datagridview1);
                MessageDöndür.Message(txtcustomerName.Text + " " + txtCustomerSurname.Text + "\n" +
                                "Adli Müşteri Kaydedildi",
                                "Müsteri Kayıt İşlemi Başarılı",
                                MessageDöndür.MessageIcon.Information,
                                MessageDöndür.MessageButton.OK);
            }
            else if (string.IsNullOrWhiteSpace(cmbcustomerReference.Text) != true &&
                string.IsNullOrWhiteSpace(txtcustomerName.Text) != true &&
                string.IsNullOrWhiteSpace(txtCustomerSurname.Text) != true)
            {

                int custİD = (int)datagridview1.CurrentRow.Cells["CustomerID"].Value;
                var custEdit = (from c in data.Customer
                                where c.CustomerID == custİD
                                select c).First();
                var refEdit = (from r in data.SubTboRefCustomer
                               where r.RefUserID == custEdit.CustomerID
                               select r).First();
                custEdit.CustomerName = txtcustomerName.Text;
                custEdit.CustomerSurname = txtCustomerSurname.Text;
                custEdit.CustomerTelephone = txtcustomerTelephone.Text;
                custEdit.CustomerOccupotion = txtcustomerOccupotion.Text;
                custEdit.CustomerAddress = rctxtcustomerAddress.Text;
                custEdit.CustomerDetails = rctxtcustomerDetails.Text;
                custEdit.CustomerOccupotion = txtcustomerOccupotion.Text;
                custEdit.CustomerAccount = Convert.ToDecimal(txtcustomerAccount.Text);
                custEdit.CustomerReference = (int)cmbcustomerReference.SelectedValue;
                refEdit.RefUserName = txtcustomerName.Text;
                refEdit.RefUserSurname = txtCustomerSurname.Text;
                data.SubmitChanges();
                fonk.musterileriDoldur(datagridview1);
                MessageBox.Show(txtcustomerName.Text + " " + txtCustomerSurname.Text + "\n" +
                              "Adli Müşteri Düzenlendi",
                              "Müsteri Düzenleme İşlemi Başarılı",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Müşteri Düzenleme İşlemi Başarısız...\n" +
                    "Verileri Doğru Girdiğinizden Emin Olun", "Girdilerde Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CustomerConnectComponent fonk = new CustomerConnectComponent();
            fonk.musterileriDoldur(datagridview1, textBox1.Text);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CustomerConnectComponent fonk = new CustomerConnectComponent();
            fonk.musterileriDoldur(datagridview1, textBox1.Text, textBox2.Text);
        }

        private void datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int refid = (int)datagridview1.CurrentRow.Cells["CustomerReference"].Value;
            cmbcustomerReference.SelectedValue = refid;
            txtcustomerName.Text = datagridview1.CurrentRow.Cells["CustomerName"].Value.ToString();
            txtCustomerSurname.Text = datagridview1.CurrentRow.Cells["CustomerSurname"].Value.ToString();
            txtcustomerTelephone.Text = datagridview1.CurrentRow.Cells["CustomerTelephone"].Value.ToString();
            txtcustomerOccupotion.Text = datagridview1.CurrentRow.Cells["CustomerOccupotion"].Value.ToString();
            rctxtcustomerAddress.Text = datagridview1.CurrentRow.Cells["CustomerAddress"].Value.ToString();
            rctxtcustomerDetails.Text = datagridview1.CurrentRow.Cells["CustomerDetails"].Value.ToString();
            txtcustomerAccount.Text = datagridview1.CurrentRow.Cells["CustomerAccount"].Value.ToString();
        }
    }
}
