using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class BasvuruKullanici
{
    public int BasvuruKullaniciId { get; set; }

    public int BasvuruId { get; set; }
    public Basvuru Basvuru { get; set; }

    public int KullaniciId { get; set; }
    public Kullanici Kullanici { get; set; }
}
}