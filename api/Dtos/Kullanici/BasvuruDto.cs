using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Kullanici
{
    public class BasvuruDto
    {
    public int BasvuruId { get; set; }
    public string ProjeAdi { get; set; }

    public TblRef BasvuranBirim { get; set; }

    public TblRef BasvuruYapilanProje { get; set; }

    public TblRef BasvuruYapilanTur { get; set; }

    public TblRef KatilimciTuru { get; set; }

    public TblRef BasvuruDonemi { get; set; }

    public TblRef BasvuruDurumu { get; set; }

    public DateTime BasvuruTarihi { get; set; }
    public DateTime AciklamaTarihi { get; set; }
    public decimal HibeTutari { get; set; }
    }
}