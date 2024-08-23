public class AltTip
{
    public int Id { get; set; }
    public string? Ad { get; set; }
    public int TipId { get; set; }
    public Tip Tip { get; set; }
    public ICollection<Basvuru> Basvurular { get; set; }


}