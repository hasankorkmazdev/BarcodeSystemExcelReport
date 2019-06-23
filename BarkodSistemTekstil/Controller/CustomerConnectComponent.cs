using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Controller
{
    class CustomerConnectComponent
    {
        Class.CustomerProc Custom = new Class.CustomerProc();
        DataGridView datagridprops = new DataGridView();
        
        public DataGridView musterileriDoldur(DataGridView DGV)
        {
            DGV.DataSource = Custom.MusteriListesi();
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
        public DataGridView musterileriDoldur(DataGridView DGV,string adi)
        {
            DGV.DataSource = Custom.MusteriListesi(adi);
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
        public DataGridView musterileriDoldur(DataGridView DGV,string adi, string soyadi)
        {

            DGV.DataSource = Custom.MusteriListesi(adi, soyadi);
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
            cmbCustomerRefrence.DataSource = new BindingSource(Custom.ReferanslarListesi(), null);
            cmbCustomerRefrence.DisplayMember = "Value";
            cmbCustomerRefrence.ValueMember = "Key";
            return cmbCustomerRefrence;

        }
    }
}
