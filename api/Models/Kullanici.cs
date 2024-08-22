using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }

        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public string Rol { get; set; }

        public bool SilinmeDurumu { get; set; }
    }
}