using api.Entities;

public class Basvuru : BaseClass
{
    public int Id { get; set; }
    public string? ProjeAdi { get; set; }

    public int? BasvuranBirimId { get; set; }
    public Tip BasvuranBirim { get; set; }

    public int? BasvuruYapilanProjeId { get; set; }
    public Tip BasvuruYapilanProje { get; set; }

    public int? BasvuruYapilanTurId { get; set; }
    public Tip BasvuruYapilanTur { get; set; }

    public int? KatilimciTurId { get; set; }
    public Tip KatilimciTuru { get; set; }

    public int? BasvuruDonemId { get; set; }
    public Tip BasvuruDonemi { get; set; }
    public int? BasvuruDurumId { get; set; }
    public Tip BasvuruDurumu { get; set; }

    public DateTime? BasvuruTarihi { get; set; }

    public DateTime? AciklanmaTarihi { get; set; }

    public decimal? HibeTutari { get; set; }

    public ICollection<KullaniciBasvuru> KullaniciBasvurular { get; set; }
}