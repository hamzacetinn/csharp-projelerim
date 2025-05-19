using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form4_U : Form
    {
        public Form4_U()
        {
            InitializeComponent();
        }

       
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        public Form4 frm4 = new Form4();
        public Form1 frm1 = new Form1();

        private void Form4_U_Load(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (txtTC.Text.Length != 11)
                {
                    MessageBox.Show("Lütfen TC Kimlik No bilgisini doğru giriniz.");
                    return;
                }
                if (txtTelefon.Text == "" || txtTC.Text == "" || txtSoyad.Text == "" || txtAd.Text == "")
                {
                    MessageBox.Show("Lütfen Zorunlu alanları boş bırakmayızınız!");
                    return;
                }

                da = new SqlDataAdapter("update  musteri_yonetimi set isim=@ad, soy_isim=@soyad, tc_no=@tcno, tel1=@telefon, tel2=@telefon2, mail=@mail where m_id=@m_id", baglanti);
                da.SelectCommand.Parameters.AddWithValue("@m_id", txtMID.Text);
                da.SelectCommand.Parameters.AddWithValue("@ad", txtAd.Text);
                da.SelectCommand.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                da.SelectCommand.Parameters.AddWithValue("@tcno", txtTC.Text);
                da.SelectCommand.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                da.SelectCommand.Parameters.AddWithValue("@telefon2", txtTelefon2.Text);
                da.SelectCommand.Parameters.AddWithValue("@mail", txtMail.Text);
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                da.Fill(frm4.ds);
                //veri yenileme
                frm4.ds.Clear();
                da = new SqlDataAdapter("select * from musteri_yonetimi", baglanti);
                da.Fill(frm4.ds, "musteri_yonetimi");
                frm4.dataGridView1.DataSource = frm4.ds;
                frm4.dataGridView1.DataMember = "musteri_yonetimi";
                frm4.bm = frm4.BindingContext[frm4.ds, "musteri_yonetimi"];

                frm4.VeriYenile();
                baglanti.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMID.Text.Trim(), out int mid))
                {
                    // Geçerli bir sayı değilse, alanları temizle
                    txtAd.Text = "";
                    txtSoyad.Text = "";
                    txtTC.Text = "";
                    txtTelefon.Text = "";
                    txtTelefon2.Text = "";
                    txtMail.Text = "";
                    return;
                }

                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM musteri_yonetimi WHERE m_id = @mid", baglanti);
                cmd.Parameters.AddWithValue("@mid", mid);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtAd.Text = reader["isim"].ToString();
                    txtSoyad.Text = reader["soy_isim"].ToString();
                    txtTC.Text = reader["tc_no"].ToString();
                    txtTelefon.Text = reader["tel1"].ToString();
                    txtTelefon2.Text = reader["tel2"].ToString();
                    txtMail.Text = reader["mail"].ToString();
                }
                else
                {
                    // ID yoksa alanları temizle
                    txtAd.Text = "";
                    txtSoyad.Text = "";
                    txtTC.Text = "";
                    txtTelefon.Text = "";
                    txtTelefon2.Text = "";
                    txtMail.Text = "";
                }

                reader.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}

