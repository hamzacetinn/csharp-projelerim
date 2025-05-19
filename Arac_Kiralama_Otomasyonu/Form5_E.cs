using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form5_E : Form
    {
        public Form5_E()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Baglan.baglanti);
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingManagerBase bm;

        public Form5 frm5 = new Form5();

        private DataTable gelenVeri;

        /*public Form5_E(DataTable dt)
        {
            InitializeComponent();
            gelenVeri = dt;

        }*/


        private void btn_add_Click(object sender, EventArgs e)
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
                    frm5 = new Form5(); 

                baglanti = new SqlConnection(Baglan.baglanti);
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                da = new SqlDataAdapter("INSERT INTO musteri_yonetimi (tc_no, isim, soy_isim, telefon, telefon2, mail) VALUES (@q1, @q2, @q3, @q4, @q5, @q6)", baglanti);
                da.SelectCommand.Parameters.AddWithValue("@q1", txt_tctno.Text); // tc_no
                da.SelectCommand.Parameters.AddWithValue("@q2", txtAd.Text); // isim
                da.SelectCommand.Parameters.AddWithValue("@q3", txt_tctno.Text); // soy_isim
                da.SelectCommand.Parameters.AddWithValue("@q4", txt_tel.Text); // telefon
                da.SelectCommand.Parameters.AddWithValue("@q5", txt_tel2.Text); // telefon2
                da.SelectCommand.Parameters.AddWithValue("@q6", txtmail.Text); // mail
                da.Fill(ds);
                ds.Clear();
                da = new SqlDataAdapter("select * from musteri_yonetimi", baglanti);
                da.Fill(ds, "musteri_yonetimi");
                frm5.dgw_musteri.DataSource = ds;
                frm5.dgw_musteri.DataMember = "musteri_yonetimi";
                frm5.bm = frm5.BindingContext[ds, "musteri_yonetimi"];
                // frm5.ds.Clear();

                //frm5.VeriYenile2();
                /*da = new SqlDataAdapter("select*from musteri_yonetimi order by m_id", baglanti);
                bm = BindingContext[frm5.ds, "musteri_yonetimi"];*/
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Form5)
                    {
                        ((Form5)form).VeriYenile2();
                        break;
                    }
                }

                frm5.VeriYenile2();
                frm5.dgw_musteri.Refresh();
                baglanti.Close();
                this.Close();

            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.ToString());
            }
            catch (Exception ex)
            {
                if (gelenVeri != null)
                {
                    frm5.dgw_musteri.DataSource = gelenVeri;
                    frm5.dgw_musteri.DataMember = "musteri_yonetimi";


                    da = new SqlDataAdapter("SELECT * FROM musteri_yonetimi ORDER BY m_id", baglanti);
                    da.Fill(gelenVeri);

                    frm5.dgw_musteri.DataSource = gelenVeri;
                    frm5.dgw_musteri.DataMember = "musteri_yonetimi";
                }
                else
                {
                    MessageBox.Show("Table 'musteri_yonetimi' does not exist in the DataSet.");
                }
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            frm5.dgw_musteri.Refresh();
            this.Close();
        }

        private void Form5_E_Load(object sender, EventArgs e)
        {

        }
    }
}
