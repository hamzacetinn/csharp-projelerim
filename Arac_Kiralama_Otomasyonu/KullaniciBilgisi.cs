using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class KullaniciBilgisi : Form
    {
        public KullaniciBilgisi()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();
        DataSet ds = new DataSet();
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        BindingManagerBase bm;
        private void KullaniciBilgisi_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(470, 387);
            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnListe.Enabled = true;
            btnEditEx.Visible = false;
            btnListeEx.Visible = false;
            btnClear.Visible = false;   
            btnDelet.Visible = false;

            string connectionString = Baglan.baglanti;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT *FROM kullanici WHERE k_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", AktifKullanici.KullaniciID);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtAd.Text = dr["k_adi"].ToString();
                    txtSoyAd.Text = dr["k_soyadi"].ToString();
                    txtGorev.Text = dr["k_görevi"].ToString();
                    txtAdres.Text = dr["k_adresi"].ToString();
                    txtMail.Text = dr["k_mail"].ToString();
                    txtTel1.Text = dr["k_tel"].ToString();
                    txtTel2.Text = dr["k_tel_yakin"].ToString();
                    txtSifre.Text = dr["k_sifre"].ToString();

                    if (dr["fotografi"] != DBNull.Value)
                    {
                        byte[] resim = (byte[])dr["fotografi"];
                        MemoryStream ms = new MemoryStream(resim);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources._3__8_;
                    }
                }
                baglanti.Close();
                dr.Close();
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            string connectionString = Baglan.baglanti;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                {
                    FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] resim = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    conn.Open();
                    string query = "insert into kullanici (k_adi, k_soyadi, k_görevi, k_adresi, k_mail,k_tel,k_tel_yakin,k_sifre,fotografi)  values( @adi,@soyad,@gorevi,@adres,@mail,@tel1,@tel2,@sifre,@foto)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@adi", txtAd.Text);
                    cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
                    cmd.Parameters.AddWithValue("@gorevi", txtGorev.Text);
                    cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                    cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                    cmd.Parameters.AddWithValue("@tel1", txtTel1.Text);
                    cmd.Parameters.AddWithValue("@tel2", txtTel2.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                    cmd.Parameters.Add("@foto", SqlDbType.Image, resim.Length).Value = resim;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    string query = "insert into kullanici (k_adi, k_soyadi, k_görevi, k_adresi, k_mail,k_tel,k_tel_yakin,k_sifre)  values( @adi,@soyad,@gorevi,@adres,@mail,@tel1,@tel2,@sifre)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@adi", txtAd.Text);
                    cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
                    cmd.Parameters.AddWithValue("@gorevi", txtGorev.Text);
                    cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                    cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                    cmd.Parameters.AddWithValue("@tel1", txtTel1.Text);
                    cmd.Parameters.AddWithValue("@tel2", txtTel2.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                    ;
                    cmd.ExecuteNonQuery();
                    da = new SqlDataAdapter("select k_id,k_adi, k_soyadi, k_görevi, k_adresi, k_mail,k_tel,k_tel_yakin,k_sifre from kullanici order by k_id", conn);
                    ds.Clear();
                    da.Fill(ds, "kullanici");
                    dgw_kullanici.DataSource = ds.Tables["kullanici"];
                    conn.Close();
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(AktifKullanici.Gorev == "Yönetici")
            {
                openFileDialog1.Title = "Resim Seçiniz";
                openFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = openFileDialog1.FileName;
                }
            }
            else
            {
                MessageBox.Show("Bu işlem için yetkiniz yok.");
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = Baglan.baglanti;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    if (btnListe.Focused == false)
                    {
                        if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                        {
                            if (conn.State == ConnectionState.Closed) conn.Open();

                            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            byte[] resim = br.ReadBytes((int)fs.Length);
                            br.Close();
                            fs.Close();

                            string query = "update kullanici set k_adi=@adi,k_soyadi=@soyad,k_görevi=@gorevi,k_adresi=@adres,k_mail=@mail,k_tel=@tel1,k_tel_yakin=@tel2,k_sifre=@sifre,fotografi=@foto where k_id=@id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", dgw_kullanici.SelectedRows[0].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@adi", txtAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
                            cmd.Parameters.AddWithValue("@gorevi", txtGorev.Text);
                            cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                            cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                            cmd.Parameters.AddWithValue("@tel1", txtTel1.Text);
                            cmd.Parameters.AddWithValue("@tel2", txtTel2.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                            cmd.Parameters.Add("@foto", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            openFileDialog1.FileName = "";
                        }
                        else
                        {
                            if (conn.State == ConnectionState.Closed) conn.Open();
                            string query = "update kullanici set k_adi=@adi,k_soyadi=@soyad,k_görevi=@gorevi,k_adresi=@adres,k_mail=@mail,k_tel=@tel1,k_tel_yakin=@tel2,k_sifre=@sifre where k_id=@id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", dgw_kullanici.SelectedRows[0].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@adi", txtAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
                            cmd.Parameters.AddWithValue("@gorevi", txtGorev.Text);
                            cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                            cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                            cmd.Parameters.AddWithValue("@tel1", txtTel1.Text);
                            cmd.Parameters.AddWithValue("@tel2", txtTel2.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                            //cmd.Parameters.Add("@foto", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    if (btnListe.Focused == true)
                    {
                        if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                        {
                            if (conn.State == ConnectionState.Closed) conn.Open();
                            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            byte[] resim = br.ReadBytes((int)fs.Length);
                            br.Close();
                            fs.Close();
                            conn.Open();

                            string query = "update kullanici set k_adi=@adi,k_soyadi=@soyad,k_görevi=@gorevi,k_adresi=@adres,k_mail=@mail,k_tel=@tel1,k_tel_yakin=@tel2,k_sifre=@sifre,fotografi=@foto where k_id=@id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", AktifKullanici.KullaniciID);
                            cmd.Parameters.AddWithValue("@adi", txtAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
                            cmd.Parameters.AddWithValue("@gorevi", txtGorev.Text);
                            cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                            cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                            cmd.Parameters.AddWithValue("@tel1", txtTel1.Text);
                            cmd.Parameters.AddWithValue("@tel2", txtTel2.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                            cmd.Parameters.Add("@foto", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            openFileDialog1.FileName = "";
                        }
                        else
                        {
                            if (conn.State == ConnectionState.Closed) conn.Open();
                            string query = "update kullanici set k_adi=@adi,k_soyadi=@soyad,k_görevi=@gorevi,k_adresi=@adres,k_mail=@mail,k_tel=@tel1,k_tel_yakin=@tel2,k_sifre=@sifre where k_id=@id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", dgw_kullanici.SelectedRows[0].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@adi", txtAd.Text);
                            cmd.Parameters.AddWithValue("@soyad", txtSoyAd.Text);
                            cmd.Parameters.AddWithValue("@gorevi", txtGorev.Text);
                            cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                            cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                            cmd.Parameters.AddWithValue("@tel1", txtTel1.Text);
                            cmd.Parameters.AddWithValue("@tel2", txtTel2.Text);
                            cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                            //cmd.Parameters.Add("@foto", SqlDbType.Image, resim.Length).Value = resim;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    da = new SqlDataAdapter("select k_id,k_adi, k_soyadi, k_görevi, k_adresi, k_mail,k_tel,k_tel_yakin,k_sifre from kullanici order by k_id", conn);
                    ds.Clear();
                    da.Fill(ds, "kullanici");
                    dgw_kullanici.DataSource = ds.Tables["kullanici"];
                    conn.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (AktifKullanici.Gorev == "Yönetici")
            {
                /* txtAd.Clear();
                 txtSoyAd.Clear();
                 txtGorev.Clear();
                 txtAdres.Clear();
                 txtMail.Clear();
                 txtTel1.Clear();
                 txtTel2.Clear();
                 txtSifre.Clear();*/

                txtAd.ReadOnly = false;
                txtSoyAd.ReadOnly = false;
                txtGorev.ReadOnly = false;
                txtAdres.ReadOnly = false;
                txtMail.ReadOnly = false;
                txtTel1.ReadOnly = false;
                txtTel2.ReadOnly = false;
                txtSifre.ReadOnly = false;
               


                btnEdit.Visible = false;
                btnEditEx.Visible = true;


                btnEkle.Visible = true;
                btnGuncelle.Visible = true;
                btnClear.Visible = true;
                btnDelet.Visible = true;
                btnClear.Visible = true;
                MessageBox.Show("Yetkiniz doğrulandı. Alanlar aktif edildi.");

            }
            else
            {
                MessageBox.Show("Bu işlem için yetkiniz yok.");
            }
        }

        private void btnEditEx_Click(object sender, EventArgs e)
        {
            //this.Size = new System.Drawing.Size(528, 299);
            txtAd.ReadOnly = true;
            txtSoyAd.ReadOnly = true;
            txtGorev.ReadOnly = true;
            txtAdres.ReadOnly = true;
            txtMail.ReadOnly = true;
            txtTel1.ReadOnly = true;
            txtTel2.ReadOnly = true;
            txtSifre.ReadOnly = true;
            btnEditEx.Visible = false;
            btnEdit.Visible = true;
            btnGuncelle.Visible = false;
            btnEkle.Visible = false;
            btnDelet.Visible = false;
            btnClear.Visible = false;




            txtAd.Clear();
            txtSoyAd.Clear();
            txtGorev.Clear();
            txtAdres.Clear();
            txtMail.Clear();
            txtTel1.Clear();
            txtTel2.Clear();
            txtSifre.Clear();

            string connectionString = Baglan.baglanti;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                string query = "SELECT k_adi, k_soyadi, k_görevi, k_adresi, k_mail,k_tel,k_tel_yakin, k_sifre FROM kullanici WHERE k_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", AktifKullanici.KullaniciID);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtAd.Text = dr["k_adi"].ToString();
                    txtSoyAd.Text = dr["k_soyadi"].ToString();
                    txtGorev.Text = dr["k_görevi"].ToString();
                    txtAdres.Text = dr["k_adresi"].ToString();
                    txtMail.Text = dr["k_mail"].ToString();
                    txtTel1.Text = dr["k_tel"].ToString();
                    txtTel2.Text = dr["k_tel_yakin"].ToString();
                    txtSifre.Text = dr["k_sifre"].ToString();
                }
                dr.Close();
            }
        }
        private void btnListe_Click(object sender, EventArgs e)
        {


           
            if (AktifKullanici.Gorev == "Yönetici")
            {
                this.Size = new System.Drawing.Size(1200, 387);

                /*txtAd.Clear();
                txtSoyAd.Clear();
                txtGorev.Clear();
                txtAdres.Clear();
                txtMail.Clear();
                txtTel1.Clear();
                txtTel2.Clear();
                txtSifre.Clear();*/

                btnListe.Visible = false;
                btnListeEx.Visible = true;



                if (btnEkle.Visible == false)
                {
                    txtAd.ReadOnly = true;
                    txtSoyAd.ReadOnly = true;
                    txtGorev.ReadOnly = true;
                    txtAdres.ReadOnly = true;
                    txtMail.ReadOnly = true;
                    txtTel1.ReadOnly = true;
                    txtTel2.ReadOnly = true;
                    txtSifre.ReadOnly = true;

                }
                else
                {
                    txtAd.ReadOnly = false;
                    txtSoyAd.ReadOnly = false;
                    txtGorev.ReadOnly = false;
                    txtAdres.ReadOnly = false;
                    txtMail.ReadOnly = false;
                    txtTel1.ReadOnly = false;
                    txtTel2.ReadOnly = false;
                    txtSifre.ReadOnly = false;
                }

                dgw_kullanici.Visible = true;

                if (btnEdit.Focused == true || btnEdit.Visible == false)
                {
                    btnEkle.Visible = true;
                    btnGuncelle.Visible = true;
                }
                else
                {
                    btnEkle.Visible = false;
                    btnGuncelle.Visible = false;
                }




                SqlDataAdapter da = new SqlDataAdapter("select k_id,k_adi, k_soyadi, k_görevi, k_adresi, k_mail,k_tel,k_tel_yakin,k_sifre from kullanici", baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds, "kullanici");
                dgw_kullanici.DataSource = ds.Tables["kullanici"];

            }
            else
            {
                MessageBox.Show("Bu işlem için yetkiniz yok.");
            }
        }

        private void dgw_kullanici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtAd.Clear();
                txtSoyAd.Clear();
                txtGorev.Clear();
                txtAdres.Clear();
                txtMail.Clear();
                txtTel1.Clear();
                txtTel2.Clear();
                txtSifre.Clear();

                txtAd.Text = dgw_kullanici.SelectedRows[0].Cells[1].Value.ToString();
                txtSoyAd.Text = dgw_kullanici.SelectedRows[0].Cells[2].Value.ToString();
                txtGorev.Text = dgw_kullanici.SelectedRows[0].Cells[3].Value.ToString();
                txtAdres.Text = dgw_kullanici.SelectedRows[0].Cells[4].Value.ToString();
                txtMail.Text = dgw_kullanici.SelectedRows[0].Cells[5].Value.ToString();
                txtTel1.Text = dgw_kullanici.SelectedRows[0].Cells[6].Value.ToString();
                txtTel2.Text = dgw_kullanici.SelectedRows[0].Cells[7].Value.ToString();
                txtSifre.Text = dgw_kullanici.SelectedRows[0].Cells[8].Value.ToString();

                var selectedId = dgw_kullanici.SelectedRows[0].Cells[0].Value;
                if (selectedId == null || selectedId == DBNull.Value)
                {
                    MessageBox.Show("Seçilen kullanıcı ID'si alınamadı.");
                    return;
                }

                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from kullanici where k_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", dgw_kullanici.SelectedRows[0].Cells[0].Value);
                SqlDataReader dr = komut.ExecuteReader(); //hata alınan yer
                if (dr.Read())
                {
                    if (dr["fotografi"] != DBNull.Value)
                    {
                        byte[] resim = new byte[0];
                        resim = (byte[])dr["fotografi"];
                        MemoryStream ms = new MemoryStream(resim);
                        pictureBox1.Image = Image.FromStream(ms);
                        dr.Close();
                        ms.Close();
                        
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources._3__8_;
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());

            }
        }
        private void btnListeEx_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(470, 387);
            txtAd.ReadOnly = true;
            txtSoyAd.ReadOnly = true;
            txtGorev.ReadOnly = true;
            txtAdres.ReadOnly = true;
            txtMail.ReadOnly = true;
            txtTel1.ReadOnly = true;
            txtTel2.ReadOnly = true;
            txtSifre.ReadOnly = true;
            dgw_kullanici.Visible = false;
            if (btnEkle.Visible == false)
            {
                txtAd.ReadOnly = true;
                txtSoyAd.ReadOnly = true;
                txtGorev.ReadOnly = true;
                txtAdres.ReadOnly = true;
                txtMail.ReadOnly = true;
                txtTel1.ReadOnly = true;
                txtTel2.ReadOnly = true;
                txtSifre.ReadOnly = true;
            }
            else
            {
                txtAd.ReadOnly = false;
                txtSoyAd.ReadOnly = false;
                txtGorev.ReadOnly = false;
                txtAdres.ReadOnly = false;
                txtMail.ReadOnly = false;
                txtTel1.ReadOnly = false;
                txtTel2.ReadOnly = false;
                txtSifre.ReadOnly = false;
            }
            btnListeEx.Visible = false;
            btnListe.Visible = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyAd.Clear();
            txtGorev.Clear();
            txtAdres.Clear();
            txtMail.Clear();
            txtTel1.Clear();
            txtTel2.Clear();
            txtSifre.Clear();
            pictureBox1.Image = Properties.Resources._3__8_;
            openFileDialog1.FileName = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            try
            {
                if (dgw_kullanici.SelectedCells.Count > 0)
                {
                    int id = Convert.ToInt32(dgw_kullanici.CurrentRow.Cells[0].Value);
                    if (id != null)
                    {
                        baglanti = new SqlConnection(Baglan.baglanti);
                        if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                        da = new SqlDataAdapter("DELETE FROM kullanici where k_id=" + id, baglanti);
                        da.Fill(ds);
                        ds.Clear();
                        frm5.ds.Clear();
                        da = new SqlDataAdapter("select k_id,k_adi, k_soyadi, k_görevi, k_adresi, k_mail,k_tel,k_tel_yakin,k_sifre from kullanici order by k_id", baglanti);
                        ds.Clear();
                        da.Fill(ds, "kullanici");
                        dgw_kullanici.DataSource = ds.Tables["kullanici"];

                        bm = BindingContext[ds, "kullanici"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
            baglanti.Close();
        }
    }
}
