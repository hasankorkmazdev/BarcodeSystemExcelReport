namespace BarkodSistemTekstil.Ui
{
    partial class Ui_Wizard
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelOperation = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panelOperationHead = new System.Windows.Forms.Panel();
            this.lblCustomerSurname = new System.Windows.Forms.Label();
            this.txtCustomerSurname = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.PanelInformation = new System.Windows.Forms.Panel();
            this.lblInformation = new System.Windows.Forms.Label();
            this.panelLeftMain = new System.Windows.Forms.Panel();
            this.panelLeftDown = new System.Windows.Forms.Panel();
            this.panelLeftTop = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSteps = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelOperation.SuspendLayout();
            this.panelOperationHead.SuspendLayout();
            this.PanelInformation.SuspendLayout();
            this.panelLeftMain.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelBody);
            this.panelMain.Controls.Add(this.panelStatus);
            this.panelMain.Controls.Add(this.panelTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(883, 528);
            this.panelMain.TabIndex = 0;
            // 
            // panelBody
            // 
            this.panelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBody.Controls.Add(this.panelOperation);
            this.panelBody.Controls.Add(this.PanelInformation);
            this.panelBody.Controls.Add(this.panelLeftMain);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 46);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(883, 424);
            this.panelBody.TabIndex = 5;
            // 
            // panelOperation
            // 
            this.panelOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOperation.Controls.Add(this.listBox1);
            this.panelOperation.Controls.Add(this.panelOperationHead);
            this.panelOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOperation.Location = new System.Drawing.Point(166, 79);
            this.panelOperation.Name = "panelOperation";
            this.panelOperation.Size = new System.Drawing.Size(715, 343);
            this.panelOperation.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(0, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(287, 301);
            this.listBox1.TabIndex = 0;
            // 
            // panelOperationHead
            // 
            this.panelOperationHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOperationHead.Controls.Add(this.lblCustomerSurname);
            this.panelOperationHead.Controls.Add(this.txtCustomerSurname);
            this.panelOperationHead.Controls.Add(this.lblCustomerName);
            this.panelOperationHead.Controls.Add(this.txtCustomerName);
            this.panelOperationHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOperationHead.Location = new System.Drawing.Point(0, 0);
            this.panelOperationHead.Name = "panelOperationHead";
            this.panelOperationHead.Size = new System.Drawing.Size(713, 40);
            this.panelOperationHead.TabIndex = 40;
            // 
            // lblCustomerSurname
            // 
            this.lblCustomerSurname.AutoSize = true;
            this.lblCustomerSurname.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCustomerSurname.Location = new System.Drawing.Point(297, 9);
            this.lblCustomerSurname.Name = "lblCustomerSurname";
            this.lblCustomerSurname.Size = new System.Drawing.Size(150, 22);
            this.lblCustomerSurname.TabIndex = 38;
            this.lblCustomerSurname.Text = "Müşteri Soyadi :";
            // 
            // txtCustomerSurname
            // 
            this.txtCustomerSurname.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCustomerSurname.Location = new System.Drawing.Point(460, 6);
            this.txtCustomerSurname.Name = "txtCustomerSurname";
            this.txtCustomerSurname.Size = new System.Drawing.Size(159, 28);
            this.txtCustomerSurname.TabIndex = 39;
            this.txtCustomerSurname.TextChanged += new System.EventHandler(this.txtCustomerSurname_TextChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCustomerName.Location = new System.Drawing.Point(7, 9);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(115, 22);
            this.lblCustomerName.TabIndex = 36;
            this.lblCustomerName.Text = "MüşteriAdi :";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCustomerName.Location = new System.Drawing.Point(132, 6);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(159, 28);
            this.txtCustomerName.TabIndex = 37;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // PanelInformation
            // 
            this.PanelInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelInformation.Controls.Add(this.lblInformation);
            this.PanelInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelInformation.Location = new System.Drawing.Point(166, 0);
            this.PanelInformation.Name = "PanelInformation";
            this.PanelInformation.Size = new System.Drawing.Size(715, 79);
            this.PanelInformation.TabIndex = 5;
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblInformation.Location = new System.Drawing.Point(2, 4);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(673, 44);
            this.lblInformation.TabIndex = 34;
            this.lblInformation.Text = "Rapor oluşturma sihirbazına hoşgeldiniz.Bu sihirbaz sizin veriminizi arrtırmak \r\n" +
    "için hazırlanmıştır.İlk alanınızı seçip ilerleyin.";
            // 
            // panelLeftMain
            // 
            this.panelLeftMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftMain.Controls.Add(this.panelLeftDown);
            this.panelLeftMain.Controls.Add(this.panelLeftTop);
            this.panelLeftMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftMain.Location = new System.Drawing.Point(0, 0);
            this.panelLeftMain.Name = "panelLeftMain";
            this.panelLeftMain.Size = new System.Drawing.Size(166, 422);
            this.panelLeftMain.TabIndex = 2;
            // 
            // panelLeftDown
            // 
            this.panelLeftDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftDown.Location = new System.Drawing.Point(0, 78);
            this.panelLeftDown.Name = "panelLeftDown";
            this.panelLeftDown.Size = new System.Drawing.Size(164, 346);
            this.panelLeftDown.TabIndex = 5;
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Size = new System.Drawing.Size(164, 78);
            this.panelLeftTop.TabIndex = 4;
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.progressBar1);
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Controls.Add(this.lblSteps);
            this.panelStatus.Controls.Add(this.btnBack);
            this.panelStatus.Controls.Add(this.btnNext);
            this.panelStatus.Controls.Add(this.btnCancel);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 470);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(883, 58);
            this.panelStatus.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.GreenYellow;
            this.progressBar1.Location = new System.Drawing.Point(69, 26);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(247, 24);
            this.progressBar1.TabIndex = 41;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatus.Location = new System.Drawing.Point(3, 28);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 20);
            this.lblStatus.TabIndex = 41;
            this.lblStatus.Text = "Durum :";
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSteps.Location = new System.Drawing.Point(3, 4);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(55, 20);
            this.lblSteps.TabIndex = 40;
            this.lblSteps.Text = "Steps :";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(58)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBack.Location = new System.Drawing.Point(505, 12);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(121, 35);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Geri";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(58)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNext.Location = new System.Drawing.Point(632, 12);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 35);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "İleri";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(58)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(759, 12);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 35);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitle.Controls.Add(this.logoPictureBox);
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(883, 46);
            this.panelTitle.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Location = new System.Drawing.Point(3, 4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(45, 35);
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(53, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(313, 30);
            this.lblTitle.TabIndex = 33;
            this.lblTitle.Text = "Rapor Oluşturma Sihirbazı";
            // 
            // Ui_Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelMain);
            this.Name = "Ui_Wizard";
            this.Size = new System.Drawing.Size(883, 528);
            this.Load += new System.EventHandler(this.Ui_Wizard_Load);
            this.panelMain.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelOperation.ResumeLayout(false);
            this.panelOperationHead.ResumeLayout(false);
            this.panelOperationHead.PerformLayout();
            this.PanelInformation.ResumeLayout(false);
            this.PanelInformation.PerformLayout();
            this.panelLeftMain.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.Panel panelLeftMain;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelOperation;
        private System.Windows.Forms.Panel PanelInformation;
        private System.Windows.Forms.Panel panelLeftDown;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtCustomerSurname;
        private System.Windows.Forms.Label lblCustomerSurname;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.Panel panelOperationHead;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
