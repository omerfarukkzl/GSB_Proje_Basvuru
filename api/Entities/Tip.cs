
public class Tip
{
    public int Id { get; set; }
    public string? Ad { get; set; }

    public ICollection<AltTip> AltTipler { get; set; }
    public ICollection<Basvuru> Basvurular { get; set; }
    public ICollection<Basvuru> BasvurularProje { get; set; }
    public ICollection<Basvuru> BasvurularTur { get; set; }

}