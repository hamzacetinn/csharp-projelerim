using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Arac_Kiralama_Otomasyonu
{
    internal class Baglan
    {
        public static string baglanti = ConfigurationManager.ConnectionStrings["SqlBaglanti"].ConnectionString;
    }
}
