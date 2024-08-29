public class BasvuruDto
{
    public int Id { get; set; }
    public string? ProjeAdi { get; set; }
    public int? BasvuranBirimId { get; set; }
    public string? BasvuranBirimAdi { get; internal set; }
    public int? BasvuruYapilanProjeId { get; set; }
    public string? BasvuruYapilanProjeAdi { get; internal set; }
    public int? BasvuruYapilanTurId { get; set; }
    public string? BasvuruYapilanTurAdi { get; internal set; }
    public int? KatilimciTurId { get; set; }
    public string? KatilimciTurAdi { get; internal set; }
    public int? BasvuruDonemId { get; set; }
    public string? BasvuruDonemAdi { get; internal set; }
    public int? BasvuruDurumId { get; set; }
    public string? BasvuruDurumAdi { get; internal set; }
    public DateTime? BasvuruTarihi { get; set; }
    public DateTime? AciklanmaTarihi { get; set; }
    public decimal? HibeTutari { get; set; }

    public bool SilinmeDurumu { get; set; }
    
    
    
    
    
    
}