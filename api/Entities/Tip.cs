
public class Tip
{
    public int Id { get; set; }
    public string? Ad { get; set; }

    public ICollection<AltTip> ListAltTipler { get; set; }
    public ICollection<Basvuru> ListBasvuruDurumu { get; set; }
    public ICollection<Basvuru> ListBasvuruYapilanProje { get; set; }
    public ICollection<Basvuru> ListBasvuruYapilanTur { get; set; }
    public ICollection<Basvuru> ListBasvuruDonemi { get; set; }
    public ICollection<Basvuru> ListBasvuranBirim { get; set; }
public ICollection<Basvuru> ListKatilimciTuru { get; set; }


    
}