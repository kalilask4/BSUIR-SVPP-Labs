using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Laba7.Entities
{
    class Swap
    {
        public int SwapId { get; set; }
        public string Type { get; set; }
        public string DbCoinId { get; set; }
        public string KdCoinId { get; set; }
        public double Amount { get; set; }
    }
}
