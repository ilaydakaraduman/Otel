using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel
{
    public class Personel
    {
        public int Id { get; set; }
        public string Isim_Soyad { get; set; }
        public string IslemBilgisi { get; set; }
        public DateTime Tarih { get; set; }
        public int OdaNo { get; set; }
        public int RezervasyonID { get; set; }
    }
}
