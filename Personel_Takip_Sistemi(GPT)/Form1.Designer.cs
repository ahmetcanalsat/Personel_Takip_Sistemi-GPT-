namespace Personel_Takip_Sistemi_GPT_
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmb_persDepartman = new System.Windows.Forms.ComboBox();
            this.txt_persAd = new System.Windows.Forms.TextBox();
            this.txt_persSoyad = new System.Windows.Forms.TextBox();
            this.cmb_persCinsiyet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_persEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(542, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(867, 712);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmb_persDepartman
            // 
            this.cmb_persDepartman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_persDepartman.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_persDepartman.FormattingEnabled = true;
            this.cmb_persDepartman.Location = new System.Drawing.Point(232, 159);
            this.cmb_persDepartman.Name = "cmb_persDepartman";
            this.cmb_persDepartman.Size = new System.Drawing.Size(188, 37);
            this.cmb_persDepartman.TabIndex = 1;
            // 
            // txt_persAd
            // 
            this.txt_persAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_persAd.Location = new System.Drawing.Point(232, 38);
            this.txt_persAd.Name = "txt_persAd";
            this.txt_persAd.Size = new System.Drawing.Size(188, 34);
            this.txt_persAd.TabIndex = 2;
            // 
            // txt_persSoyad
            // 
            this.txt_persSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_persSoyad.Location = new System.Drawing.Point(232, 98);
            this.txt_persSoyad.Name = "txt_persSoyad";
            this.txt_persSoyad.Size = new System.Drawing.Size(188, 34);
            this.txt_persSoyad.TabIndex = 3;
            // 
            // cmb_persCinsiyet
            // 
            this.cmb_persCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_persCinsiyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_persCinsiyet.FormattingEnabled = true;
            this.cmb_persCinsiyet.Location = new System.Drawing.Point(232, 233);
            this.cmb_persCinsiyet.Name = "cmb_persCinsiyet";
            this.cmb_persCinsiyet.Size = new System.Drawing.Size(188, 37);
            this.cmb_persCinsiyet.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Soyad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Departman:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cinsiyet:";
            // 
            // btn_persEkle
            // 
            this.btn_persEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_persEkle.Location = new System.Drawing.Point(137, 321);
            this.btn_persEkle.Name = "btn_persEkle";
            this.btn_persEkle.Size = new System.Drawing.Size(165, 79);
            this.btn_persEkle.TabIndex = 9;
            this.btn_persEkle.Text = "EKLE";
            this.btn_persEkle.UseVisualStyleBackColor = true;
            this.btn_persEkle.Click += new System.EventHandler(this.btn_persEkle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 708);
            this.Controls.Add(this.btn_persEkle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_persCinsiyet);
            this.Controls.Add(this.txt_persSoyad);
            this.Controls.Add(this.txt_persAd);
            this.Controls.Add(this.cmb_persDepartman);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmb_persDepartman;
        private System.Windows.Forms.TextBox txt_persAd;
        private System.Windows.Forms.TextBox txt_persSoyad;
        private System.Windows.Forms.ComboBox cmb_persCinsiyet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_persEkle;
    }
}

