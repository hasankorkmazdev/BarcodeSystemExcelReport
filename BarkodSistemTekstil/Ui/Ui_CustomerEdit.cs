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
        CustomerConnectComponent CCC = new CustomerConnectComponent();
        private void Ui_CustomerEdit_Load(object sender, EventArgs e)
        {
            CCC.cmboboxReferansDoldur(cmbcustomerReference);
            CCC.musterileriDoldur(datagridview);
            datagridview.AllowUserToAddRows = false;
        }


        #region Buton-Sil 
        int custID = -1;
        private void btncustomerDelete_Click(object sender, EventArgs e)
        {
            CCC.musteriSilControl((int)datagridview.CurrentRow.Cells["CustomerID"].Value);
            CCC.musterileriDoldur(datagridview);
        }
        #endregion

        #region Buton-Düzenle
        private void btncustomerEdit_Click(object sender, EventArgs e)
        {
             CCC = new CustomerConnectComponent();
            CCC.musteriDuzenleControl((int)datagridview.CurrentRow.Cells["CustomerID"].Value, txtcustomerName, txtCustomerSurname, txtcustomerTelephone, txtcustomerOccupotion, cmbcustomerReference, txtcustomerAccount, rctxtcustomerAddress, rctxtcustomerDetails);
            CCC.musterileriDoldur(datagridview);
            CCC.cmboboxReferansDoldur(cmbcustomerReference);
            foreach (var item in this.groupBox3.Controls)
            {
                if (item is TextBox )
                {
                    TextBox tx =(TextBox) item;
                    tx.Clear();
                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown num =(NumericUpDown) item;
                    num.Value = 0;
                }
                else if (item is RichTextBox)
                {
                    RichTextBox rx = (RichTextBox)item;
                    rx.Clear();
                }
                else if (item is MaskedTextBox)
                {
                    MaskedTextBox ms = (MaskedTextBox)item;
                    ms.Clear();

                }
            }
           
        }
        #endregion
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CCC.musterileriDoldur(datagridview, textBox1.Text);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CCC.musterileriDoldur(datagridview, textBox1.Text, textBox2.Text);
        }

        private void datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int refid = (int)datagridview.CurrentRow.Cells["CustomerReference"].Value;
            cmbcustomerReference.SelectedValue = refid;
            
            txtcustomerName.Text = datagridview.CurrentRow.Cells["CustomerName"].Value.ToString();
            txtCustomerSurname.Text = datagridview.CurrentRow.Cells["CustomerSurname"].Value.ToString();
            txtcustomerTelephone.Text = datagridview.CurrentRow.Cells["CustomerTelephone"].Value.ToString();
            txtcustomerOccupotion.Text = datagridview.CurrentRow.Cells["CustomerOccupotion"].Value.ToString();
            rctxtcustomerAddress.Text = datagridview.CurrentRow.Cells["CustomerAddress"].Value.ToString();
            rctxtcustomerDetails.Text = datagridview.CurrentRow.Cells["CustomerDetails"].Value.ToString();
            txtcustomerAccount.Text = datagridview.CurrentRow.Cells["CustomerAccount"].Value.ToString();
        }
    }
}
