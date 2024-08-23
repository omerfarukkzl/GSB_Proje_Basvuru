public class Basvuru
{
    public int Id { get; set; }
    public string BasvuruAdi { get; set; }

    public int BasvuruDurumId { get; set; }
    public Tip BasvuruDurumu { get; set; }

    public int BasvuruYapilanProjeId { get; set; }
    public Tip BasvuruYapilanProje { get; set; }

    public int BasvuruYapilanTurId { get; set; }
    public Tip BasvuruYapilanTur { get; set; }

    public ICollection<KullaniciBasvuru> KullaniciBasvurular { get; set; }
}