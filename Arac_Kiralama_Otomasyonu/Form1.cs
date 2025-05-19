using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form1 : Form
    {
        public string personel;

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        SqlDataReader dr;

        private void Form1_Load(object sender, EventArgs e)
        {
            BitmisSozlesmeleriIsle();
        }

        SqlCommand komut = new SqlCommand();
        private void btn_giris_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciAdi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                bool giris = false;
                komut = new SqlCommand("SELECT * FROM kullanici WHERE k_adi=@kadi AND k_sifre=@sifre", baglanti);
                komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    if (oku["k_adi"].ToString() == kullaniciAdi && oku["k_sifre"].ToString() == sifre)
                    {
                        giris = true;
                        //Program.KullaniciAdi = kullaniciAdi;
                        AktifKullanici.KullaniciID = Convert.ToInt32(oku["k_id"]);
                        AktifKullanici.KullaniciAdi = kullaniciAdi;
                        AktifKullanici.Gorev = oku["k_görevi"].ToString();


                        txtKullaniciAdi.Clear();
                        txtSifre.Clear();

                        oku.Close();
                        baglanti.Close();
                        Form2 frm2 = new Form2();
                        frm2.frm1 = this;
                        frm2.Show();
                        this.Hide();
                    }

                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) && string.IsNullOrWhiteSpace(txtSifre.Text))
                    {

                        MessageBox.Show("Giriş Başarısız! Kullanıcı adı ve şifre alanları boş. Lüften ilgili alanları doldurunuz!");
                    }
                    else if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) && string.IsNullOrWhiteSpace(txtSifre.Text)!=null)
                    {

                        MessageBox.Show("Giriş Başarısız! Kullanıcı adı alanı boş. Lüften ilgili alanı doldurunuz!");
                    }
                    else if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) != null && string.IsNullOrWhiteSpace(txtSifre.Text))
                    {

                        MessageBox.Show("Giriş Başarısız! Şifre alanı boş. Lüften ilgili alanı doldurunuz!");
                    }
                    else
                    {
                        MessageBox.Show("Giriş Başarısız! Kullanıcı adı veya şifre hatalı.");
                    }
                }
                


                /*if (oku["k_adi"].ToString() != kullaniciAdi)
                {

                    MessageBox.Show("Giriş Başarısız! Kullanıcı adı hatalı.");
                }
                if (oku["k_sifre"].ToString() != sifre)
                {

                    MessageBox.Show("Giriş Başarısız! Şifre hatalı.");
                }*/

                oku.Close();
                baglanti.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  // Enter tuşuna basıldı mı?
            {
                btn_giris.PerformClick();   // Butonu programatik olarak tıkla
                e.SuppressKeyPress = true; // Enter tuşunun bip sesi çıkmasını engelle
            }
        }
        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  // Enter tuşuna basıldı mı?
            {
                btn_giris.PerformClick();   // Butonu programatik olarak tıkla
                e.SuppressKeyPress = true; // Enter tuşunun bip sesi çıkmasını engelle
            }
        }
        DateTime bugun = DateTime.Today;
        private void BitmisSozlesmeleriIsle()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // Bitmiş sözleşmeleri al
                SqlCommand komut = new SqlCommand(@" SELECT tamamlananSozlesme.plaka FROM tamamlananSozlesme  WHERE bitis <= @bugun AND durum != 'BİTTİ' ", baglanti);
                komut.Parameters.AddWithValue("@bugun", bugun);

                SqlDataReader dr = komut.ExecuteReader();
                List<string> bitmisPlakalar = new List<string>();

                while (dr.Read())
                {
                    bitmisPlakalar.Add(dr["plaka"].ToString());
                }
                dr.Close();

                foreach (var plaka in bitmisPlakalar)
                {
                    // Sözleşme durumunu güncelle
                    SqlCommand guncelleSozlesme = new SqlCommand("UPDATE tamamlananSozlesme SET durum='BİTTİ' WHERE plaka=@plaka AND durum != 'BİTTİ'", baglanti);
                    guncelleSozlesme.Parameters.AddWithValue("@plaka", plaka);
                    guncelleSozlesme.ExecuteNonQuery();

                    // Araç durumunu müsait yap
                    SqlCommand guncelleArac = new SqlCommand("UPDATE araba_yonetimi SET durumu='MUSAIT' WHERE plaka=@plaka", baglanti);
                    guncelleArac.Parameters.AddWithValue("@plaka", plaka);
                    guncelleArac.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Biten sözleşmeleri işlerken hata oluştu:\n" + ex.ToString());
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }
    }
}
