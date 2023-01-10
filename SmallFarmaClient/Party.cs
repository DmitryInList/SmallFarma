// данные Партии - собраны в одном месте для удобства манипулирования ими.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallFarmaClient
{
    public class Party
    {
        public int id { get; set; }
        public int id_prod { get; set; }
        public int id_ware { get; set; }
        public int count { get; set; }
    }
}
