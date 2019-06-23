using System;
using System.Windows.Forms;
using BarkodSistemTekstil.Class;
using BarkodSistemTekstil.Ui.Customers;
using BarkodSistemTekstil.Ui;
using BarkodSistemTekstil.Controller;

namespace BarkodSistemTekstil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Routing.AddPage(new Ui_CustomerAdd());
        }
        private void button7_Click(object sender, EventArgs e)
        {
           Routing.AddPage(new Ui_ProductEditPage());
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Routing.AddPage(new Ui_ProductAddPage());
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Routing.AddPage(new Ui_CustomerEdit());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Routing.AddPage(new SalePage());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Routing.AddPage(new Ui.Ui_CustomerAccount());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Routing.AddPage(new Ui.ui_Rapor());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CustomerProc prc = new CustomerProc();
            CustomerConnectComponent con = new CustomerConnectComponent();
            con.musterileriDoldur(dataGridView1);
        }
    }
}
