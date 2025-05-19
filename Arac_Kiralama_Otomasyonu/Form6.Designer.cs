namespace Arac_Kiralama_Otomasyonu
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.dgw_sozlesme = new System.Windows.Forms.DataGridView();
            this.txt_Mara = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_plakaAra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbKullanici = new System.Windows.Forms.PictureBox();
            this.lb_kullanici = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_sozlesme)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKullanici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw_sozlesme
            // 
            this.dgw_sozlesme.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_sozlesme.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.dgw_sozlesme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_sozlesme.Location = new System.Drawing.Point(12, 158);
            this.dgw_sozlesme.MultiSelect = false;
            this.dgw_sozlesme.Name = "dgw_sozlesme";
            this.dgw_sozlesme.ReadOnly = true;
            this.dgw_sozlesme.RowHeadersVisible = false;
            this.dgw_sozlesme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_sozlesme.Size = new System.Drawing.Size(776, 367);
            this.dgw_sozlesme.TabIndex = 35;
            // 
            // txt_Mara
            // 
            this.txt_Mara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txt_Mara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Mara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Mara.Location = new System.Drawing.Point(115, 128);
            this.txt_Mara.MaxLength = 11;
            this.txt_Mara.Name = "txt_Mara";
            this.txt_Mara.Size = new System.Drawing.Size(124, 20);
            this.txt_Mara.TabIndex = 70;
            this.txt_Mara.TextChanged += new System.EventHandler(this.txt_Mara_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label3.Location = new System.Drawing.Point(24, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "TC No:";
            // 
            // txt_plakaAra
            // 
            this.txt_plakaAra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txt_plakaAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_plakaAra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_plakaAra.Location = new System.Drawing.Point(398, 128);
            this.txt_plakaAra.MaxLength = 10;
            this.txt_plakaAra.Name = "txt_plakaAra";
            this.txt_plakaAra.Size = new System.Drawing.Size(124, 20);
            this.txt_plakaAra.TabIndex = 72;
            this.txt_plakaAra.TextChanged += new System.EventHandler(this.txt_plakaAra_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label4.Location = new System.Drawing.Point(286, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 71;
            this.label4.Text = "Araba Plaka:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbKullanici);
            this.panel1.Controls.Add(this.lb_kullanici);
            this.panel1.Location = new System.Drawing.Point(25, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 87);
            this.panel1.TabIndex = 90;
            // 
            // pbKullanici
            // 
            this.pbKullanici.Image = ((System.Drawing.Image)(resources.GetObject("pbKullanici.Image")));
            this.pbKullanici.InitialImage = global::Arac_Kiralama_Otomasyonu.Properties.Resources._3__8_;
            this.pbKullanici.Location = new System.Drawing.Point(3, 0);
            this.pbKullanici.Name = "pbKullanici";
            this.pbKullanici.Size = new System.Drawing.Size(100, 84);
            this.pbKullanici.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbKullanici.TabIndex = 7;
            this.pbKullanici.TabStop = false;
            // 
            // lb_kullanici
            // 
            this.lb_kullanici.AutoSize = true;
            this.lb_kullanici.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lb_kullanici.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.lb_kullanici.Location = new System.Drawing.Point(109, 35);
            this.lb_kullanici.Name = "lb_kullanici";
            this.lb_kullanici.Size = new System.Drawing.Size(0, 25);
            this.lb_kullanici.TabIndex = 5;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_plakaAra);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Mara);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgw_sozlesme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sözleşme";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.Resize += new System.EventHandler(this.Form6_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_sozlesme)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKullanici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgw_sozlesme;
        private System.Windows.Forms.TextBox txt_Mara;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_plakaAra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbKullanici;
        public System.Windows.Forms.Label lb_kullanici;
    }
}