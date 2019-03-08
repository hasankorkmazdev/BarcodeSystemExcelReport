using System;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Ui
{
    public partial class Discount : Form
    {
        static Discount dsc;
        public Discount()
        {
            InitializeComponent();
        }
        static decimal discount = 0;
        public static decimal  Show()
        {
            dsc = new Discount();
            dsc.ShowDialog();
            return discount;
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
           discount= Convert.ToDecimal(txtDiscount.Text);
           dsc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            discount = 0;
            dsc.Close();
        }
    }
}
