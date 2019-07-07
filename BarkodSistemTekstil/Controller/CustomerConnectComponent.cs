using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarkodSistemTekstil.Class;
using BarkodSistemTekstil.Model;
using BarkodSistemTekstil.Ui;

namespace BarkodSistemTekstil.Controller
{
    class CustomerConnectComponent
    {
        Class.CustomerProc Customproc = new Class.CustomerProc();
        Customer cust = new Customer();
        DataGridView datagridprops = new DataGridView();

        public DataGridView musterileriDoldur(DataGridView DGV)
        {
            DGV.DataSource = Customproc.MusteriListesi();
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
            return DGV;
        }
        public DataGridView musterileriDoldur(DataGridView DGV, string adi)
        {
            DGV.DataSource = Customproc.MusteriListesi(adi);
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
            return DGV;
        }
        public DataGridView musterileriDoldur(DataGridView DGV, string adi, string soyadi)
        {

            DGV.DataSource = Customproc.MusteriListesi(adi, soyadi);
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
            return DGV;
        }
        public ComboBox cmboboxReferansDoldur(ComboBox cmbCustomerRefrence)
        {
            cmbCustomerRefrence.DataSource = new BindingSource(Customproc.ReferanslarListesi(), null);
            cmbCustomerRefrence.DisplayMember = "Value";
            cmbCustomerRefrence.ValueMember = "Key";
            return cmbCustomerRefrence;

        }
        public int musteriEkleControl(TextBox txname, TextBox txsoyisim, MaskedTextBox txtel, TextBox txmeslek, ComboBox cmbreferans, NumericUpDown txbakiye, RichTextBox adres, RichTextBox detay)
        {

            if (cmbreferans.SelectedValue == null)
            {
                MessageDöndür.Message("Referans Kısmında Hata Oluştu...\n" +
                    "Muhtemelen Açılır Listede Olmayan Bir Referans Seçtiniz...\n" +
                    "Lütfen Açılır Listeden Referansi Doğru Şekilde Seçiniz...\n" +
                    "Eğer Referans Seçmiyecekseniz Referans Bölümüne 1 Yazmanız Yeterlidir", "Referans Seçim Bloğunda Hata Oluştu", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                return -1;

            }
            else if (cmbreferans.Text == "1" &&
                string.IsNullOrWhiteSpace(txname.Text) != true &&
                string.IsNullOrWhiteSpace(txsoyisim.Text) != true)
            {
                Customproc = new CustomerProc();
                Customproc.MusteriEkleProc(txname.Text, txsoyisim.Text, txtel.Text, txmeslek.Text, (int)cmbreferans.SelectedValue, txbakiye.Text, adres.Text, detay.Text);
                CustomMessage.CustomMsg.Message(txname.Text + " " + txsoyisim.Text + "\n" +
                                "Adli Müşteri Kaydedildi",
                                "Müsteri Kayıt İşlemi Başarılı", CustomMessage.CustomMsg.MessageIcon.Information
                                , CustomMessage.CustomMsg.MessageButton.OK);
            }
            else if (string.IsNullOrWhiteSpace(cmbreferans.Text) != true &&
                string.IsNullOrWhiteSpace(txname.Text) != true &&
                string.IsNullOrWhiteSpace(txsoyisim.Text) != true)
            {
                Customproc = new CustomerProc();
                Customproc.MusteriEkleProc(txname.Text, txsoyisim.Text, txtel.Text, txmeslek.Text, (int)cmbreferans.SelectedValue, txbakiye.Text, adres.Text, detay.Text);
                CustomMessage.CustomMsg.Message(txname.Text + " " + txsoyisim.Text + "\n" +
                                "Adli Müşteri Kaydedildi",
                                "Müsteri Kayıt İşlemi Başarılı", CustomMessage.CustomMsg.MessageIcon.Information
                                , CustomMessage.CustomMsg.MessageButton.OK);
            }
            else
            {
                MessageBox.Show("Yeni Müşteri Ekleme Başarısız Oldu...\n" +
                    "Verileri Doğru Girdiğinizden Emin Olun", "Girdilerde Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



            return 1;
        }
        public void musteriSilControl(int mID)
        {
            Customproc = new CustomerProc();
            cust = new Customer();
            cust = Customproc.MusteriIDyeGöreAra(mID);
            if (cust.CustomerAccount > 0)
            {
                DialogResult result = MessageBox.Show(cust.CustomerName + " " + cust.CustomerSurname + " Müsteriyi Silmek Üzeresiniz..."
                                                 + cust.CustomerName + cust.CustomerSurname + " İsmindeki Müşterinin Borç durumu: "
                                              + cust.CustomerAccount + "\n\nYinede Silmeye Devam Edilsinmi ?",
                                             "Silme İşlemi Yetkilendirilmesi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(cust.CustomerName + " " + cust.CustomerSurname + " Adindaki Müsteri Silindi", "Müsteri Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Customproc.MusteriSil(cust);
                }
                else
                {
                    MessageBox.Show("Müşteri Silme İşlemi İptal Edildi..", "Müsteri Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void musteriDuzenleControl(int mID, TextBox txname, TextBox txsoyisim, MaskedTextBox txtel, TextBox txmeslek, ComboBox cmbreferans, NumericUpDown txbakiye, RichTextBox adres, RichTextBox detay)
        {
            Customproc = new CustomerProc();

            if (cmbreferans.SelectedValue == null)
            {
                MessageDöndür.Message("Referans Kısmında Hata Oluştu...\n" +
                    "Muhtemelen Açılır Listede Olmayan Bir Referans Seçtiniz...\n" +
                    "Lütfen Açılır Listeden Referansi Doğru Şekilde Seçiniz...\n" +
                    "Eğer Referans Seçmiyecekseniz Referans Bölümüne 1 Yazmanız Yeterlidir", "Referans Seçim Bloğunda Hata Oluştu", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);

            }
            else
            {
                if (cmbreferans.Text == "1")
                {
                    if (Customproc.MusteriDuzenle(Customproc.MusteriIDyeGöreAra(mID), Customproc.ReferansAra(mID),
                        txname.Text, txsoyisim.Text, txtel.Text, txmeslek.Text, 1, Convert.ToDecimal(txbakiye.Value),
                         adres.Text, detay.Text) == 1)
                    {
                        MessageDöndür.Message(txname.Text + " " + txsoyisim.Text + "\n" +
                                        "Adli Müşteri Kaydedildi",
                                        "Müsteri Düzenleme İşlemi Başarılı",
                                        MessageDöndür.MessageIcon.Information,
                                        MessageDöndür.MessageButton.OK);
                    }
                }
                else if (string.IsNullOrWhiteSpace(cmbreferans.Text) != true &&
                    string.IsNullOrWhiteSpace(txname.Text) != true &&
                    string.IsNullOrWhiteSpace(txsoyisim.Text) != true)
                {
                    if (Customproc.MusteriDuzenle(Customproc.MusteriIDyeGöreAra(mID), Customproc.ReferansAra(mID),
                        txname.Text, txsoyisim.Text, txtel.Text, txmeslek.Text, (int)cmbreferans.SelectedValue, Convert.ToDecimal(txbakiye.Value),
                         adres.Text, detay.Text) == 1)
                    {
                        MessageDöndür.Message(txname.Text + " " + txsoyisim.Text + "\n" +
                                        "Adli Müşteri Kaydedildi",
                                        "Müsteri Kayıt İşlemi Başarılı",
                                        MessageDöndür.MessageIcon.Information,
                                        MessageDöndür.MessageButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri Düzenleme İşlemi Başarısız...\n" +
                        "Verileri Doğru Girdiğinizden Emin Olun", "Girdilerde Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }
    }
}
