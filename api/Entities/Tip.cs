
using api.Entities;

public class Tip : BaseClass
{
    public int Id { get; set; }
    public string? Ad { get; set; }

    public ICollection<AltTip> ListAltTipler { get; set; }
    
}