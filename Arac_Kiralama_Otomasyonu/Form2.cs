using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        FormResizer resizer = new FormResizer();
        public Form1 frm1 = new Form1();
        KullaniciBilgisi klb;
        Form3 frm3;
        Form4 frm4;
        Form5 frm5;
        Form6 frm6;



        private void Form2_Load(object sender, EventArgs e)
        {
            resizer.CaptureInitialSizes(this);
            this.KeyPreview = true; // Klavye olaylarını önce formun yakalamasını sağlar
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1250, 700);//ilk baştaki boyut
            TopMost = false;
            //Giriş yapan Kullanıcı
            lb_kullanici.Text =AktifKullanici.KullaniciAdi;

        }
        private void btn_arc_yonetimi_Click(object sender, EventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new Form3();
                frm3.Show();

                frm3.Owner = this; // Form3'ün sahibi olarak Form2'yi ayarlıyoruz
                frm3.TopMost = true;
            }
            else
            {
                frm3.BringToFront(); // Form zaten açıksa öne getir
            }

        }
        private void btn_musteri_yonetimi_Click(object sender, EventArgs e)
        {

            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new Form4();
                frm4.Show();
                frm4.Owner = this;
                frm4.TopMost = true;
            }
            else
            {
                frm4.BringToFront(); // Form zaten açıksa öne getir
            }
        }
        private void btn_sozlesme_Click(object sender, EventArgs e)
        {
            
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new Form6();
                frm6.Show();
                frm6.Owner = this;
                frm6.TopMost = true;
            }
            else
            {
                frm6.BringToFront(); // Form zaten açıksa öne getir
            }
        }
        private void btn_kiralama_islemleri_Click(object sender, EventArgs e)
        {
           
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new Form5();
                frm5.Show();
                frm5.Owner = this;
                frm5.TopMost = true;
                
            }
            else
            {
                frm5.BringToFront(); // Form zaten açıksa öne getir
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_KulCikisi_Click(object sender, EventArgs e)
        {
            frm1.Show();
            this.Close();
        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            resizer.ResizeControls(this);
        }
        //TAM EKRAN
        private bool tamEkranModu = false; // Tam ekran durumunu takip eden değişken
        private void Form2_KeyUp(object sender, KeyEventArgs e)
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
                
                tamEkranModu = !tamEkranModu;
            } // Durumu tersine çevir*/
        }
        private void lb_kullanici_Click(object sender, EventArgs e)
        {
            if (klb == null || klb.IsDisposed)
            {

                klb = new KullaniciBilgisi();
                klb.Show();
                klb.Owner = this; // Form3'ün sahibi olarak Form2'yi ayarlıyoruz
                klb.TopMost = true;
            }
            else
            {
                klb.BringToFront(); // Form zaten açıksa öne getir
            }
        }
        private void lb_kullanici_MouseLeave(object sender, EventArgs e)
        {
           // lb_kullanici.ForeColor = Color.FromArgb(127, 127, 127);
        }
        private void lb_kullanici_MouseMove(object sender, MouseEventArgs e)
        {
           // lb_kullanici.ForeColor = Color.FromArgb(170, 170, 170);

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (klb == null || klb.IsDisposed)
            {

                klb = new KullaniciBilgisi();
                klb.Show();
                klb.Owner = this; // Form3'ün sahibi olarak Form2'yi ayarlıyoruz
                klb.TopMost = true;
            }
            else
            {
                klb.BringToFront(); // Form zaten açıksa öne getir
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbKullanici_Click(object sender, EventArgs e)
        {
            if (klb == null || klb.IsDisposed)
            {

                klb = new KullaniciBilgisi();
                klb.Show();
                klb.Owner = this; // Form3'ün sahibi olarak Form2'yi ayarlıyoruz
                klb.TopMost = true;
            }
            else
            {
                klb.BringToFront(); // Form zaten açıksa öne getir
            }
        }
    }
}
