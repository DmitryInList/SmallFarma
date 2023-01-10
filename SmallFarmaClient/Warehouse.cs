// данные Склада - собраны в одном месте для удобства манипулирования ими.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallFarmaClient
{
    public class Warehouse
    {
        public int id { get; set; }
        public int id_phar { get; set; }
        public string Ware_Name { get; set; }
    }
}
