using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Tipler
    {

        public int Id { get; set; }
        public string? Tip { get; set; }

        public string? AltTip { get; set; }

        public int? TipKod { get; set; }

        public bool? SilinmeDurumu { get; set; }

     /*   public ICollection<Basvuru> ListeBasvuruDurumlar { get; set; }
        public ICollection<Basvuru> ListeBasvuruYapilanTurler { get; set; }
        public ICollection<Basvuru> ListeBasvuruYapilanProjeler { get; set; }
        public ICollection<Basvuru> ListeBasvuruKatilimciTurlar { get; set; }
        public ICollection<Basvuru> ListeBasvuruDonemler { get; set; }    


*/
    }
}