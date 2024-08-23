using api.Entities;

public class KullaniciBasvuru : BaseClass
{
    public int KullaniciId { get; set; }
    public Kullanici? Kullanici { get; set; }

    public int BasvuruId { get; set; }
    public Basvuru? Basvuru { get; set; }
}