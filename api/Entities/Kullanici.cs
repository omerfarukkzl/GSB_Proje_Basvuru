public class Kullanici
{
    public int Id { get; set; }
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public ICollection<KullaniciBasvuru> KullaniciBasvurulari { get; set; }
}