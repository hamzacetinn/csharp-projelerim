using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        public SqlDataAdapter da;
        public DataSet ds = new DataSet();
        public BindingManagerBase bm;
        FormResizer resizer = new FormResizer();
        public void VeriYenile()
        {
            // Verileri temizle
            ds.Clear();

            // Verileri yeniden yükle
            SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
            try
            {
                da = new SqlDataAdapter("select * from musteri_yonetimi order by m_id", baglanti);
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                da.Fill(ds, "musteri_yonetimi");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "musteri_yonetimi";
                bm = this.BindingContext[ds, "musteri_yonetimi"];
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1342, 730);
            resizer.CaptureInitialSizes(this);
            lb_kullanici.Text = AktifKullanici.KullaniciAdi;
            SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                da = new SqlDataAdapter("select* from musteri_yonetimi order by m_id", baglanti);
                ds.Clear();
                da.Fill(ds, "musteri_yonetimi");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "musteri_yonetimi";
                bm = this.BindingContext[ds, "musteri_yonetimi"];
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4_A frm4_add = new Form4_A();
            frm4_add.Owner = this; // Form4_A'nın sahibi olarak Form4'ü ayarlıyoruz
            frm4_add.TopMost = true;
            frm4_add.frm4 = this;
            frm4_add.Show();
        }
        private void btn_delet_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            try
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    if (id != null)
                    {
                        baglanti = new SqlConnection(Baglan.baglanti);
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        da = new SqlDataAdapter("DELETE FROM musteri_yonetimi where m_id=" + id, baglanti);
                        da.Fill(ds);
                        da.Fill(frm5.ds);
                        ds.Clear();
                        frm5.ds.Clear();
                        da = new SqlDataAdapter("select * from musteri_yonetimi order by m_id", baglanti);
                        da.Fill(ds, "musteri_yonetimi");
                        da.Fill(frm5.ds, "musteri_yonetimi");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "musteri_yonetimi";
                        frm5.dgw_musteri.DataSource = ds;
                        frm5.dgw_musteri.DataMember = "musteri_yonetimi";
                        bm = this.BindingContext[ds, "musteri_yonetimi"];
                        frm5.bm = frm5.BindingContext[frm5.ds, "musteri_yonetimi"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            baglanti.Close();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            Form4_U frm4u = new Form4_U();
            frm4u.Owner = this; // Form4_U'nun sahibi olarak Form4'ü ayarlıyoruz
            frm4u.TopMost = true;
            frm4u.frm4 = this;
            frm4u.Show();
        }
        private void Form4_Resize(object sender, EventArgs e)
        {
            resizer.ResizeControls(this);
        }
    }
}