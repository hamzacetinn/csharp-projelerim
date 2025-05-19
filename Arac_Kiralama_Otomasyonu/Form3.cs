using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        public SqlDataAdapter da;
        public DataSet ds = new DataSet();
        public BindingManagerBase bm;
        FormResizer resizer = new FormResizer();
        public void VeriYenile()
        {
            // Verileri temizle
            ds.Clear();

            // Verileri yeniden yükle
            //SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
            try
            {
                da = new SqlDataAdapter(" select id,marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili from araba_yonetimi order by id", baglanti);
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                da.Fill(ds, "araba_yonetimi");
                dgwAraba.DataSource = ds;
                dgwAraba.DataMember = "araba_yonetimi";
                bm = this.BindingContext[ds, "araba_yonetimi"];
                baglanti.Close();
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
                string plaka = txtPlaka.Text.Trim();
                string marka = txtMarka.Text.Trim();
                string seri = txtSeri.Text.Trim();
                string model = txtModel.Text.Trim();
                string kasa = cmbKasa.Text.Trim();
                string rengi = txtRenk.Text.Trim();
                string durumu = cmbDurum.Text.Trim();
                string yakit = cmbYakıt.Text.Trim();
                string vites = cmbVites.Text.Trim();
                int sec = 0;
                int min, max;
                int? minYil = int.TryParse(txtMinYil.Text, out min) ? min : (int?)null;
                int? maxYil = int.TryParse(txtMaxYil.Text, out max) ? max : (int?)null;
                int minU, maxU;
                int? minUcret = int.TryParse(txtMinUcret.Text, out minU) ? minU : (int?)null;
                int? maxUcret = int.TryParse(txtMaxUcret.Text, out maxU) ? maxU : (int?)null;

                DataTable dt = filtre.DinamikFiltrele(marka, seri, model, kasa, vites, yakit, rengi, sec, durumu, plaka, minYil, maxYil, minUcret, maxUcret);
                dgwAraba.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            resizer.CaptureInitialSizes(this);
            this.MinimumSize = new Size(1400, 720);
            btn_add.MinimumSize = new Size(100, 70);
            btn_delet.MinimumSize = new Size(100, 70);
            btn_update.MinimumSize = new Size(100, 70);
            dgwAraba.MinimumSize = new Size(120, 20);
            cmbDurum.SelectedIndex = 0;
            cmbVites.SelectedIndex = 0;
            cmbYakıt.SelectedIndex = 0;
            cmbKasa.SelectedIndex = 0;
            lb_kullanici.Text = AktifKullanici.KullaniciAdi;
            SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
            try
            {
                da = new SqlDataAdapter(" select id,marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili from araba_yonetimi order by id", baglanti);
                baglanti.Open();
                ds.Clear();
                da.Fill(ds, "araba_yonetimi");
                dgwAraba.DataSource = ds;
                dgwAraba.DataMember = "araba_yonetimi";
                bm = this.BindingContext[ds, "araba_yonetimi"];
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString());
            }

        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            Form3_A frm3_add = new Form3_A();
            frm3_add.Owner = this; // Form3'ün sahibi olarak Form2'yi ayarlıyoruz
            frm3_add.TopMost = true;
            frm3_add.frm3 = this;
            frm3_add.Show();
        }

        private void btn_delet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                if (dgwAraba.SelectedCells.Count > 0)
                {
                    int id;

                    if (int.TryParse(dgwAraba.CurrentRow.Cells["id"].Value.ToString(), out id))
                        if (id != null)
                        {
                            string deleteQuery = "DELETE FROM araba_yonetimi WHERE id = @id";
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, baglanti))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                            ds.Clear();
                            VeriYenile();
                            MessageBox.Show("Araç başarıyla silindi!");

                        }
                }
                else
                {
                    MessageBox.Show("Test", "Deneme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            Form3_U frm3_update = new Form3_U();
            frm3_update.frm3 = this;
            frm3_update.Owner = this; // Form3'ün sahibi olarak Form2'yi ayarlıyoruz
            frm3_update.TopMost = true;
            frm3_update.Show();
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            resizer.ResizeControls(this);
            //resizeChildrenControls();
        }
        private void txtKasa_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtPlaka_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtMarka_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtSeri_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtRenk_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbYakıt_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbVites_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbDurum_SelectedIndexChanged(object sender, EventArgs e)
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
        private void txtMinUcret_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtMaxUcret_TextChanged(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void txtSeri_TextChanged_1(object sender, EventArgs e)
        {
            FiltreUygula();
        }
        private void cmbKasa_SelectedIndexChanged(object sender, EventArgs e)
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
                da = new SqlDataAdapter("SELECT id,marka,seri,model,plaka,yakit,rengi,kasa,durumu,vites,kira_ucreti,yili FROM araba_yonetimi ORDER BY id", conn);
                ds.Clear();
                da.Fill(ds, "araba_yonetimi");
                dgwAraba.DataSource = ds;
                dgwAraba.DataMember = "araba_yonetimi";
                //HamzadgwAraba.Columns["kasa"].HeaderText = "Kasa Tipi"; // Başlık ayarı
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMarka.Clear();
            txtModel.Clear();
            txtPlaka.Clear();
            txtRenk.Clear();
            txtSeri.Clear();
            txtMinYil.Clear();
            txtMaxYil.Clear();
            txtMinUcret.Clear();
            txtMaxUcret.Clear();
            cmbDurum.SelectedIndex = 0;
            cmbKasa.SelectedIndex = 0;
            cmbVites.SelectedIndex = 0;
            cmbYakıt.SelectedIndex = 0;
            dgwAraba.ClearSelection();
        }
    }
}
