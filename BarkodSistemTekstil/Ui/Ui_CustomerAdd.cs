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

        Controller.CustomerConnectComponent CCC = new Controller.CustomerConnectComponent();
      
        private void Ui_CustomerAdd_Load(object sender, EventArgs e)
        {
            CCC.cmboboxReferansDoldur(cmbCustomerRefrence);
        }
        private void btncustomerInsert_Click(object sender, EventArgs e)
        {
            CCC.musteriEkleControl(txtcustomerName, txtSurname, txtCustomerTelephone, txtcusomerOccupotion, cmbCustomerRefrence, txtcustomerAccount, rctxtcustomerAddress, rctxtcustomerDetail);
        }

      
    }
}
