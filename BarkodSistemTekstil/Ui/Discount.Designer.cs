namespace BarkodSistemTekstil.Ui
{
    partial class Discount
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
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUygula = new System.Windows.Forms.Button();
            this.btniptal = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(77, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(181, 60);
            this.label13.TabIndex = 7;
            this.label13.Text = "İskonto Miktarı\r\nTL Cinsinden";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDiscount.Location = new System.Drawing.Point(24, 94);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(286, 36);
            this.txtDiscount.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btniptal);
            this.panel1.Controls.Add(this.btnUygula);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 187);
            this.panel1.TabIndex = 8;
            // 
            // btnUygula
            // 
            this.btnUygula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(58)))));
            this.btnUygula.FlatAppearance.BorderSize = 0;
            this.btnUygula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUygula.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUygula.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUygula.Location = new System.Drawing.Point(24, 134);
            this.btnUygula.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUygula.Name = "btnUygula";
            this.btnUygula.Size = new System.Drawing.Size(141, 34);
            this.btnUygula.TabIndex = 9;
            this.btnUygula.Text = "Uygula";
            this.btnUygula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUygula.UseVisualStyleBackColor = false;
            this.btnUygula.Click += new System.EventHandler(this.button8_Click);
            // 
            // btniptal
            // 
            this.btniptal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(58)))));
            this.btniptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btniptal.FlatAppearance.BorderSize = 0;
            this.btniptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btniptal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btniptal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btniptal.Location = new System.Drawing.Point(169, 134);
            this.btniptal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btniptal.Name = "btniptal";
            this.btniptal.Size = new System.Drawing.Size(141, 34);
            this.btniptal.TabIndex = 10;
            this.btniptal.Text = "İptal";
            this.btniptal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btniptal.UseVisualStyleBackColor = false;
            this.btniptal.Click += new System.EventHandler(this.button1_Click);
            // 
            // Discount
            // 
            this.AcceptButton = this.btnUygula;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btniptal;
            this.ClientSize = new System.Drawing.Size(334, 191);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUygula;
        private System.Windows.Forms.Button btniptal;
    }
}
