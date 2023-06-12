namespace WindowsFormsApp1
{
    partial class FrmFiyatguncelle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.barkodAra = new System.Windows.Forms.TextBox();
            this.urunAra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.barkod = new System.Windows.Forms.TextBox();
            this.urunAdı = new System.Windows.Forms.TextBox();
            this.fıyat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.yenıFıyat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.guncelle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.yenıPuan = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod Okutunuz";
            // 
            // barkodAra
            // 
            this.barkodAra.Location = new System.Drawing.Point(12, 38);
            this.barkodAra.Name = "barkodAra";
            this.barkodAra.Size = new System.Drawing.Size(178, 20);
            this.barkodAra.TabIndex = 1;
            this.barkodAra.TextChanged += new System.EventHandler(this.barkodAra_TextChanged);
            // 
            // urunAra
            // 
            this.urunAra.Location = new System.Drawing.Point(12, 95);
            this.urunAra.Name = "urunAra";
            this.urunAra.Size = new System.Drawing.Size(178, 20);
            this.urunAra.TabIndex = 2;
            this.urunAra.TextChanged += new System.EventHandler(this.urunAra_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ürün Adı Giriniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seçili Ürün Bilgileri";
            // 
            // barkod
            // 
            this.barkod.Enabled = false;
            this.barkod.Location = new System.Drawing.Point(88, 176);
            this.barkod.Name = "barkod";
            this.barkod.Size = new System.Drawing.Size(108, 20);
            this.barkod.TabIndex = 5;
            // 
            // urunAdı
            // 
            this.urunAdı.Enabled = false;
            this.urunAdı.Location = new System.Drawing.Point(88, 217);
            this.urunAdı.Name = "urunAdı";
            this.urunAdı.Size = new System.Drawing.Size(108, 20);
            this.urunAdı.TabIndex = 6;
            // 
            // fıyat
            // 
            this.fıyat.Enabled = false;
            this.fıyat.Location = new System.Drawing.Point(88, 259);
            this.fıyat.Name = "fıyat";
            this.fıyat.Size = new System.Drawing.Size(108, 20);
            this.fıyat.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Barkod";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fiyatı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ürün Adı";
            // 
            // yenıFıyat
            // 
            this.yenıFıyat.Location = new System.Drawing.Point(88, 336);
            this.yenıFıyat.Name = "yenıFıyat";
            this.yenıFıyat.Size = new System.Drawing.Size(112, 20);
            this.yenıFıyat.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Yeni Fiyat";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 495);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "<=";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(251, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(537, 506);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // guncelle
            // 
            this.guncelle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.guncelle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guncelle.Location = new System.Drawing.Point(44, 409);
            this.guncelle.Name = "guncelle";
            this.guncelle.Size = new System.Drawing.Size(156, 34);
            this.guncelle.TabIndex = 16;
            this.guncelle.Text = "Güncelle";
            this.guncelle.UseVisualStyleBackColor = false;
            this.guncelle.Click += new System.EventHandler(this.guncelle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Yeni Puan";
            // 
            // yenıPuan
            // 
            this.yenıPuan.Location = new System.Drawing.Point(88, 373);
            this.yenıPuan.Name = "yenıPuan";
            this.yenıPuan.Size = new System.Drawing.Size(112, 20);
            this.yenıPuan.TabIndex = 17;
            // 
            // FrmFiyatguncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.yenıPuan);
            this.Controls.Add(this.guncelle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.yenıFıyat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fıyat);
            this.Controls.Add(this.urunAdı);
            this.Controls.Add(this.barkod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urunAra);
            this.Controls.Add(this.barkodAra);
            this.Controls.Add(this.label1);
            this.Name = "FrmFiyatguncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox barkodAra;
        private System.Windows.Forms.TextBox urunAra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox barkod;
        private System.Windows.Forms.TextBox urunAdı;
        private System.Windows.Forms.TextBox fıyat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox yenıFıyat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button guncelle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox yenıPuan;
    }
}