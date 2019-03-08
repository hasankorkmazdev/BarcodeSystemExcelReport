using BarkodSistemTekstil.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BarkodSistemTekstil.Ui
{
    public partial class MessageDöndür : Form{
        static MessageDöndür msgBox;
        public enum MessageIcon { OK=0,Eror,Trash,Information }
        public enum MessageButton { YesNo, YesNoCancel, OK,OKCancel }
        public enum MessageResult { Yes,No,OK,Cancel}
        private static  MessageResult msj=MessageResult.OK;
        private MessageDöndür()
        {
            InitializeComponent();
        }

        public static MessageResult Message(string icerik)
        {
            msgBox = new MessageDöndür();
            msgBox.lblMesaj.Text = icerik;
            msgBox.ShowDialog();
            msgBox.button1.Text = "Tamam";
            msgBox.button2.Visible = false;
            msgBox.button3.Visible = false;
            return msj;
            
        }
        public static MessageResult Message(string icerik,string baslik)
        {
            msgBox = new MessageDöndür();
            msgBox.lblMesaj.Text = icerik;
            msgBox.label2.Text = baslik;
            msgBox.button1.Text = "Tamam";
            msgBox.button2.Visible = false;
            msgBox.button3.Visible = false;
            msgBox.ShowDialog();
            return msj;
        }
        public static MessageResult Message(string icerik, string baslik,MessageIcon icon)
        {
            msgBox = new MessageDöndür();
            switch (icon)
            {
                case MessageIcon.OK:
                    msgBox.pictureBox1.Image = Resources.Okico;
                    
                 
                    break;
                case MessageIcon.Eror:
                    msgBox.pictureBox1.Image = Resources.ErorIco;
                   
                    break;
                case MessageIcon.Trash:
                    msgBox.pictureBox1.Image = Resources.TrashIco;
                    break;
                case MessageIcon.Information:
                    msgBox.pictureBox1.Image = Resources.InfoIco;
                    break;
                default:
                    break;
            }
            msgBox.lblMesaj.Text = icerik;
            msgBox.label2.Text = baslik;
            msgBox.button1.Text = "Tamam";
            msgBox.button2.Visible = false;
            msgBox.button3.Visible = false;
            msgBox.ShowDialog();
            return msj;
        }
        public static MessageResult Message(string icerik, string baslik, MessageIcon icon,MessageButton button )
        {
            msgBox = new MessageDöndür();
            switch(icon)
            {
                case MessageIcon.OK:
                    msgBox.pictureBox1.Image = Resources.Okico;
                    msgBox.panel5.BackColor = Color.LawnGreen;
                    msgBox.panel6.BackColor = Color.LawnGreen;
                    break;
                case MessageIcon.Eror:
                    msgBox.pictureBox1.Image = Resources.ErorIco;
                    msgBox.panel6.BackColor = Color.FromArgb(255, 83, 73);
                    msgBox.panel5.BackColor = Color.FromArgb(255, 83, 73);
                    break;
                case MessageIcon.Trash:
                    msgBox.pictureBox1.Image = Resources.TrashIco;
                    msgBox.panel5.BackColor = Color.FromArgb(255, 247, 0);
                    msgBox.panel6.BackColor = Color.FromArgb(255, 247, 0);
                    break;
                case MessageIcon.Information:
                    msgBox.pictureBox1.Image = Resources.InfoIco;
                    msgBox.panel6.BackColor = Color.FromArgb(0, 102, 255);
                    msgBox.panel5.BackColor = Color.FromArgb(0, 102, 255);
                    break;
                default:
                    break;
            }
            switch(button)
            {
                case MessageButton.OK:
                    msgBox.button1.Text = "Tamam";
                    msgBox.button2.Visible = false;
                    msgBox.button3.Visible = false;
                    break;
                case MessageButton.OKCancel:
                    msgBox.button1.Text = "Tamam";
                    msgBox.button2.Text = "İptal";
                    msgBox.button3.Visible = false;
                    break;
                case MessageButton.YesNo:
                    msgBox.button1.Text = "Evet";
                    msgBox.button2.Text = "Hayır";
                    msgBox.button3.Visible = false;
                    break;
                case MessageButton.YesNoCancel:
                    msgBox.button1.Text = "Evet";
                    msgBox.button2.Text = "Hayır";
                    msgBox.button3.Text = "İptal";
                    break;
                   

            }
            msgBox.label2.Text = baslik;
            msgBox.lblMesaj.Text = icerik;
            msgBox.ShowDialog();
            return msj;
        }
        private void lblMesaj_Resize(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(lblMesaj.Width + 100, lblMesaj.Height + 100);
            button1.Location = new Point(panel2.Width - 75,2);
            button2.Location = new Point(panel2.Width - 147,2);
            button3.Location = new Point(panel2.Width - 220,2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Tamam")
            {
                msj = MessageResult.OK;
            }
            else if (button1.Text == "Evet")
            {
                msj = MessageResult.Yes;
            }
            msgBox.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Hayır")
            {
                msj = MessageResult.No;
            }
            else if (button2.Text == "İptal")
            {
                msj = MessageResult.Cancel;
            }
            msgBox.Close();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            msj = MessageResult.Cancel;
            msgBox.Close();
        }

    }
}
