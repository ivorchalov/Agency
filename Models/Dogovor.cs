using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrAgent.Models
{
    public class Dogovor
    {
        public Dogovor()
        {
            this.StrSl = new HashSet<StrSl>();
        }
        public int Id { get; set; }
        public int IDKl { get; set; }
        public int IDAg { get; set; }
        public int IDTr { get; set; }
        public string Date { get; set; }
        public string Described { get; set; }
        public string Status { set; get; }

        public User Agent { get; set; }
        public User Klient { get; set; }
        public Tarif Tarif { get; set; }
        public ICollection<StrSl> StrSl { get; set; }
    }
}