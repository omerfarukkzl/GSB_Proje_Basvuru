public class BasvuruDto
{
    public int Id { get; set; }
    public string? ProjeAdi { get; set; }
    public int? BasvuranBirimId { get; set; }
    public int? BasvuruYapilanProjeId { get; set; }
    public int? BasvuruYapilanTurId { get; set; }
    public int? KatilimciTurId { get; set; }
    public int? BasvuruDonemId { get; set; }
    public int? BasvuruDurumId { get; set; }
    public DateTimeOffset? BasvuruTarihi { get; set; }
    public DateTimeOffset? AciklanmaTarihi { get; set; }
    public decimal? HibeTutari { get; set; }
}