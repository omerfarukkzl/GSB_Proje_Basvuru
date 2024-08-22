using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Kullanici
{
    public class KullaniciDto
    {

        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public string Rol { get; set; }
    }
}