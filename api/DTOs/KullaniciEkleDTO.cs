public class KullaniciEkleDto
{

    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public int? RolId { get; set; }
    public bool AktiflikDurumu { get; internal set; }
    public bool SilinmeDurumu { get; internal set; }
}