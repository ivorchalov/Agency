using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrAgent.Models
{
    public class StrSl
    {
        public int Id { get; set; }
        public string Status { set; get; }
        public int IDKl { get; set; }
        public int IDAg { get; set; }
        public int IDDogv { get; set; }
        public string Date { get; set; }
        public string Described { get; set; }
        public Dogovor Dogovor { get; set; }
        public User Agent { get; set; }
        public User Klient { get; set; }
    }
}
