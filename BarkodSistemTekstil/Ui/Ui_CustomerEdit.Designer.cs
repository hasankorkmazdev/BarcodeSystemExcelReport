namespace BarkodSistemTekstil.Ui
{
    partial class Ui_CustomerEdit
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtcustomerTelephone = new System.Windows.Forms.MaskedTextBox();
            this.btncustomerDelete = new System.Windows.Forms.Button();
            this.cmbcustomerReference = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcustomerAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btncustomerEdit = new System.Windows.Forms.Button();
            this.rctxtcustomerDetails = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCustomerSurname = new System.Windows.Forms.TextBox();
            this.txtcustomerName = new System.Windows.Forms.TextBox();
            this.txtcustomerOccupotion = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.rctxtcustomerAddress = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datagridview1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtcustomerTelephone);
            this.groupBox3.Controls.Add(this.btncustomerDelete);
            this.groupBox3.Controls.Add(this.cmbcustomerReference);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtcustomerAccount);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btncustomerEdit);
            this.groupBox3.Controls.Add(this.rctxtcustomerDetails);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txtCustomerSurname);
            this.groupBox3.Controls.Add(this.txtcustomerName);
            this.groupBox3.Controls.Add(this.txtcustomerOccupotion);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.rctxtcustomerAddress);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(570, 515);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Müşteri Ekle Düzenle";
            // 
            // txtcustomerTelephone
            // 
            this.txtcustomerTelephone.BeepOnError = true;
            this.txtcustomerTelephone.Location = new System.Drawing.Point(270, 111);
            this.txtcustomerTelephone.Mask = "(999)000-00-00";
            this.txtcustomerTelephone.Name = "txtcustomerTelephone";
            this.txtcustomerTelephone.Size = new System.Drawing.Size(287, 36);
            this.txtcustomerTelephone.TabIndex = 28;
            // 
            // btncustomerDelete
            // 
            this.btncustomerDelete.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btncustomerDelete.Location = new System.Drawing.Point(289, 452);
            this.btncustomerDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btncustomerDelete.Name = "btncustomerDelete";
            this.btncustomerDelete.Size = new System.Drawing.Size(275, 52);
            this.btncustomerDelete.TabIndex = 27;
            this.btncustomerDelete.Text = "Sil";
            this.btncustomerDelete.UseVisualStyleBackColor = true;
            this.btncustomerDelete.Click += new System.EventHandler(this.btncustomerDelete_Click);
            // 
            // cmbcustomerReference
            // 
            this.cmbcustomerReference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbcustomerReference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcustomerReference.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbcustomerReference.FormattingEnabled = true;
            this.cmbcustomerReference.Location = new System.Drawing.Point(270, 190);
            this.cmbcustomerReference.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcustomerReference.Name = "cmbcustomerReference";
            this.cmbcustomerReference.Size = new System.Drawing.Size(287, 35);
            this.cmbcustomerReference.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(524, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 30);
            this.label3.TabIndex = 26;
            this.label3.Text = "TL";
            // 
            // txtcustomerAccount
            // 
            this.txtcustomerAccount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtcustomerAccount.Location = new System.Drawing.Point(271, 229);
            this.txtcustomerAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcustomerAccount.Name = "txtcustomerAccount";
            this.txtcustomerAccount.Size = new System.Drawing.Size(247, 36);
            this.txtcustomerAccount.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(5, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 30);
            this.label2.TabIndex = 24;
            this.label2.Text = "Müşterinin Hesabı :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(5, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "Müşterinin Referansi :";
            // 
            // btncustomerEdit
            // 
            this.btncustomerEdit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btncustomerEdit.Location = new System.Drawing.Point(5, 452);
            this.btncustomerEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btncustomerEdit.Name = "btncustomerEdit";
            this.btncustomerEdit.Size = new System.Drawing.Size(281, 52);
            this.btncustomerEdit.TabIndex = 9;
            this.btncustomerEdit.Text = "Düzenle";
            this.btncustomerEdit.UseVisualStyleBackColor = true;
            this.btncustomerEdit.Click += new System.EventHandler(this.btncustomerEdit_Click);
            // 
            // rctxtcustomerDetails
            // 
            this.rctxtcustomerDetails.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rctxtcustomerDetails.Location = new System.Drawing.Point(270, 363);
            this.rctxtcustomerDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rctxtcustomerDetails.Name = "rctxtcustomerDetails";
            this.rctxtcustomerDetails.Size = new System.Drawing.Size(289, 85);
            this.rctxtcustomerDetails.TabIndex = 8;
            this.rctxtcustomerDetails.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(4, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "Müşteri Soyadi :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(5, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 30);
            this.label13.TabIndex = 5;
            this.label13.Text = "Müşteri Adi :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(6, 390);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(226, 30);
            this.label19.TabIndex = 17;
            this.label19.Text = "Müşterinin Detay :";
            // 
            // txtCustomerSurname
            // 
            this.txtCustomerSurname.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCustomerSurname.Location = new System.Drawing.Point(270, 74);
            this.txtCustomerSurname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerSurname.Name = "txtCustomerSurname";
            this.txtCustomerSurname.Size = new System.Drawing.Size(287, 36);
            this.txtCustomerSurname.TabIndex = 0;
            // 
            // txtcustomerName
            // 
            this.txtcustomerName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtcustomerName.Location = new System.Drawing.Point(271, 37);
            this.txtcustomerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcustomerName.Name = "txtcustomerName";
            this.txtcustomerName.Size = new System.Drawing.Size(286, 36);
            this.txtcustomerName.TabIndex = 0;
            // 
            // txtcustomerOccupotion
            // 
            this.txtcustomerOccupotion.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtcustomerOccupotion.Location = new System.Drawing.Point(271, 152);
            this.txtcustomerOccupotion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcustomerOccupotion.Name = "txtcustomerOccupotion";
            this.txtcustomerOccupotion.Size = new System.Drawing.Size(286, 36);
            this.txtcustomerOccupotion.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(5, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(222, 30);
            this.label15.TabIndex = 8;
            this.label15.Text = "Müşteri Telefonu :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(5, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(248, 30);
            this.label16.TabIndex = 9;
            this.label16.Text = "Müşterinin Mesleği :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.Location = new System.Drawing.Point(6, 302);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(227, 30);
            this.label17.TabIndex = 10;
            this.label17.Text = "Müşterinin Adresi :";
            // 
            // rctxtcustomerAddress
            // 
            this.rctxtcustomerAddress.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rctxtcustomerAddress.Location = new System.Drawing.Point(270, 273);
            this.rctxtcustomerAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rctxtcustomerAddress.Name = "rctxtcustomerAddress";
            this.rctxtcustomerAddress.Size = new System.Drawing.Size(289, 85);
            this.rctxtcustomerAddress.TabIndex = 7;
            this.rctxtcustomerAddress.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.Location = new System.Drawing.Point(622, 3);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(228, 36);
            this.textBox2.TabIndex = 44;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(418, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 30);
            this.label6.TabIndex = 43;
            this.label6.Text = "Müşteri Soyadi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(20, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 30);
            this.label5.TabIndex = 42;
            this.label5.Text = "Müşteri Adi :";
            // 
            // datagridview1
            // 
            this.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.datagridview1.Location = new System.Drawing.Point(0, 50);
            this.datagridview1.Name = "datagridview1";
            this.datagridview1.RowTemplate.Height = 24;
            this.datagridview1.Size = new System.Drawing.Size(1066, 440);
            this.datagridview1.TabIndex = 40;
            this.datagridview1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview1_CellClick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(184, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 36);
            this.textBox1.TabIndex = 41;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datagridview1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(577, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 490);
            this.panel1.TabIndex = 45;
            // 
            // Ui_CustomerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ui_CustomerEdit";
            this.Size = new System.Drawing.Size(1655, 1373);
            this.Load += new System.EventHandler(this.Ui_CustomerEdit_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btncustomerDelete;
        private System.Windows.Forms.ComboBox cmbcustomerReference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcustomerAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncustomerEdit;
        private System.Windows.Forms.RichTextBox rctxtcustomerDetails;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtcustomerName;
        private System.Windows.Forms.TextBox txtcustomerOccupotion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox rctxtcustomerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerSurname;
        private System.Windows.Forms.MaskedTextBox txtcustomerTelephone;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView datagridview1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
