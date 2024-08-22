using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    
 public class Basvuru
{
    public int BasvuruId { get; set; }
    public string ProjeAdi { get; set; }

    public int BasvuranBirimId { get; set; }
    public TblRef BasvuranBirim { get; set; }

    public int BasvuruYapilanProjeId { get; set; }
    public TblRef BasvuruYapilanProje { get; set; }

    public int BasvuruYapilanTurId { get; set; }
    public TblRef BasvuruYapilanTur { get; set; }

    public int KatilimciTuruId { get; set; }
    public TblRef KatilimciTuru { get; set; }

    public int BasvuruDonemiId { get; set; }
    public TblRef BasvuruDonemi { get; set; }

    public int BasvuruDurumuId { get; set; }
    public TblRef BasvuruDurumu { get; set; }

    public DateTime BasvuruTarihi { get; set; }
    public DateTime AciklamaTarihi { get; set; }
    public decimal HibeTutari { get; set; }
}



}