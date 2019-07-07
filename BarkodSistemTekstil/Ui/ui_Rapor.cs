using ExcelReport;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace BarkodSistemTekstil.Ui
{
    public partial class ui_Rapor : UserControl
    {
        public ui_Rapor()
        {
            InitializeComponent();
        }
        Model.BarcodeSystemDataContext data = new Model.BarcodeSystemDataContext();
        int i = 2;
        string logoPath;
        Report rpt = new Report();
        
        private void btnUygula_Click(object sender, EventArgs e)
        {
           

            //Report rpt = new Report(@"C:\Users\PC\Desktop\Customer.xlsx", 1);

            rpt.Border = true;
            rpt.Visibility = true;
            rpt.NewApp("Karaca");
            
           /* var query = (from q in data.Customer
                       // select q).ToList();
            foreach (var item in query)
            {
                rpt.Border = true;
                rpt.Write(i, 1, item.CustomerName);
                rpt.Write(i, 2, item.CustomerSurname);
                rpt.Write(i, 3, item.CustomerOccupotion);
                rpt.Write(i, 4, item.CustomerAccount.ToString() + "TL");
                i++;
            }*/

            rpt.LeftFooterText(DateTime.Now.ToString());
            rpt.LeftHeaderLogo(logoPath);
           
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Resim Dosyası |*.png| Resim Dosyası |*.jpeg| Resim Dosyası |*.JPG|Resim Dosyası | *.ico";
            file.RestoreDirectory = true;
            file.Title = "Yüklemek İstenen Logo Dosyası";
            file.ShowDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                logoPath = file.FileName;
                Clipboard.SetDataObject((object)logoPath, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;
            MessageBox.Show(misValue.ToString());
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class.Routing.AddPage(new Ui.Ui_Wizard());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ui.Form1 f1 = new Form1();
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExcelReport.Report rep = new Report();
            
            rep.WriteCell(1, 1, "Hasan");
        }
    }
}
