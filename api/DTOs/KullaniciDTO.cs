public class KullaniciDto
{
    public int Id { get; set; }
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public string RolAdi { get; set; }
    public int? RolId { get; set; }
    public bool AktiflikDurumu { get; set; }
    public bool SilinmeDurumu { get; set; }
}