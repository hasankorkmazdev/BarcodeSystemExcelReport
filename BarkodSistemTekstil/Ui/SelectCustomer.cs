using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using BarkodSistemTekstil.Controller;

namespace BarkodSistemTekstil.Ui
{
    public partial class SelectCustomer : Form
    {
        
        public SelectCustomer()
        {
            InitializeComponent();
            selectedid = -1;
        }
        static SelectCustomer sc;
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        private static int selectedid=-1;
        CustomerConnectComponent fonk = new CustomerConnectComponent();
        private void btnUygula_Click(object sender, EventArgs e)
        {
            if (selectedid==-1)
            {
                MessageDöndür.Message("Satış Yapılacak Müşteri Seçilmedi.\nYeniden Deneyin .", "Müşteri Seçim Ekranında Hata Oluştu !", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
            }
            else
            {
                selectedid =(int)customerDataGridView.CurrentRow.Cells["CustomerID"].Value;
                sc.Close();
            }
            
        }

        private void SelectCustomer_Load(object sender, EventArgs e)
        {
            //TODO:Customer Delete Edildiğinde ki Edilme Soft Delete Etmemiz Lazım Yoksa Satıştaki Kayıtlar Kaybolur
            fonk.musterileriDoldur(customerDataGridView);
        }
        /// <summary>
        /// Customer Sayfası Açılır Datagridviewden Müşteri Seçilir Bu Methodla Müşterinin ID'si geri Döner
        /// </summary>
        /// <returns>CustomerID</returns>
        public static int Show()
        {
            sc = new SelectCustomer();
            sc.ShowDialog();
            return selectedid;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

            fonk.musterileriDoldur(customerDataGridView, txtName.Text);
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            
            fonk.musterileriDoldur(customerDataGridView, txtName.Text,txtSurname.Text);
        }

        private void customerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedid = (int)customerDataGridView.CurrentRow.Cells["CustomerID"].Value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectedid = -1;
            sc.Close();
            
        }
    }
}
