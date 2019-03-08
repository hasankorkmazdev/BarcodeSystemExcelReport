using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Ui
{
    public partial class Ui_Repo : UserControl
    {
        public Ui_Repo()
        {
            InitializeComponent();
        }


        int selectedIndex=-1;
        private void Ui_Repo_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            listBox1.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Class.Routing.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "Ne raporu Oluşturacaksınız ?";
          
            listBox1.Visible = true;
            
            selectedIndex = listBox1.SelectedIndex;
            if(selectedIndex==0)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Ürün Listesi");
                listBox1.Items.Add("Ürünün Raporu");
            }
            else if (selectedIndex==1)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Ürününlerin Listesi");
                listBox1.Items.Add("Ürüne Ait Satış Raporu");
                listBox1.Items.Add("Ürün Alım Raporu");
               
            }
            else if (selectedIndex==2)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Müşteri Listesi");
                listBox1.Items.Add("Müşteri Dökümleri");
            }
        }
    }
}
