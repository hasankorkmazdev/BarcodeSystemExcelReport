using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp;

namespace BarkodSistemTekstil.Class
{
    class iTextSharpRapor
    {
        FileStream fs;
        /// <summary>
        /// dosya adi ve tipini parametre olarak geçir
        /// </summary>
        /// <param name="dosyaadi">abc</param>
        /// <param name="dosyatip">.pdf</param>
        iTextSharpRapor(string dosyaadi, string dosyatip,string acces)
        {
            ;
            //Çalışılacak Dosya Yolu
            string Path = Application.StartupPath + @"\" + dosyaadi + dosyatip;
            if (File.Exists(Path))//Böyle bi Pdf Varmı ?
            {
                DialogResult dg = MessageBox.Show(dosyaadi + "." + dosyatip + " Böyle bir dosya zaten var !\n Üzerine Yazılsınmı ?", "Dosya İşlemleri", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (dg==DialogResult.Yes)
                {
                    fs = new FileStream(Path, FileMode.Append, FileAccess.Write);//Evet Var //Yolu,  Dosyanın Varlığı, Kullanım Tipi
                }
                else if (dg==DialogResult.No)
                {
                    fs = new FileStream(Path, FileMode.CreateNew, FileAccess.Write);
                }
            }
            else
            {
                //Yeni Oluştu..
                fs = new FileStream(Path, FileMode.CreateNew, FileAccess.Write);
            }
        }
        public void PdfWrite(string text)
        {
             
        }




    }


    }

