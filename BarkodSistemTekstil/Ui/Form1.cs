using BarkodSistemTekstil.Class;
using BarkodSistemTekstil.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerProc prc = new CustomerProc();
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.FileStream fs = new System.IO.FileStream(Application.StartupPath + "\\" + "First-PDF-document.pdf", System.IO.FileMode.Create);
            Document document = new Document(PageSize.A4, 10, 10, 10, 15);

            // Create an instance to the PDF file by creating an instance of the PDF   
            // Writer class using the document and the filestrem in the constructor.
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            // Ek Bilgiler 
            document.AddAuthor("Micke Blomquist");
            document.AddCreator("Sample application using iTextSharp");
            document.AddKeywords("PDF tutorial education");
            document.AddSubject("Document subject - Describing the steps creating a PDF document");
            document.AddTitle("The document title - PDF creation using iTextSharp");
            // Open the document to enable you to write to the document  
            document.Open();
            // Add a simple and wellknown phrase to the document in a flow layout manner  
            //Paragraph p= new Paragraph("Müsteri Listesi", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK));
            //p.Alignment = Element.ALIGN_CENTER;
            //document.Add(p);

            PdfPTable ptable = new PdfPTable(4);






            Model.BarcodeSystemDataContext data = new BarcodeSystemDataContext();
            double Veresiye = 0;
            double Nakit = 0;
            double Kredi = 0;
            double Toplam = 0;
            double totalDiscount = 0;
            double islemeyapilantotalürüniskontosu = 0;
            int nakitIslemSayisi = 0;
            int veresiyeIslemSayisi = 0;
            int krediIslemSayisi = 0;
            var query = from q in data.Sale
                        where q.SaleDate == DateTime.Now
                        select q;
            if (query.Count() <= 0)
            {
                MessageDöndür.Message("Bugün Ürün Satışı Yapılmamıştır", "Boş Liste Döndü", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);

            }
            else
            {


                var p = new PdfPCell(new Phrase("24 Saatlik Satis Raporu"));
                p.Colspan = 4;
                p.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(p);
                ptable.AddCell("Islem Tutari");
                ptable.AddCell("Islem Tipi");
                ptable.AddCell("Yapılan Toplam Indirim");
                ptable.AddCell("Yapılan Urün Indirimi");
                foreach (var item in query)
                {
                    totalDiscount = 0;
                    if (item.TotalDiscount >= 0)
                    {
                        totalDiscount += (double)item.TotalDiscount;
                    }
                    //Nakit İşlem
                    if (item.PaymentMethodSale == 1)
                    {
                        Nakit += (double)item.TotalPrice;
                        nakitIslemSayisi++;
                    }
                    //Kredi İşlem
                    else if (item.PaymentMethodSale == 2)
                    {
                        Kredi += (double)item.TotalPrice;
                        krediIslemSayisi++;
                    }
                    //Veresiye İşlem
                    else if (item.PaymentMethodSale == 3)
                    {
                        Veresiye += (double)item.TotalPrice;
                        veresiyeIslemSayisi++;
                    }

                    var operationProductID = from q in data.OpeationProduct
                                             where q.SaleProduct == item.SaleID
                                             select q;
                    foreach (var productDC in operationProductID)
                    {
                        islemeyapilantotalürüniskontosu += (double)productDC.ProductDiscount;
                    }
                    ptable.AddCell(item.TotalPrice.ToString());
                    ptable.AddCell(item.SubTboPaymentMethod.PaymentMethodName);
                    ptable.AddCell(item.TotalDiscount.ToString());
                    ptable.AddCell(islemeyapilantotalürüniskontosu.ToString());
                    islemeyapilantotalürüniskontosu = 0;
                }
                Toplam += (Veresiye + Nakit + Kredi);
                var ToplamIslemSayisi = new PdfPCell(new Phrase("Toplam islem Sayisi :" + (krediIslemSayisi + nakitIslemSayisi + veresiyeIslemSayisi)));
                ToplamIslemSayisi.Colspan = 2;
                ToplamIslemSayisi.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(ToplamIslemSayisi);
                var ToplamTutar = new PdfPCell(new Phrase("ToplamTutar :" + Toplam + " TL"));
                ToplamTutar.Colspan = 2;
                ToplamTutar.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(ToplamTutar);
                var NakitIslemSayisi = new PdfPCell(new Phrase("Nakit islem Sayisi :" + nakitIslemSayisi));
                NakitIslemSayisi.Colspan = 2;
                NakitIslemSayisi.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(NakitIslemSayisi);
                var NakitToplamSayisi = new PdfPCell(new Phrase(" Nakit Tutar :" + Nakit + " TL"));
                NakitToplamSayisi.Colspan = 2;
                NakitToplamSayisi.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(NakitToplamSayisi);
                var KrediIslemSayisi = new PdfPCell(new Phrase("Kredi islem Sayisi :" + krediIslemSayisi + " Kredi Tutar" + Kredi + " TL"));
                KrediIslemSayisi.Colspan = 2;
                KrediIslemSayisi.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(KrediIslemSayisi);
                var KrediTutar = new PdfPCell(new Phrase(" Kredi Tutar" + Kredi + " TL"));
                KrediTutar.Colspan = 2;
                KrediTutar.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(KrediTutar);
                var VeresiyeIslemSayisi = new PdfPCell(new Phrase("Veresiye islem Sayisi :" + veresiyeIslemSayisi));
                VeresiyeIslemSayisi.Colspan = 2;
                VeresiyeIslemSayisi.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(VeresiyeIslemSayisi);
                var VeresiyeToplam = new PdfPCell(new Phrase(" Veresiye Tutar :" + Veresiye + " TL"));
                VeresiyeToplam.Colspan = 2;
                VeresiyeToplam.HorizontalAlignment = Element.ALIGN_CENTER;
                ptable.AddCell(VeresiyeToplam);
                /*

                rpt.WriteCell(row + 3, 2, "Veresiye :" + Veresiye + " TL");

                  rpt.WriteCell(row + 5, 0, "Nakit İslem :" + nakitIslemSayisi);
                  rpt.WriteCell(row + 5, 1, "Kredi İslem :" + krediIslemSayisi);
                  rpt.WriteCell(row + 5, 2, "Veresiye İslem :" + veresiyeIslemSayisi);

                  rpt.SaveAs(Application.StartupPath + "24SaatRapor.xlsx");
                  rpt.RamClose();*/
            }
            document.Add(ptable);
            // Close the document  
            document.Close();
            // Close the writer instance  
            writer.Close();
            // Always close open filehandles explicity  
            fs.Close();
            Process.Start("chrome", Application.StartupPath + "\\" + "First-PDF-document.pdf");

        }
    }
}
