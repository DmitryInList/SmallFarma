// данные Аптеки - собраны в одном месте для удобства манипулирования ими.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallFarmaClient
{
    public class Pharmace
    {
        public int id { get; set; }
        public string Phar_Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
