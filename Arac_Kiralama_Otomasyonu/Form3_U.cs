using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{

    public partial class Form3_U : Form
    {
        public Form3_U()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public Form3 frm3 = new Form3();
        public Form1 frm1 = new Form1();


        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBrand.Text == "" || txtSeri.Text == "" || txtModel.Text == "" || txtPlaka.Text == "" || txtColor.Text == "" || cmbKasa.Text == "" || cmbVites.Text == "SEÇ" || comboBox1.Text == "SEÇ" || txtDayPrice.Text == "" || txtYili.Text == "" || cmbYakıt.Text == "")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                    return;
                }
                if (txtPlaka.Text.Length > 8 || txtPlaka.Text.Length < 7)
                {
                    MessageBox.Show("Lütfen plaka bilgisini doğru giriniz. Boşluk Bırakmadan ve  7 veya 8 karakter şeklinde giriniz!");
                    return;
                }
                byte[] resimByte = null;
                if (pictureBox1.ImageLocation != null)
                {
                    resimByte = File.ReadAllBytes(pictureBox1.ImageLocation); // Resmi byte dizisine çevir
                }
                // Güncelleme
                if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                {
                    da = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand();
                    string güncelle;
                    güncelle = "UPDATE araba_yonetimi SET yili=@yili,seri=@seri, marka=@marka, model=@model, plaka=@plaka, yakit=@yakıt_turu, rengi=@araba_rengi, kasa=@kasa, durumu=@araba_durumu, vites=@vites, kira_ucreti=@gunluk_kira, fotografi=@fotografi WHERE id=@id";
                    cmd = new SqlCommand(güncelle, baglanti);
                    cmd.Parameters.AddWithValue("@marka", txtBrand.Text);
                    cmd.Parameters.AddWithValue("@seri", txtSeri.Text);
                    cmd.Parameters.AddWithValue("@model", txtModel.Text);
                    cmd.Parameters.AddWithValue("@yili", txtYili.Text);
                    cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    cmd.Parameters.AddWithValue("@yakıt_turu", cmbYakıt.Text);
                    cmd.Parameters.AddWithValue("@araba_rengi", txtColor.Text);
                    cmd.Parameters.AddWithValue("@kasa", cmbKasa.Text);
                    cmd.Parameters.AddWithValue("@araba_durumu", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@vites", cmbVites.Text);
                    cmd.Parameters.AddWithValue("@gunluk_kira", txtDayPrice.Text);
                    cmd.Parameters.AddWithValue("@id", textBox8.Text);
                    cmd.Parameters.Add("@fotografi", SqlDbType.VarBinary).Value = (object)resimByte ?? DBNull.Value;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    da = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand();
                    string güncelle;
                    güncelle = "UPDATE araba_yonetimi SET yili=@yili,seri=@seri, marka=@marka, model=@model, plaka=@plaka, yakit=@yakıt_turu, rengi=@araba_rengi, kasa=@kasa, durumu=@araba_durumu, vites=@vites, kira_ucreti=@gunluk_kira WHERE id=@id";
                    cmd = new SqlCommand(güncelle, baglanti);
                    cmd.Parameters.AddWithValue("@marka", txtBrand.Text);
                    cmd.Parameters.AddWithValue("@seri", txtSeri.Text);
                    cmd.Parameters.AddWithValue("@model", txtModel.Text);
                    cmd.Parameters.AddWithValue("@yili", txtYili.Text);
                    cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    cmd.Parameters.AddWithValue("@yakıt_turu", cmbYakıt.Text);
                    cmd.Parameters.AddWithValue("@araba_rengi", txtColor.Text);
                    cmd.Parameters.AddWithValue("@kasa", cmbKasa.Text);
                    cmd.Parameters.AddWithValue("@araba_durumu", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@vites", cmbVites.Text);
                    cmd.Parameters.AddWithValue("@gunluk_kira", txtDayPrice.Text);
                    cmd.Parameters.AddWithValue("@id", textBox8.Text);
                    //cmd.Parameters.Add("@fotografi", SqlDbType.VarBinary).Value = (object)resimByte ?? DBNull.Value;
                    cmd.ExecuteNonQuery();
                }

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // Veri Yenileme
                frm3.ds.Clear();
                da = new SqlDataAdapter("select id,marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili from araba_yonetimi order by id", baglanti);
                da.Fill(frm3.ds, "araba_yonetimi");
                frm3.dgwAraba.DataSource = frm3.ds;
                frm3.dgwAraba.DataMember = "araba_yonetimi";
                frm3.bm = frm3.BindingContext[frm3.ds, "araba_yonetimi"];

                frm3.VeriYenile();
                baglanti.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Form3 frm3 = new Form3();
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                ds.Clear();
                da = new SqlDataAdapter("SELECT * FROM araba_yonetimi where id='" + textBox8.Text + "'", baglanti);
                da.Fill(ds, "araba_yonetimi");
                txtBrand.DataBindings.Clear();
                txtModel.DataBindings.Clear();
                txtYili.DataBindings.Clear();
                cmbKasa.DataBindings.Clear();
                cmbYakıt.DataBindings.Clear();
                cmbVites.DataBindings.Clear();
                txtPlaka.DataBindings.Clear();
                txtColor.DataBindings.Clear();
                txtDayPrice.DataBindings.Clear();
                comboBox1.DataBindings.Clear();
                pictureBox1.DataBindings.Clear();
                txtSeri.DataBindings.Clear();
                textBox8.DataBindings.Clear();

                SqlCommand kasaKomut = new SqlCommand("SELECT DISTINCT kasa FROM araba_yonetimi", baglanti);
                SqlDataReader kasaDr = kasaKomut.ExecuteReader();

                cmbKasa.Items.Clear(); // Önce temizleyin

                while (kasaDr.Read())
                {
                    cmbKasa.Items.Add(kasaDr["kasa"].ToString());
                }
                kasaDr.Close();



                if (ds.Tables["araba_yonetimi"].Rows.Count > 0)
                {
                    txtBrand.DataBindings.Add("text", ds, "araba_yonetimi.marka");
                    txtSeri.DataBindings.Add("text", ds, "araba_yonetimi.seri");
                    txtModel.DataBindings.Add("text", ds, "araba_yonetimi.model");
                    txtYili.DataBindings.Add("text", ds, "araba_yonetimi.yili");
                    cmbKasa.DataBindings.Add("text", ds, "araba_yonetimi.kasa"); 
                    cmbYakıt.DataBindings.Add("text", ds, "araba_yonetimi.yakit");
                    cmbVites.DataBindings.Add("text", ds, "araba_yonetimi.vites");
                    txtPlaka.DataBindings.Add("text", ds, "araba_yonetimi.plaka");
                    txtColor.DataBindings.Add("text", ds, "araba_yonetimi.rengi");
                    txtDayPrice.DataBindings.Add("text", ds, "araba_yonetimi.kira_ucreti");
                    comboBox1.DataBindings.Add("text", ds, "araba_yonetimi.durumu");
                    pictureBox1.DataBindings.Add("image", ds, "araba_yonetimi.fotografi", true);
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }

            /*openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            var yol = openFileDialog1.FileName;*/

        }

        private void Form3_U_Load(object sender, EventArgs e)
        {

        }

        private void cmbKasa_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                
            }
        }
    }
}
