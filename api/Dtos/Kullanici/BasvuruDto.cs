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

    public Tipler BasvuranBirim { get; set; }

    public Tipler BasvuruYapilanProje { get; set; }

    public Tipler BasvuruYapilanTur { get; set; }

    public Tipler KatilimciTuru { get; set; }

    public Tipler BasvuruDonemi { get; set; }

    public Tipler BasvuruDurumu { get; set; }

    public DateTime BasvuruTarihi { get; set; }
    public DateTime AciklamaTarihi { get; set; }
    public decimal HibeTutari { get; set; }
    }
}