using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Arac_Kiralama_Otomasyonu
{

    public class arabaFiltre
    {



        public string connectionString = Baglan.baglanti;

        public DataTable DinamikFiltrele(string marka, string seri, string model, string kasa, string vites, string yakit, string rengi, int sec = 1, string durumu = null, string plaka = null, int? minYil = null, int? maxYil = null, int? minUcret = null, int? maxUcret = null)
        {
            if (sec==1)
            {
                string query = "SELECT id,marka,seri,model,yili,yakit,rengi,kasa,plaka,durumu,vites,kira_ucreti FROM araba_yonetimi WHERE durumu = 'MUSAIT'";
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(kasa) && kasa != "SEÇ")
                {
                    query += " AND kasa LIKE @kasa ";
                    parameters.Add(new SqlParameter("@kasa", "%" + kasa + "%"));
                }
                if (!string.IsNullOrWhiteSpace(marka))
                {
                    query += " AND marka LIKE @marka";
                    parameters.Add(new SqlParameter("@marka", "%" + marka + "%"));
                }
                if (!string.IsNullOrWhiteSpace(seri))
                {
                    query += " AND seri LIKE @seri";
                    parameters.Add(new SqlParameter("@seri", "%" + seri + "%"));
                }
                if (!string.IsNullOrWhiteSpace(model))
                {
                    query += " AND model LIKE @model";
                    parameters.Add(new SqlParameter("@model", "%" + model + "%"));
                }
                if (!string.IsNullOrEmpty(durumu) && durumu != "SEÇ")
                {
                    query += " AND durumu LIKE @durumu";
                    parameters.Add(new SqlParameter("@durumu", "%" + durumu + "%"));
                }
                if (!string.IsNullOrWhiteSpace(vites) && vites != "SEÇ")
                {
                    query += " AND vites LIKE @vites ";
                    parameters.Add(new SqlParameter("@vites", "%" + vites + "%"));
                }
                if (!string.IsNullOrWhiteSpace(yakit) && yakit != "SEÇ")
                {
                    query += " AND yakit LIKE @yakit ";
                    parameters.Add(new SqlParameter("@yakit", "%" + yakit + "%"));
                }
                if (!string.IsNullOrWhiteSpace(rengi))
                {
                    query += " AND rengi LIKE @rengi";
                    parameters.Add(new SqlParameter("@rengi", "%" + rengi + "%"));
                }
                if (!string.IsNullOrWhiteSpace(plaka))
                {
                    query += " AND plaka LIKE @plaka";
                    parameters.Add(new SqlParameter("@plaka", "%" + plaka + "%"));
                }
                if (minYil.HasValue && maxYil.HasValue)
                {
                    query += " AND yili BETWEEN @minYil AND @maxYil";
                    parameters.Add(new SqlParameter("@minYil", minYil.Value));
                    parameters.Add(new SqlParameter("@maxYil", maxYil.Value));
                }
                else if (minYil.HasValue)
                {
                    query += " AND yili >= @minYil";
                    parameters.Add(new SqlParameter("@minYil", minYil.Value));
                }
                else if (maxYil.HasValue)
                {
                    query += " AND yili <= @maxYil";
                    parameters.Add(new SqlParameter("@maxYil", maxYil.Value));
                }
                if (minUcret.HasValue && maxUcret.HasValue)
                {
                    query += " AND kira_ucreti BETWEEN @minUcret AND @maxUcret";
                    parameters.Add(new SqlParameter("@minUcret", minUcret.Value));
                    parameters.Add(new SqlParameter("@maxUcret", maxUcret.Value));
                }
                else if (minUcret.HasValue)
                {
                    query += " AND kira_ucreti >= @minUcret";
                    parameters.Add(new SqlParameter("@minUcret", minUcret.Value));
                }
                else if (maxUcret.HasValue)
                {
                    query += " AND kira_ucreti <= @maxUcret";
                    parameters.Add(new SqlParameter("@maxUcret", maxUcret.Value));
                }
                return GetDataTable(query, parameters.ToArray());
            }
            else
            {
                string query = "SELECT id,marka,seri,model,yili,yakit,rengi,kasa,plaka,durumu,vites,kira_ucreti FROM araba_yonetimi WHERE 1=1";
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(kasa) && kasa != "SEÇ")
                {
                    query += " AND kasa LIKE @kasa ";
                    parameters.Add(new SqlParameter("@kasa", "%" + kasa + "%"));
                }
                if (!string.IsNullOrWhiteSpace(marka))
                {
                    query += " AND marka LIKE @marka";
                    parameters.Add(new SqlParameter("@marka", "%" + marka + "%"));
                }
                if (!string.IsNullOrWhiteSpace(seri))
                {
                    query += " AND seri LIKE @seri";
                    parameters.Add(new SqlParameter("@seri", "%" + seri + "%"));
                }
                if (!string.IsNullOrWhiteSpace(model))
                {
                    query += " AND model LIKE @model";
                    parameters.Add(new SqlParameter("@model", "%" + model + "%"));
                }
                if (!string.IsNullOrEmpty(durumu) && durumu != "SEÇ")
                {
                    query += " AND durumu LIKE @durumu";
                    parameters.Add(new SqlParameter("@durumu", "%" + durumu + "%"));
                }
                if (!string.IsNullOrWhiteSpace(vites) && vites != "SEÇ")
                {
                    query += " AND vites LIKE @vites ";
                    parameters.Add(new SqlParameter("@vites", "%" + vites + "%"));
                }
                if (!string.IsNullOrWhiteSpace(yakit) && yakit != "SEÇ")
                {
                    query += " AND yakit LIKE @yakit ";
                    parameters.Add(new SqlParameter("@yakit", "%" + yakit + "%"));
                }
                if (!string.IsNullOrWhiteSpace(rengi))
                {
                    query += " AND rengi LIKE @rengi";
                    parameters.Add(new SqlParameter("@rengi", "%" + rengi + "%"));
                }
                if (!string.IsNullOrWhiteSpace(plaka))
                {
                    query += " AND plaka LIKE @plaka";
                    parameters.Add(new SqlParameter("@plaka", "%" + plaka + "%"));
                }
                if (minYil.HasValue && maxYil.HasValue)
                {
                    query += " AND yili BETWEEN @minYil AND @maxYil";
                    parameters.Add(new SqlParameter("@minYil", minYil.Value));
                    parameters.Add(new SqlParameter("@maxYil", maxYil.Value));
                }
                else if (minYil.HasValue)
                {
                    query += " AND yili >= @minYil";
                    parameters.Add(new SqlParameter("@minYil", minYil.Value));
                }
                else if (maxYil.HasValue)
                {
                    query += " AND yili <= @maxYil";
                    parameters.Add(new SqlParameter("@maxYil", maxYil.Value));
                }
                if (minUcret.HasValue && maxUcret.HasValue)
                {
                    query += " AND kira_ucreti BETWEEN @minUcret AND @maxUcret";
                    parameters.Add(new SqlParameter("@minUcret", minUcret.Value));
                    parameters.Add(new SqlParameter("@maxUcret", maxUcret.Value));
                }
                else if (minUcret.HasValue)
                {
                    query += " AND kira_ucreti >= @minUcret";
                    parameters.Add(new SqlParameter("@minUcret", minUcret.Value));
                }
                else if (maxUcret.HasValue)
                {
                    query += " AND kira_ucreti <= @maxUcret";
                    parameters.Add(new SqlParameter("@maxUcret", maxUcret.Value));
                }



                return GetDataTable(query, parameters.ToArray());
            }
           
        }







        public DataTable DinamikFiltreleSozlesme(string tcno, string plaka)
        {

            string query = "SELECT * FROM sozlesme WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(tcno))
            {
                query += " AND tc_no LIKE @tc";
                parameters.Add(new SqlParameter("@tc", "%" + tcno + "%"));
            }

            if (!string.IsNullOrWhiteSpace(plaka))
            {
                query += " AND plaka LIKE @plaka";
                parameters.Add(new SqlParameter("@plaka", "%" + plaka + "%"));
            }
            return GetDataTable(query, parameters.ToArray());
        }

        public DataTable GetDataTable(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}



