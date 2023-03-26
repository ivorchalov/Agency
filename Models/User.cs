using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrAgent.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public string Discriminator { get; set; }
    }
}
