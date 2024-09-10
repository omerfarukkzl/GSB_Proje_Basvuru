using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class BasvuruFiltreDTO
    {
    public string? ProjeAdi { get; set; }
    public int? BasvuranBirimId { get; set; }
    public int? BasvuruYapilanProjeId { get; set; }
    public int? BasvuruYapilanTurId { get; set; }
    public int? KatilimciTurId { get; set; }
    public int? BasvuruDonemId { get; set; }
    public int? BasvuruDurumId { get; set; }
    public DateTime? BasvuruTarihiBaslangic { get; set; }
    public DateTime? BasvuruTarihiBitis { get; set; }
    }
}