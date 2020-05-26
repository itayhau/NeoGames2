using CoreProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSimulator
{
    static class DataGenerator
    {
        static internal List<PurchaseInfo> GenerateData()
        {
            return new List<PurchaseInfo>
            {
                // should consider that ItemNo will be an auto increment number depend on the result
                // or perhaps index ID

                new PurchaseInfo { ItemNo = 1, Amount = 1, PurchaseDate = new DateTime(2019, 11, 26, 16, 09, 31)},
                new PurchaseInfo { ItemNo = 2, Amount = 5, PurchaseDate = new DateTime(2019, 11, 26, 16, 09, 31)},
                new PurchaseInfo { ItemNo = 3, Amount = 56, PurchaseDate = new DateTime(2019, 11, 26, 16, 09, 32)},
                new PurchaseInfo { ItemNo = 4, Amount = 22, PurchaseDate = new DateTime(2019, 11, 26, 16, 09, 32)},
                new PurchaseInfo { ItemNo = 5, Amount = 154.5f, PurchaseDate = new DateTime(2019, 11, 26, 16, 09, 32)},
                new PurchaseInfo { ItemNo = 6, Amount = 35.56f, PurchaseDate = new DateTime(2019, 11, 26, 16, 09, 32)}
            };
        }
    }
}
