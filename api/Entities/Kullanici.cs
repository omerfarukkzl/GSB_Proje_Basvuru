using api.Entities;

public class Kullanici : BaseClass
{
    public int Id { get; set; }
    public int? RolId { get; set; }
    public Roller KullaniciRol { get; set; }
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public bool SilinmeDurumu { get; set; } 
    public bool AktiflikDurumu { get; set; }
    public ICollection<Basvuru> ListBasvuranKullanici { get; set; }

    
    


}