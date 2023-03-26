using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrAgent.Models
{
    public class Tarif
    {
        public Tarif()
        {
            this.Dogovor = new HashSet<Dogovor>();
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Conditions { get; set; }
        public ICollection<Dogovor> Dogovor { get; set; }
    }
}