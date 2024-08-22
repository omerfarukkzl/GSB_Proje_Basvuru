using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Referans
    {
        public int Id { get; set; }
        public string Tip { get; set; }

        public string AltTip { get; set; }

        public bool Silinme_Durumu { get; set; }
    }
}