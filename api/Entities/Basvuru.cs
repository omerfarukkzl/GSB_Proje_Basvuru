using api.Entities;

public class Basvuru : BaseClass
{
    public int Id { get; set; }
    
    public int? KullaniciId { get; set; }
    public Kullanici BasvuranKullanici { get; set; }
    public string? ProjeAdi { get; set; }

    public int? BasvuranBirimId { get; set; }
    public AltTip BasvuranBirim { get; set; }

    public int? BasvuruYapilanProjeId { get; set; }
    public AltTip BasvuruYapilanProje { get; set; }

    public int? BasvuruYapilanTurId { get; set; }
    public AltTip BasvuruYapilanTur { get; set; }

    public int? KatilimciTurId { get; set; }
    public AltTip KatilimciTuru { get; set; }

    public int? BasvuruDonemId { get; set; }
    public AltTip BasvuruDonemi { get; set; }
    public int? BasvuruDurumId { get; set; }
    public AltTip BasvuruDurumu { get; set; }

    public DateTimeOffset? BasvuruTarihi { get; set; }

    public DateTimeOffset? AciklanmaTarihi { get; set; }

    public decimal? HibeTutari { get; set; }


}