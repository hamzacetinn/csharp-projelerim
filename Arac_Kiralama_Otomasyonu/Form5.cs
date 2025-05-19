using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form5 : Form
    {
        private FormResizer resizer = new FormResizer();
        public Form5()
        {
            InitializeComponent();
        }
        public Form1 frm1 = new Form1();
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        public SqlDataAdapter da = new SqlDataAdapter();
        public SqlCommand komut = new SqlCommand();
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public DataView dv = new DataView();
        public BindingManagerBase bm;

        private bool tamEkranModu = false; // Tam ekran durumunu takip eden değişken
        public void VeriYenile2()
        {
            ds.Clear();
            SqlConnection conn = new SqlConnection(Baglan.baglanti);
            try
            {
                da = new SqlDataAdapter("select * from musteri_yonetimi order by m_id", conn);
                if (conn.State == ConnectionState.Closed) conn.Open();
                da.Fill(ds, "musteri_yonetimi");
                dgw_musteri.DataSource = ds;

                dgw_musteri.DataMember = "musteri_yonetimi";
                bm = this.BindingContext[ds, "musteri_yonetimi"];
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        private void SozlesmeListele()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM sozlesme", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgw_sozlesme.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }

        private void AracListele()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT id,marka,seri,model,yili,yakit,rengi,kasa,plaka,durumu,vites,kira_ucreti FROM araba_yonetimi WHERE durumu='MUSAIT'", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgw_arac.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }

        private void LoadData()
        {
            try
            {
                string connectionString = Baglan.baglanti; // Veritabanı bağlantı dizesi
                string query = "SELECT * FROM musteri_yonetimi"; // Tabloyu seç

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgw_musteri.DataSource = dataTable; // DataGridView'i doldur
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());

            }
        }
        private void FiltreUygula()
        {
            try
            {
                arabaFiltre filtre = new arabaFiltre();
                string marka = txtMarka.Text.Trim();
                string seri = txtSeri.Text;
                string model = txtModel.Text.Trim();
                string kasa = cmbKasa.Text.Trim();
                string yakit = cmbYakıt.Text.Trim();
                string vites = cmbVites.Text.Trim();
                string rengi = txtRenk.Text.Trim();
                string durumu = cmbDurum.Text.Trim();
                string plaka1 = txtPlaka.Text.Trim();
                int sec = 1;
                int min, max;
                int? minYil = int.TryParse(txtMinYil.Text, out min) ? min : (int?)null;
                int? maxYil = int.TryParse(txtMaxYil.Text, out max) ? max : (int?)null;
                int minU, maxU;
                int? minUcret = int.TryParse(txtMinUcret.Text, out minU) ? minU : (int?)null;
                int? maxUcret = int.TryParse(txtMaxUcret.Text, out maxU) ? maxU : (int?)null;


                DataTable dt = filtre.DinamikFiltrele(marka, seri, model, kasa, vites, yakit, rengi, sec, durumu, plaka1, minYil, maxYil, minUcret, maxUcret);
                dgw_arac.DataSource = dt;

                string tc = txt_tc_ara.Text.Trim();
                string plaka = txt_plakaAra.Text.Trim();
                DataTable dt1 = filtre.DinamikFiltreleSozlesme(tc, plaka);
                dgw_sozlesme.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        public void secim1(System.Windows.Forms.ComboBox secim)
        {
            try
            {
                txtKart.Visible = txtNakit.Visible = false;
                label15.Visible = label16.Visible = false;
                btnOde.Visible = false;
                //Anlık olarak nesne oluşturma

                switch (secim.SelectedIndex)
                {

                    case 1:
                        txtNakit.Visible = true;
                        label15.Visible = true;
                        btnOde.Visible = true;
                        btnOde.Location = new Point(212, 869);

                        /* txtKart.Visible = false;
                         label16.Visible = false;*/
                        break;
                    case 2:
                        /*txtNakit.Visible = false;
                        label15.Visible = false;*/
                        txtKart.Visible = true;
                        label16.Visible = true;
                        btnOde.Visible = true;
                        txtKart.Location = new Point(161, 840);
                        label16.Location = new Point(12, 842);
                        btnOde.Location = new Point(212, 869);

                        break;
                    case 3:
                        txtNakit.Visible = true;
                        label15.Visible = true;
                        txtKart.Visible = true;
                        label16.Visible = true;
                        btnOde.Visible = true;
                        txtKart.Location = new Point(161, 869);
                        label16.Location = new Point(12, 869);
                        btnOde.Location = new Point(212, 898);

                        break;
                    default:
                        txtKart.Visible = false;
                        txtNakit.Visible = false;
                        label16.Visible = false;
                        label15.Visible = false;
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());

            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                dgw_musteri.AllowUserToResizeColumns = false;
                dgw_musteri.AllowUserToResizeRows = false;
                dgw_arac.AllowUserToResizeColumns = false;
                dgw_arac.AllowUserToResizeRows = false;
                dgw_sozlesme.AllowUserToResizeColumns = false;
                dgw_sozlesme.AllowUserToResizeRows = false;
                this.KeyPreview = true; // Klavye olaylarını önce formun yakalamasını sağlar
                resizer.CaptureInitialSizes(this);
                lb_kullanici.Text = AktifKullanici.KullaniciAdi;
                dgw_musteri.ClearSelection();
                txt_Mara.Clear();
                dgw_arac.RowTemplate.Height = 18;
                cmb_odemeyontemi.SelectedIndex = 0;
                cmbDurum.SelectedIndex = 0;
                cmbVites.SelectedIndex = 0;
                cmbYakıt.SelectedIndex = 0;
                txtBorc.Visible = false;
                label17.Visible = false;
               

                

                cmb_odemeyontemi.Margin = new Padding(0);
                this.MinimumSize = new Size(1600, 800);//ilk baştaki boyut

                // Müşteri verilerini yükle
                da = new SqlDataAdapter("SELECT * FROM musteri_yonetimi ORDER BY m_id", baglanti);
                ds.Clear();
                da.Fill(ds, "musteri_yonetimi");
                dgw_musteri.DataSource = ds.Tables["musteri_yonetimi"];
                baglanti.Close();

                // Araç verilerini yükle
                da = new SqlDataAdapter("SELECT id,marka,seri,model,yili,yakit,rengi,kasa,plaka,durumu,vites,kira_ucreti FROM araba_yonetimi WHERE durumu='MUSAIT'", baglanti);
                da.Fill(ds, "araba_yonetimi");
                dgw_arac.DataSource = ds.Tables["araba_yonetimi"];
                //dgw_arac.AllowUserToAddRows = false;
                baglanti.Close();
                // Sözleşme verilerini yükle
                da = new SqlDataAdapter("SELECT *FROM sozlesme order by s_id", baglanti);

                da.Fill(ds, "sozlesme");
                dgw_sozlesme.DataSource = ds.Tables["sozlesme"];
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        private void Form5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11) // F11 tuşuna basıldığında
            {
                if (tamEkranModu)
                {
                    // Tam ekrandan çık
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    // Tam ekrana geç
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                tamEkranModu = !tamEkranModu;// Durumu tersine çevir*/
            }
        }
        private void Form5_Resize(object sender, EventArgs e)
        {
            resizer.ResizeControls(this);
        }

        private void cmb_odemeyontemi_SelectedIndexChanged(object sender, EventArgs e)
        {
            secim1(cmb_odemeyontemi);
        }
        private void cmbYakıt_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtMarka_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtKasa_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txt_tc_ara_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txt_plakaAra_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbKasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbYakıt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txt_Mara.Text;
                string connectionString = Baglan.baglanti;
                string query = "SELECT * FROM musteri_yonetimi WHERE tc_no LIKE @searchValue"; // SQL sorgusu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Parametreyi ekle
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgw_musteri.DataSource = dataTable; // DataGridView'i filtrelenmiş verilerle güncelle
                }
                if (string.IsNullOrEmpty(searchValue))
                {
                    LoadData(); // Eğer TextBox boşsa tüm veriyi tekrar yükle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dgw_araç_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_kira.Clear();

                if (e.RowIndex >= 0)
                {
                    txt_kira.Text = dgw_arac.Rows[e.RowIndex].Cells[11].Value.ToString();
                    TimeSpan gun = DateTime.Parse(dtp_bitis.Text) - DateTime.Parse(dtp_baslangic.Text);
                    int gun2 = gun.Days + 1;
                    txtGun.Text = gun2.ToString() + " " + "Gün";
                    //cmb_durumu.Text = dgw_arac.Rows[e.RowIndex].Cells[8].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        private void dgw_musteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan gun = DateTime.Parse(dtp_bitis.Text) - DateTime.Parse(dtp_baslangic.Text);
                int gun2 = gun.Days + 1;
                var kirabedeli = gun2 * Convert.ToInt32(txt_kira.Text);
                txtTutar.Text = kirabedeli.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hata: Lütfen Araba Kiralama Tarihini Ayarlayınız! ");
            }
        }
        private void dtp_bitis_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan gun = DateTime.Parse(dtp_bitis.Text) - DateTime.Parse(dtp_baslangic.Text);
                int gun2 = gun.Days + 1;
                txtGun.Text = gun2.ToString() + " " + "Gün";

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hata: Lütfen Araba Kiralama Tarihini Ayarlayınız! ");
            }
        }
        private void btn_m_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds.Tables.Contains("musteri_yonetimi"))
                {
                    dgw_musteri.DataSource = ds;
                    dgw_musteri.DataMember = "musteri_yonetimi";
                }
                else
                {
                    MessageBox.Show("Tablo 'musteri_yonetimi' DataSet içinde bulunamadı.");
                }
                dgw_musteri.DataSource = ds.Tables["musteri_yonetimi"];
                Form5_E frm5e = new Form5_E();
                frm5e.Owner = this; // Form5_E'nin sahibi olarak Form5'i ayarlıyoruz
                frm5e.TopMost = true;
                frm5e.Show();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hata: Lütfen Araba Kiralama Tarihini Ayarlayınız! ");
            }
        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (dgw_musteri.SelectedRows.Count > 0)
                {
                    String tc = dgw_musteri.SelectedRows[0].Cells[1].Value.ToString();
                    String ad = dgw_musteri.SelectedRows[0].Cells[2].Value.ToString();
                    String soyad = dgw_musteri.SelectedRows[0].Cells[3].Value.ToString();
                    String tel = dgw_musteri.SelectedRows[0].Cells[4].Value.ToString();
                    //string plaka = dgw_arac.SelectedRows[0].Cells[1].Value.ToString();
                    if (dgw_arac.SelectedRows.Count > 0)
                    {
                        String marka = dgw_arac.SelectedRows[0].Cells[1].Value.ToString();
                        String seri = dgw_arac.SelectedRows[0].Cells[2].Value.ToString();
                        String model = dgw_arac.SelectedRows[0].Cells[3].Value.ToString();
                        String yili = dgw_arac.SelectedRows[0].Cells[4].Value.ToString();
                        String yakit = dgw_arac.SelectedRows[0].Cells[5].Value.ToString();
                        String rengi = dgw_arac.SelectedRows[0].Cells[6].Value.ToString();
                        String kasa = dgw_arac.SelectedRows[0].Cells[7].Value.ToString();
                        String plaka = dgw_arac.SelectedRows[0].Cells[8].Value.ToString();
                        String vites = dgw_arac.SelectedRows[0].Cells[10].Value.ToString();
                        String ucret = dgw_arac.SelectedRows[0].Cells[11].Value.ToString();
                        string baslangic = dtp_baslangic.Text;
                        string bitis = dtp_bitis.Text;
                        string gun = txtGun.Text;
                        string borc = txtBorc.Text;
                        string odeme = cmb_odemeyontemi.Text;
                        if (odeme == "SEC")
                        {
                            MessageBox.Show("Lütfen Ödeme Yöntemi Seçiniz!");
                        }
                        string sql = "INSERT INTO sozlesme (tc_no, isim, soy_isim, telefon, plaka, marka, seri, model, kasa, yili, vites, yakit, rengi, kira_ucreti ,baslangic, bitis, gun, odeme_yontemi, borcu,k_adi) " +
                        "VALUES (@tc_no,@isim,@soy_isim,@tel_no,@plaka,@marka,@seri,@model,@kasa,@yili,@vites,@yakit,@rengi,@kira_ucreti,@baslangic_tarihi,@bitis_tarihi,@gun_sayisi,@odeme_yontemi,@borcu,@k_adi)";
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        SqlCommand komut = new SqlCommand(sql, baglanti);
                        komut.Parameters.AddWithValue("@tc_no", tc);
                        komut.Parameters.AddWithValue("@isim", ad);
                        komut.Parameters.AddWithValue("@soy_isim", soyad);
                        komut.Parameters.AddWithValue("@tel_no", tel);
                        komut.Parameters.AddWithValue("@plaka", plaka);
                        komut.Parameters.AddWithValue("@marka", marka);
                        komut.Parameters.AddWithValue("@seri", seri);
                        komut.Parameters.AddWithValue("@model", model);
                        komut.Parameters.AddWithValue("@kasa", kasa);
                        komut.Parameters.AddWithValue("@yili", yili);
                        komut.Parameters.AddWithValue("@vites", vites);
                        komut.Parameters.AddWithValue("@yakit", yakit);
                        komut.Parameters.AddWithValue("@rengi", rengi);
                        komut.Parameters.AddWithValue("@kira_ucreti", ucret);
                        komut.Parameters.AddWithValue("@baslangic_tarihi", dtp_baslangic.Value);
                        komut.Parameters.AddWithValue("@bitis_tarihi", dtp_bitis.Value);
                        int gunSayisi = int.Parse(gun.Split(' ')[0]);
                        komut.Parameters.AddWithValue("@gun_sayisi", gunSayisi);
                        komut.Parameters.AddWithValue("@odeme_yontemi", odeme);
                        komut.Parameters.AddWithValue("@borcu", borc);
                        komut.Parameters.AddWithValue("@k_adi", AktifKullanici.KullaniciAdi); // Satıcı bilgisi
                        komut.ExecuteNonQuery();
                        ds.Clear();
                        SqlCommand updateKomut = new SqlCommand("UPDATE araba_yonetimi SET durumu='DOLU' WHERE plaka=@plaka ", baglanti);
                        updateKomut.Parameters.AddWithValue("@plaka", plaka);
                        updateKomut.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Araç Seçiniz!");
                    }
                    // 2. DataSet'i temizle
                    ds.Clear();
                    // 3. Güncel verileri almak için SELECT işlemi
                    string sqlSelect = "SELECT * FROM araba_yonetimi where durumu='MUSAIT'";
                    /* if (ds.Tables["araba_yonetimi"].Rows.Count == 0)
                     {
                         MessageBox.Show("Müsait araç yok, tablo boş!");
                     }*/
                    ds.Tables["araba_yonetimi"].Clear();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili FROM araba_yonetimi WHERE durumu='MUSAIT'", baglanti);
                    da.Fill(ds, "araba_yonetimi");
                    dgw_arac.DataSource = ds.Tables["araba_yonetimi"];
                    if (ds.Tables["araba_yonetimi"].Rows.Count == 0)
                    {
                        MessageBox.Show("Müsait araç yok, tablo boş!");
                    }
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen Müşteri ve Araba seçiniz!");
                }
                SqlDataAdapter da1 = new SqlDataAdapter("select * from sozlesme", baglanti);
                da1.Fill(ds, "sozlesme");
                dgw_sozlesme.DataSource = ds.Tables["sozlesme"];
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hata: Lütfen Araba Kiralama Tarihini Ayarlayınız! ");
            }
        }
        private void btnOde_Click(object sender, EventArgs e)
        {
            try
            {//burayı fixle
                txtBorc.Visible = true;
                label17.Visible = true;
                var secim = cmb_odemeyontemi;
                int borcDurumu;
                switch (secim.SelectedIndex)
                {
                    case 1:
                        txtKart.Text = "0";
                        borcDurumu = (Convert.ToInt32(txtKart.Text) + Convert.ToInt32(txtNakit.Text)) - Convert.ToInt32(txtTutar.Text); // direkt veri tabanına ekle
                        txtBorc.Text = borcDurumu.ToString(); // borç durumunu öğrenmek için bir tuşa basılacak ve o zaman borç durumu text boxda gözükecek
                        break;
                    case 2:
                        txtNakit.Text = "0";
                        borcDurumu = (Convert.ToInt32(txtKart.Text) + Convert.ToInt32(txtNakit.Text)) - Convert.ToInt32(txtTutar.Text); // direkt veri tabanına ekle
                        txtBorc.Text = borcDurumu.ToString(); // borç durumunu öğrenmek için bir tuşa basılacak ve o zaman borç durumu text boxda gözükecek
                        break;
                    case 3:
                        borcDurumu = (Convert.ToInt32(txtKart.Text) + Convert.ToInt32(txtNakit.Text)) - Convert.ToInt32(txtTutar.Text); // direkt veri tabanına ekle
                        txtBorc.Text = borcDurumu.ToString(); // borç durumunu öğrenmek için bir tuşa basılacak ve o zaman borç durumu text boxda gözükecek
                        break;
                    default:
                        {
                            break;
                        }
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hata:" + ex.Message);
            }
        }
        private void btn_temizle_Click(object sender, EventArgs e)
        {
            try
            {
                txtGun.Clear();
                txtBorc.Clear();
                txtKart.Clear();
                txtNakit.Clear();
                txt_kira.Clear();
                txtMarka.Clear();
                txtModel.Clear();

                txtTutar.Clear();
                txt_Mara.Clear();
                cmbYakıt.SelectedIndex = 0;
                cmbKasa.Items.Clear(); // Listeyi temizle
                cmbVites.SelectedIndex = 0;
                txtRenk.Clear();
                txtPlaka.Clear();
                txtSeri.Clear();
                txtMinYil.Clear();
                txtMaxYil.Clear();
                txtMinUcret.Clear();
                txtMaxUcret.Clear();
                cmb_odemeyontemi.SelectedIndex = 0;
                dtp_baslangic.Value = DateTime.Now;
                dtp_bitis.Value = DateTime.Now;
                AracListele();
                dgw_arac.ClearSelection();
                VeriYenile2();
                dgw_musteri.ClearSelection();
                SozlesmeListele();
                dgw_sozlesme.ClearSelection();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }

        }
        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgw_musteri.CurrentRow == null || dgw_arac.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen Güncellenecek Müşteri ve Araç Seçiniz!");
                    return;
                }
                if (dgw_sozlesme.SelectedRows.Count > 0)
                {
                    if (dgw_arac.SelectedRows.Count > 0)
                    {
                        String tc = dgw_musteri.SelectedRows[0].Cells[1].Value.ToString();
                        String ad = dgw_musteri.SelectedRows[0].Cells[2].Value.ToString();
                        String soyad = dgw_musteri.SelectedRows[0].Cells[3].Value.ToString();
                        String tel = dgw_musteri.SelectedRows[0].Cells[4].Value.ToString();
                        int s_id = Convert.ToInt32(dgw_sozlesme.CurrentRow.Cells["s_id"].Value);
                        String marka = dgw_arac.SelectedRows[0].Cells[1].Value.ToString();
                        string seri = dgw_arac.SelectedRows[0].Cells[2].Value.ToString();
                        String model = dgw_arac.SelectedRows[0].Cells[3].Value.ToString();
                        String yili = dgw_arac.SelectedRows[0].Cells[4].Value.ToString();
                        String yakit = dgw_arac.SelectedRows[0].Cells[5].Value.ToString();
                        String rengi = dgw_arac.SelectedRows[0].Cells[6].Value.ToString();
                        String kasa = dgw_arac.SelectedRows[0].Cells[7].Value.ToString();
                        string eskiPlaka = dgw_sozlesme.CurrentRow.Cells["plaka"].Value.ToString();
                        string yeniPlaka = dgw_arac.CurrentRow.Cells["plaka"].Value.ToString();
                        String vites = dgw_arac.SelectedRows[0].Cells[10].Value.ToString();
                        String ucret = dgw_arac.SelectedRows[0].Cells[11].Value.ToString();
                        DateTime baslangic = dtp_baslangic.Value;
                        DateTime bitis = dtp_bitis.Value;
                        string gun = txtGun.Text;
                        string borc = txtBorc.Text;
                        string odeme = cmb_odemeyontemi.Text;
                        string guncelle = @"UPDATE sozlesme SET 
                plaka=@plaka, marka=@marka, seri=@seri, model=@model, kasa=@kasa, 
                yili=@yili, vites=@vites, yakit=@yakit, rengi=@rengi, 
                kira_ucreti=@kira_ucreti, borcu=@borcu, baslangic=@baslangic, 
                bitis=@bitis, gun=@gun, odeme_yontemi=@odeme_yontemi 
                WHERE s_id=@s_id ";
                        komut = new SqlCommand(guncelle, baglanti);
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        // Yeni araç DOLU, eski araç MUSAIT yapılır

                        if (yeniPlaka != eskiPlaka)
                        {
                            // Yeni araç DOLU, eski araç MUSAIT yapılır
                            SqlCommand komutDolu = new SqlCommand("UPDATE araba_yonetimi SET durumu='DOLU' WHERE plaka=@plaka", baglanti);
                            komutDolu.Parameters.AddWithValue("@plaka", yeniPlaka);
                            komutDolu.ExecuteNonQuery();

                            SqlCommand komutMusait = new SqlCommand("UPDATE araba_yonetimi SET durumu='MUSAIT' WHERE plaka=@plaka", baglanti);
                            komutMusait.Parameters.AddWithValue("@plaka", eskiPlaka);
                            komutMusait.ExecuteNonQuery();
                        }
                        komut.Parameters.AddWithValue("@s_id", s_id);

                        komut.Parameters.AddWithValue("@plaka", yeniPlaka);
                        komut.Parameters.AddWithValue("@marka", marka);
                        komut.Parameters.AddWithValue("@seri", seri);
                        komut.Parameters.AddWithValue("@model", model);
                        komut.Parameters.AddWithValue("@kasa", kasa);
                        komut.Parameters.AddWithValue("@yili", yili);
                        komut.Parameters.AddWithValue("@yakit", yakit);
                        komut.Parameters.AddWithValue("@vites", vites);
                        komut.Parameters.AddWithValue("@rengi", rengi);
                        komut.Parameters.AddWithValue("@kira_ucreti", ucret);
                        komut.Parameters.AddWithValue("@borcu", borc);
                        komut.Parameters.AddWithValue("@baslangic", baslangic);
                        komut.Parameters.AddWithValue("@bitis", bitis);
                        komut.Parameters.AddWithValue("@gun", gun);
                        komut.Parameters.AddWithValue("@odeme_yontemi", odeme);

                        komut.ExecuteNonQuery();

                        baglanti.Close();

                    }
                    else
                    {
                        MessageBox.Show("Lütfen Güncellenecek Sözleşmeyi Seçiniz!");
                        return;
                    }
                }
                AracListele();
                VeriYenile2();
                SozlesmeListele();

                txtBorc.Clear();
                txt_Mara.Clear();
                txtGun.Clear();
                txtTutar.Clear();
                txtNakit.Clear();
                txtKart.Clear();
                cmb_odemeyontemi.SelectedIndex = -1;
                dtp_baslangic.Value = DateTime.Today;
                dtp_bitis.Value = DateTime.Today;
                // ✅ Bilgilendirme
                MessageBox.Show("Sözleşme başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgw_arac.CurrentRow != null)
                {

                    int secilenID = Convert.ToInt32(dgw_arac.CurrentRow.Cells["id"].Value); // "id" sütununun adını kontrol et
                    using (SqlConnection baglanti = new SqlConnection(Baglan.baglanti))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT fotografi FROM araba_yonetimi WHERE id = @id", baglanti);
                        cmd.Parameters.AddWithValue("@id", secilenID);
                        baglanti.Open();
                        object sonuc = cmd.ExecuteScalar();
                        if (sonuc != null && sonuc != DBNull.Value)
                        {
                            byte[] resimBytes = (byte[])sonuc;
                            gorsel frmGorsel = new gorsel(resimBytes);
                            frmGorsel.Owner = this;
                            frmGorsel.TopMost = true;
                            frmGorsel.frm5 = this;
                            frmGorsel.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Seçilen araç için kayıtlı bir görsel bulunamadı.");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.ToString());
            }
        }
        private void btnSozlesmeIptal_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure eskiPlaka is declared and initialized properly  
                string eskiPlaka = dgw_sozlesme.CurrentRow?.Cells["plaka"]?.Value?.ToString();

                // Check if eskiPlaka is null or empty  
                if (string.IsNullOrEmpty(eskiPlaka))
                {
                    MessageBox.Show("Lütfen İptal Edilecek Sözleşmeyi Seçiniz!");
                    return;
                }
                else
                {
                    if (dgw_sozlesme.SelectedCells.Count > 0)
                    {
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                        if (eskiPlaka != null)
                        {
                            SqlCommand komutMusait = new SqlCommand("UPDATE araba_yonetimi SET durumu='MUSAIT' WHERE plaka=@plaka", baglanti);
                            komutMusait.Parameters.AddWithValue("@plaka", eskiPlaka);
                            komutMusait.ExecuteNonQuery();
                        }
                        int id = Convert.ToInt32(dgw_sozlesme.CurrentRow.Cells[0].Value);
                        if (id != null)
                        {
                            baglanti = new SqlConnection(Baglan.baglanti);
                            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                            da = new SqlDataAdapter("DELETE FROM sozlesme where s_id=" + id, baglanti);
                            da.Fill(ds);
                            da.Fill(ds);
                            ds.Clear();
                            ds.Clear();
                            da = new SqlDataAdapter("select * from sozlesme order by s_id", baglanti);
                            da.Fill(ds, "sozlesme");
                            da.Fill(ds, "sozlesme");
                            dgw_sozlesme.DataSource = ds;
                            dgw_sozlesme.DataMember = "sozlesme";
                            dgw_musteri.DataSource = ds;
                            dgw_musteri.DataMember = "sozlesme";
                            bm = this.BindingContext[ds, "sozlesme"];
                            bm = BindingContext[ds, "sozlesme"];
                        }
                        else
                        {

                            MessageBox.Show("Bir Hata Oluştu: Sözleşme İptal Edilemedi! ");
                        }
                        AracListele();
                        SozlesmeListele();
                        VeriYenile2();

                    }
                    else
                    {
                        MessageBox.Show("Lütfen İptal Edilecek Sözleşmeyi Seçiniz!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                komut = new SqlCommand("insert into tamamlananSozlesme (tc,isim,soyisim,telefon,plaka,baslangic,bitis,gun,ucret,k_adi) values (@tc,@isim,@soyisim,@tel,@plaka,@baslangic,@bitis,@gun,@ucret,@kadi)", baglanti);
                komut.Parameters.AddWithValue("@tc", dgw_sozlesme.CurrentRow.Cells[1].Value);
                komut.Parameters.AddWithValue("@isim", dgw_sozlesme.CurrentRow.Cells[2].Value);
                komut.Parameters.AddWithValue("@soyisim", dgw_sozlesme.CurrentRow.Cells[3].Value);
                komut.Parameters.AddWithValue("@tel", dgw_sozlesme.CurrentRow.Cells[4].Value);
                komut.Parameters.AddWithValue("@plaka", dgw_sozlesme.CurrentRow.Cells[5].Value);
                komut.Parameters.AddWithValue("@ucret", dgw_sozlesme.CurrentRow.Cells[14].Value);
                komut.Parameters.AddWithValue("@gun", dgw_sozlesme.CurrentRow.Cells[16].Value);
                komut.Parameters.AddWithValue("@baslangic", dgw_sozlesme.CurrentRow.Cells[17].Value);
                komut.Parameters.AddWithValue("@bitis", dgw_sozlesme.CurrentRow.Cells[18].Value);
                komut.Parameters.AddWithValue("@kadi", AktifKullanici.KullaniciAdi);

                komut.ExecuteNonQuery();
                baglanti.Close();
                int id = Convert.ToInt32(dgw_sozlesme.CurrentRow.Cells[0].Value);
                if (id != null)
                {
                    baglanti.Open();

                    komut = new SqlCommand("delete from sozlesme where s_id=@id", baglanti);
                    komut.Parameters.AddWithValue("@id", dgw_sozlesme.CurrentRow.Cells["s_id"].Value);
                    komut.ExecuteNonQuery();


                    da = new SqlDataAdapter("select * from sozlesme order by s_id", baglanti);
                    da.Fill(ds, "sozlesme");
                    dgw_sozlesme.DataSource = ds;
                    dgw_sozlesme.DataMember = "sozlesme";

                    bm = BindingContext[ds, "sozlesme"];
                    SozlesmeListele();
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Bir Hata Oluştu: Teslim etmek için bir araç seşiniz! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        private void txtMaxUcret_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtMinUcret_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtMaxYil_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtMinYil_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbVites_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtRenk_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtSeri_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtPlaka_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbYakıt_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbKasa_DropDown(object sender, EventArgs e)
        {
            cmbKasa.Items.Clear(); // Listeyi temizle
            cmbKasa.Items.Add("SEÇ"); // İlk eleman olarak "SEÇ" ekle

            using (SqlConnection conn = new SqlConnection(Baglan.baglanti))
            {
                string query = "SELECT DISTINCT kasa FROM araba_yonetimi"; // Farklı kasa tipleri
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbKasa.Items.Add(reader["kasa"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                AracListele();
                //HamzadgwAraba.Columns["kasa"].HeaderText = "Kasa Tipi"; // Başlık ayarı
            }
        }

        private void dgw_musteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string selectedValue = dgw_musteri.Rows[e.RowIndex].Cells[1].Value.ToString(); // 
                    txt_Mara.Text = selectedValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());

            }
        }
    }
}