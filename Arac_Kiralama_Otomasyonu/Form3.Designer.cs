namespace Arac_Kiralama_Otomasyonu
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btn_add = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_delet = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.dgwAraba = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPlaka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbYakıt = new System.Windows.Forms.ComboBox();
            this.cmbVites = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRenk = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMinYil = new System.Windows.Forms.TextBox();
            this.txtMaxYil = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaxUcret = new System.Windows.Forms.TextBox();
            this.txtMinUcret = new System.Windows.Forms.TextBox();
            this.cmbKasa = new System.Windows.Forms.ComboBox();
            this.txtSeri = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbKullanici = new System.Windows.Forms.PictureBox();
            this.lb_kullanici = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAraba)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKullanici)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.btn_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add.ImageIndex = 1;
            this.btn_add.ImageList = this.ımageList1;
            this.btn_add.Location = new System.Drawing.Point(448, 252);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(208, 79);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "EKLE";
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "arrow.png");
            this.ımageList1.Images.SetKeyName(1, "car (1).png");
            this.ımageList1.Images.SetKeyName(2, "car.png");
            this.ımageList1.Images.SetKeyName(3, "delete.png");
            this.ımageList1.Images.SetKeyName(4, "transport.png");
            this.ımageList1.Images.SetKeyName(5, "ChatGPT Image 3 May 2025 10_52_33.png");
            this.ımageList1.Images.SetKeyName(6, "broom.png");
            // 
            // btn_delet
            // 
            this.btn_delet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btn_delet.FlatAppearance.BorderSize = 0;
            this.btn_delet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delet.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.btn_delet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btn_delet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delet.ImageIndex = 4;
            this.btn_delet.ImageList = this.ımageList1;
            this.btn_delet.Location = new System.Drawing.Point(1044, 252);
            this.btn_delet.Name = "btn_delet";
            this.btn_delet.Size = new System.Drawing.Size(208, 79);
            this.btn_delet.TabIndex = 1;
            this.btn_delet.Text = "SİL";
            this.btn_delet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delet.UseVisualStyleBackColor = false;
            this.btn_delet.Click += new System.EventHandler(this.btn_delet_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_update.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_update.ImageIndex = 0;
            this.btn_update.ImageList = this.ımageList1;
            this.btn_update.Location = new System.Drawing.Point(746, 252);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(208, 79);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "GÜNCELLE";
            this.btn_update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // dgwAraba
            // 
            this.dgwAraba.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwAraba.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.dgwAraba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAraba.Location = new System.Drawing.Point(440, 356);
            this.dgwAraba.MultiSelect = false;
            this.dgwAraba.Name = "dgwAraba";
            this.dgwAraba.ReadOnly = true;
            this.dgwAraba.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwAraba.Size = new System.Drawing.Size(1388, 626);
            this.dgwAraba.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(53, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Marka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(53, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label3.Location = new System.Drawing.Point(53, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seri:";
            // 
            // txtMarka
            // 
            this.txtMarka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtMarka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMarka.Location = new System.Drawing.Point(165, 292);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(153, 20);
            this.txtMarka.TabIndex = 15;
            this.txtMarka.TextChanged += new System.EventHandler(this.txtMarka_TextChanged);
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtModel.Location = new System.Drawing.Point(165, 425);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(153, 20);
            this.txtModel.TabIndex = 16;
            this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
            // 
            // txtPlaka
            // 
            this.txtPlaka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtPlaka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPlaka.Location = new System.Drawing.Point(165, 252);
            this.txtPlaka.Name = "txtPlaka";
            this.txtPlaka.Size = new System.Drawing.Size(153, 20);
            this.txtPlaka.TabIndex = 19;
            this.txtPlaka.TextChanged += new System.EventHandler(this.txtPlaka_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label4.Location = new System.Drawing.Point(53, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Plaka:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label5.Location = new System.Drawing.Point(53, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Yakit:";
            // 
            // cmbYakıt
            // 
            this.cmbYakıt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.cmbYakıt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYakıt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.cmbYakıt.FormattingEnabled = true;
            this.cmbYakıt.Items.AddRange(new object[] {
            "SEÇ",
            "Benzin",
            "Dizel",
            "Benzin & LPG",
            "Elektrik"});
            this.cmbYakıt.Location = new System.Drawing.Point(165, 521);
            this.cmbYakıt.Name = "cmbYakıt";
            this.cmbYakıt.Size = new System.Drawing.Size(153, 21);
            this.cmbYakıt.TabIndex = 32;
            this.cmbYakıt.SelectedIndexChanged += new System.EventHandler(this.cmbYakıt_SelectedIndexChanged);
            // 
            // cmbVites
            // 
            this.cmbVites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.cmbVites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.cmbVites.FormattingEnabled = true;
            this.cmbVites.Items.AddRange(new object[] {
            "SEÇ",
            "Manuel",
            "Otomatik"});
            this.cmbVites.Location = new System.Drawing.Point(165, 568);
            this.cmbVites.Name = "cmbVites";
            this.cmbVites.Size = new System.Drawing.Size(153, 21);
            this.cmbVites.TabIndex = 34;
            this.cmbVites.SelectedIndexChanged += new System.EventHandler(this.cmbVites_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label6.Location = new System.Drawing.Point(53, 566);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 25);
            this.label6.TabIndex = 33;
            this.label6.Text = "Vites:";
            // 
            // cmbDurum
            // 
            this.cmbDurum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.cmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDurum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Items.AddRange(new object[] {
            "SEÇ",
            "MUSAIT",
            "DOLU"});
            this.cmbDurum.Location = new System.Drawing.Point(165, 606);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(153, 21);
            this.cmbDurum.TabIndex = 36;
            this.cmbDurum.SelectedIndexChanged += new System.EventHandler(this.cmbDurum_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label7.Location = new System.Drawing.Point(53, 604);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "Durum:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label8.Location = new System.Drawing.Point(53, 653);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 25);
            this.label8.TabIndex = 37;
            this.label8.Text = "Kira Ücreti:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label9.Location = new System.Drawing.Point(53, 776);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 25);
            this.label9.TabIndex = 38;
            this.label9.Text = "Yili:";
            // 
            // txtRenk
            // 
            this.txtRenk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtRenk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRenk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRenk.Location = new System.Drawing.Point(165, 473);
            this.txtRenk.Name = "txtRenk";
            this.txtRenk.Size = new System.Drawing.Size(153, 20);
            this.txtRenk.TabIndex = 40;
            this.txtRenk.TextChanged += new System.EventHandler(this.txtRenk_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label10.Location = new System.Drawing.Point(53, 473);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 25);
            this.label10.TabIndex = 39;
            this.label10.Text = "Rengi:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label11.Location = new System.Drawing.Point(53, 382);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 25);
            this.label11.TabIndex = 41;
            this.label11.Text = "Kasa:";
            // 
            // txtMinYil
            // 
            this.txtMinYil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtMinYil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinYil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMinYil.Location = new System.Drawing.Point(58, 862);
            this.txtMinYil.Name = "txtMinYil";
            this.txtMinYil.Size = new System.Drawing.Size(153, 20);
            this.txtMinYil.TabIndex = 43;
            this.txtMinYil.TextChanged += new System.EventHandler(this.txtMinYil_TextChanged);
            // 
            // txtMaxYil
            // 
            this.txtMaxYil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtMaxYil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxYil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMaxYil.Location = new System.Drawing.Point(241, 862);
            this.txtMaxYil.Name = "txtMaxYil";
            this.txtMaxYil.Size = new System.Drawing.Size(153, 20);
            this.txtMaxYil.TabIndex = 43;
            this.txtMaxYil.TextChanged += new System.EventHandler(this.txtMaxYil_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label12.Location = new System.Drawing.Point(53, 825);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 25);
            this.label12.TabIndex = 44;
            this.label12.Text = "Minimum";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label13.Location = new System.Drawing.Point(236, 825);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 25);
            this.label13.TabIndex = 45;
            this.label13.Text = "Maksimum";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label14.Location = new System.Drawing.Point(236, 706);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 25);
            this.label14.TabIndex = 49;
            this.label14.Text = "Maksimum";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label15.Location = new System.Drawing.Point(53, 706);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 25);
            this.label15.TabIndex = 48;
            this.label15.Text = "Minimum";
            // 
            // txtMaxUcret
            // 
            this.txtMaxUcret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtMaxUcret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxUcret.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMaxUcret.Location = new System.Drawing.Point(241, 743);
            this.txtMaxUcret.Name = "txtMaxUcret";
            this.txtMaxUcret.Size = new System.Drawing.Size(153, 20);
            this.txtMaxUcret.TabIndex = 46;
            this.txtMaxUcret.TextChanged += new System.EventHandler(this.txtMaxUcret_TextChanged);
            // 
            // txtMinUcret
            // 
            this.txtMinUcret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtMinUcret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinUcret.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMinUcret.Location = new System.Drawing.Point(58, 743);
            this.txtMinUcret.Name = "txtMinUcret";
            this.txtMinUcret.Size = new System.Drawing.Size(153, 20);
            this.txtMinUcret.TabIndex = 47;
            this.txtMinUcret.TextChanged += new System.EventHandler(this.txtMinUcret_TextChanged);
            // 
            // cmbKasa
            // 
            this.cmbKasa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.cmbKasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKasa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.cmbKasa.FormattingEnabled = true;
            this.cmbKasa.Items.AddRange(new object[] {
            "SEÇ"});
            this.cmbKasa.Location = new System.Drawing.Point(165, 382);
            this.cmbKasa.Name = "cmbKasa";
            this.cmbKasa.Size = new System.Drawing.Size(153, 21);
            this.cmbKasa.TabIndex = 57;
            this.cmbKasa.DropDown += new System.EventHandler(this.cmbKasa_DropDown);
            this.cmbKasa.SelectedIndexChanged += new System.EventHandler(this.cmbKasa_SelectedIndexChanged);
            // 
            // txtSeri
            // 
            this.txtSeri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.txtSeri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSeri.Location = new System.Drawing.Point(165, 337);
            this.txtSeri.Name = "txtSeri";
            this.txtSeri.Size = new System.Drawing.Size(153, 20);
            this.txtSeri.TabIndex = 58;
            this.txtSeri.TextChanged += new System.EventHandler(this.txtSeri_TextChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 6;
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(186, 903);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 79);
            this.button1.TabIndex = 60;
            this.button1.Text = "Temizle";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbKullanici);
            this.panel1.Controls.Add(this.lb_kullanici);
            this.panel1.Location = new System.Drawing.Point(58, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 87);
            this.panel1.TabIndex = 61;
            // 
            // pbKullanici
            // 
            this.pbKullanici.Image = ((System.Drawing.Image)(resources.GetObject("pbKullanici.Image")));
            this.pbKullanici.InitialImage = global::Arac_Kiralama_Otomasyonu.Properties.Resources._3__8_;
            this.pbKullanici.Location = new System.Drawing.Point(3, 3);
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
            this.lb_kullanici.ImageList = this.ımageList1;
            this.lb_kullanici.Location = new System.Drawing.Point(109, 35);
            this.lb_kullanici.Name = "lb_kullanici";
            this.lb_kullanici.Size = new System.Drawing.Size(0, 25);
            this.lb_kullanici.TabIndex = 5;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Bold);
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.label28.Location = new System.Drawing.Point(52, 210);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(120, 32);
            this.label28.TabIndex = 91;
            this.label28.Text = "Filtrele";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSeri);
            this.Controls.Add(this.cmbKasa);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMaxUcret);
            this.Controls.Add(this.txtMinUcret);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMaxYil);
            this.Controls.Add(this.txtMinYil);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRenk);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDurum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbVites);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbYakıt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlaka);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtMarka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwAraba);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_delet);
            this.Controls.Add(this.btn_add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Yönetimi";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Resize += new System.EventHandler(this.Form3_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAraba)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKullanici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delet;
        private System.Windows.Forms.Button btn_update;
        public System.Windows.Forms.DataGridView dgwAraba;
        private System.Windows.Forms.ImageList ımageList1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMarka;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPlaka;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbYakıt;
        private System.Windows.Forms.ComboBox cmbVites;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDurum;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRenk;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMinYil;
        private System.Windows.Forms.TextBox txtMaxYil;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMaxUcret;
        private System.Windows.Forms.TextBox txtMinUcret;
        private System.Windows.Forms.ComboBox cmbKasa;
        private System.Windows.Forms.TextBox txtSeri;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbKullanici;
        public System.Windows.Forms.Label lb_kullanici;
        private System.Windows.Forms.Label label28;
    }
}