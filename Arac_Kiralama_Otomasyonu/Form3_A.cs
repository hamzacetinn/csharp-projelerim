using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form3_A : Form
    {

        public Form3_A()
        {
            InitializeComponent();

        }
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        public Form3 frm3 = new Form3();
        public Form1 frm1 = new Form1();


        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarka.Text == "" || txtModel.Text == "" || txtPlaka.Text == "" || txtRengi.Text == "" || txtKasa.Text == "" || cmbVites.Text == "SEÇ" || cmbYakıt.Text == "SEÇ" || txtKira.Text == "" || txtYili.Text == "")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                    return;
                }
                if (txtPlaka.Text.Length > 8 || txtPlaka.Text.Length < 7)
                {
                    MessageBox.Show("Lütfen plaka bilgisini doğru giriniz. Boşluk Bırakmadan ve  7 veya 8 karakter şeklinde giriniz!");

                    return;
                }
                /*  byte[] resimByte = null;
                  if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
                  {
                      resimByte = File.ReadAllBytes(pictureBox1.ImageLocation);
                  }*/

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                {
                    FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    byte[] resim = binaryReader.ReadBytes((int)fileStream.Length);
                    binaryReader.Close();
                    fileStream.Close();

                    string ekle = "insert into araba_yonetimi (marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili,fotografi) values(@marka,@seri,@model,@plaka,@yakit,@rengi,@kasa,@durumu,@vites,@kira_ucreti,@yili,@fotografi)";
                    SqlCommand cmd = new SqlCommand(ekle, baglanti);
                    cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                    cmd.Parameters.AddWithValue("@seri", txtSeri.Text);
                    cmd.Parameters.AddWithValue("@model", txtModel.Text);
                    cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    cmd.Parameters.AddWithValue("@yakit", cmbYakıt.Text);
                    cmd.Parameters.AddWithValue("@rengi", txtRengi.Text);
                    cmd.Parameters.AddWithValue("@kasa", txtKasa.Text);
                    cmd.Parameters.AddWithValue("@durumu", "MUSAIT");
                    cmd.Parameters.AddWithValue("@vites", cmbVites.Text);
                    cmd.Parameters.AddWithValue("@kira_ucreti", txtKira.Text);
                    cmd.Parameters.AddWithValue("@yili", txtYili.Text);
                    // Resmi byte dizisine çevir
                    cmd.Parameters.Add("@fotografi", SqlDbType.Image, resim.Length).Value = resim;

                    // cmd.Parameters.Add("@fotografi", SqlDbType.VarBinary).Value = (object)resimByte ?? DBNull.Value;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string ekle = "insert into araba_yonetimi (marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili) values(@marka,@seri,@model,@plaka,@yakit,@rengi,@kasa,@durumu,@vites,@kira_ucreti,@yili)";
                    SqlCommand cmd = new SqlCommand(ekle, baglanti);
                    cmd.Parameters.AddWithValue("@marka", txtMarka.Text);
                    cmd.Parameters.AddWithValue("@seri", txtSeri.Text);
                    cmd.Parameters.AddWithValue("@model", txtModel.Text);
                    cmd.Parameters.AddWithValue("@plaka", txtPlaka.Text);
                    cmd.Parameters.AddWithValue("@yakit", cmbYakıt.Text);
                    cmd.Parameters.AddWithValue("@rengi", txtRengi.Text);
                    cmd.Parameters.AddWithValue("@kasa", txtKasa.Text);
                    cmd.Parameters.AddWithValue("@durumu", "MUSAIT");
                    cmd.Parameters.AddWithValue("@vites", cmbVites.Text);
                    cmd.Parameters.AddWithValue("@kira_ucreti", txtKira.Text);
                    cmd.Parameters.AddWithValue("@yili", txtYili.Text);
                    // Resmi byte dizisine çevir
                    // cmd.Parameters.Add("@fotografi", SqlDbType.Image, resim.Length).Value = resim;

                    // cmd.Parameters.Add("@fotografi", SqlDbType.VarBinary).Value = (object)resimByte ?? DBNull.Value;
                    cmd.ExecuteNonQuery();
                }


                da = new SqlDataAdapter("select id,marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili from araba_yonetimi order by id ", baglanti);
                da.Fill(ds, "araba_yonetimi");
                frm3.dgwAraba.DataSource = ds;
                frm3.dgwAraba.DataMember = "araba_yonetimi";
                txtMarka.Clear();
                txtModel.Clear();
                txtKasa.Clear();
                cmbYakıt.SelectedIndex = 0;
                cmbVites.SelectedIndex = 0;
                txtPlaka.Clear();
                txtKira.Clear();
                txtYili.Clear();
                frm3.bm = frm3.BindingContext[ds, "araba_yonetimi"];

                frm3.VeriYenile();
                baglanti.Close();
                MessageBox.Show("Araç başarıyla eklendi!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_A_Load(object sender, EventArgs e)
        {
            cmbYakıt.SelectedIndex = 0;
            cmbVites.SelectedIndex = 0;
            //cmbKasa.SelectedIndex = 0;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string imagepath;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;
            }
            /*openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;*/
        }

        private void txtKasa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
