using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Roller
    {
        public int Id { get; set; }
        public string? RolAdi { get; set; }
        public ICollection<Kullanici> ListRoller { get; set; }
    }
}