using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject
{
    public class PurchaseInfo
    {
        // assuming this is not PK , but just a sequential number for the result ...
        public long ItemNo { get; set; }

        public float Amount { get; set; }
        public DateTime PurchaseDate { get; set; }

        public override string ToString()
        {
            return $"{ItemNo} {Amount} {PurchaseDate}";
        }
    }
}
