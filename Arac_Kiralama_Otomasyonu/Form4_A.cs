using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form4_A : Form
    {
        public Form4 frm4 = new Form4();
        public Form4_A()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingManagerBase bm;
        public Form1 frm1 = new Form1();



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_tctno.Text.Length != 11)
                {
                    MessageBox.Show("Lütfen TC Kimlik No bilgisini doğru giriniz. Lütfen tam 11 karakterden oluştuğundan emin olunuz.");
                    return;
                }
                if (txt_tel.Text == "" || txt_tctno.Text == "" || txtSoyad.Text == "" || txtAd.Text == "")
                {
                    MessageBox.Show("Lütfen Zorunlu alanları boş bırakmayızınız!");
                    return;
                }
                
                baglanti = new SqlConnection(Baglan.baglanti);
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                da = new SqlDataAdapter("INSERT INTO musteri_yonetimi (tc_no, isim, soy_isim, tel1, tel2, mail) VALUES (@q1, @q2, @q3, @q4, @q5, @q6)", baglanti);
                da.SelectCommand.Parameters.AddWithValue("@q1", txt_tctno.Text); // tc_no
                da.SelectCommand.Parameters.AddWithValue("@q2", txtAd.Text); // isim
                da.SelectCommand.Parameters.AddWithValue("@q3", txtSoyad.Text); // soy_isim
                da.SelectCommand.Parameters.AddWithValue("@q4", txt_tel.Text); // telefon
                da.SelectCommand.Parameters.AddWithValue("@q5", txt_tel2.Text); // telefon2
                da.SelectCommand.Parameters.AddWithValue("@q6", txtmail.Text); // mail
                da.Fill(frm4.ds, "musteri_yonetimi");
                frm4.dataGridView1.DataSource = frm4.ds;
                frm4.dataGridView1.DataMember = "musteri_yonetimi";
                frm4.ds.Clear();
                da = new SqlDataAdapter("select*from musteri_yonetimi order by m_id", baglanti);
                bm = BindingContext[frm4.ds, "musteri_yonetimi"];

                frm4.VeriYenile();
                baglanti.Close();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_A_Load(object sender, EventArgs e)
        {

        }
    }
}
