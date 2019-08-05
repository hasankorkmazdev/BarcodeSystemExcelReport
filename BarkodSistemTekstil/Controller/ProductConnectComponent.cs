using BarkodSistemTekstil.Class;
using BarkodSistemTekstil.Model;
using BarkodSistemTekstil.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Controller
{
    class ProductConnectComponent
    {
        ProductProc prc = new ProductProc();

    

        public int UrunEkle(TextBox Barkod, TextBox name, ComboBox KategoriID, RichTextBox description, NumericUpDown satisfiyat)
        {
            int productState = 0;
            if (String.IsNullOrEmpty(Barkod.Text) || String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(KategoriID.Text) || String.IsNullOrEmpty(description.Text) || String.IsNullOrEmpty(satisfiyat.Value.ToString()) || String.IsNullOrEmpty( KategoriID.SelectedIndex.ToString()))
            {
                //Null Değer Döndü
                return -1;
            
            }
            else
            {
                try
                {
                   productState= prc.UrunEkle(Barkod.Text.ToString(), name.Text.ToString(), (int)KategoriID.SelectedValue, description.Text, (double)satisfiyat.Value);
                    if (productState==1)
                    {
                        MessageDöndür.Message(Barkod.Text + " Barkodlu ürün Veritabanına Eklenmiştir", "İşlem Tamamlandı", MessageDöndür.MessageIcon.OK, MessageDöndür.MessageButton.OK);

                    }
                    else if (productState==-2)
                    {
                        MessageDöndür.Message(Barkod.Text + " Bu ürün zaten Veritabanında Var !\nBu ürünü silip yeniden deneyin...", "İşlem Tamamlanamadı", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                    }
                    return productState;
                }
                catch (Exception)
                {
                    
                    MessageDöndür.Message("Veritabanı Hatası... !", "İşlem Tamamlanamadı", MessageDöndür.MessageIcon.Eror, MessageDöndür.MessageButton.OK);
                    return -1;
                }
               
            }
        }
        public int UrunDuzenle(TextBox Barkod, TextBox name, ComboBox KategoriID, RichTextBox description, NumericUpDown satisfiyat)
        {
            if (String.IsNullOrEmpty(Barkod.Text) || String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(KategoriID.Text) || String.IsNullOrEmpty(description.Text) || String.IsNullOrEmpty(satisfiyat.Value.ToString()) || String.IsNullOrEmpty(KategoriID.SelectedIndex.ToString()))
            {
                //Null Değer Döndü
                return -1;

            }
            else
            {
                try
                {
                    prc.UrunDuzenle(Barkod.Text.ToString(), name.Text.ToString(), KategoriID.SelectedIndex, description.Text, (double)satisfiyat.Value);
                    return 1;
                }
                catch (Exception)
                {
                    return -1;
                }

            }
        }
        public int UrunSil(TextBox Barkod)
        {
            if (!String.IsNullOrEmpty(Barkod.Text))
            {
                try
                {
                    prc.UrunSil(Barkod.Text);
                    return 1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        public Product UrunAra(TextBox Barkod)
        {
            if (!String.IsNullOrEmpty(Barkod.Text))
            {
                try
                {
                    return prc.UrunAra(Barkod.Text);
                    
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }
        }
        public IQueryable UrunListele(TextBox Barkod)
        {
            if (!String.IsNullOrEmpty(Barkod.Text))
            {
                try
                {
                    return prc.UrunleriListele(Barkod.Text);
                }
                catch (Exception)
                {
                    return null;
                }
                
            }
            else
            {
                return null;
            }
        }
        public ComboBox KategoriListesi(ComboBox cmbProductCategory)
        {
            cmbProductCategory.DataSource = prc.KategoriListesi();
            cmbProductCategory.DisplayMember = "CategoryName";
            cmbProductCategory.ValueMember = "CategoryID";
            return cmbProductCategory;

        }
    }
}
