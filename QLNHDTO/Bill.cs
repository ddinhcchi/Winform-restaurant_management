using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHDTO
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public string IdTable { get; set; }
        public int Stat { get; set; }
    }
}
