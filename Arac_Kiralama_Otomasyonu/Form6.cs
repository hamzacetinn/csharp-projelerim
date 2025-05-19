using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        FormResizer resizer = new FormResizer();
        private void LoadData()
        {
            string connectionString = Baglan.baglanti; // Veritabanı bağlantı dizesi
            string query = "SELECT * FROM tamamlananSozlesme"; // Tabloyu seç

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgw_sozlesme.DataSource = dataTable; // DataGridView'i doldur
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            lb_kullanici.Text = AktifKullanici.KullaniciAdi;

            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            da = new SqlDataAdapter("select * from tamamlananSozlesme ORDER BY durum", baglanti);
            da.Fill(ds, "tamamlananSozlesme");
            dgw_sozlesme.DataSource = ds.Tables["tamamlananSozlesme"];
            resizer.CaptureInitialSizes(this);
        }

        private void Form6_Resize(object sender, EventArgs e)
        {
            resizer.ResizeControls(this);
        }

        private void txt_Mara_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txt_Mara.Text;
                string connectionString = Baglan.baglanti;
                string query = "SELECT * FROM tamamlananSozlesme WHERE tc LIKE @searchValue"; // SQL sorgusu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Parametreyi ekle
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgw_sozlesme.DataSource = dataTable; // DataGridView'i filtrelenmiş verilerle güncelle
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

        private void txt_plakaAra_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string searchValue = txt_plakaAra.Text;
                string connectionString = Baglan.baglanti;
                string query = "SELECT * FROM tamamlananSozlesme WHERE plaka LIKE @searchValue"; // SQL sorgusu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%"); // Parametreyi ekle
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dgw_sozlesme.DataSource = dataTable; // DataGridView'i filtrelenmiş verilerle güncelle
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
    }
}
