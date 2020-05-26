using CoreProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALSimulator
{
    public class SimulatorDataFetcher : IDataFetcher
    {
        public SimulatorDataFetcher()
        {
            DataHolder.Data = DataGenerator.GenerateData();
        }

        public bool CheckIfPositionExist(int position)
        {
            return DataHolder.Data.Count > position;
        }

        public bool CheckIfStartFromDateExist(DateTime startFrom)
        {
            return DataHolder.Data.FindIndex(info => info.PurchaseDate >= startFrom) != -1;
        }

        public int ContinueToNextBulk(int startFromPosition, int bulkSize, out List<PurchaseInfo> result)
        {
            if (startFromPosition + bulkSize > DataHolder.Data.Count)
            {
                bulkSize = DataHolder.Data.Count - startFromPosition;
            }

            // quick solution
            // if item no is a sequential number running from 1-n
            // then here we could run from the first item in the result and set it to 1,
            // and add 1 sequentially to the other items in the result
            result = DataHolder.Data.GetRange(startFromPosition, bulkSize);

            return startFromPosition + bulkSize;
        }

        public int GetBulkFromGivenDateTime(DateTime startFrom, int bulkSize, out List<PurchaseInfo> result)
        {
            // quick solution
            // need to find purchase by date
            // what happends if date not found ? should find first row bigger than date?
            // what happends if none exist? exception ?
            int startIndex = DataHolder.Data.FindIndex(info => info.PurchaseDate >= startFrom);

            if (startIndex == -1)
            {
                result = new List<PurchaseInfo>();
                return -1;
            }

            // also need to check if bulk size exceed the current data and conside throwing exception or not
            if (startIndex + bulkSize > DataHolder.Data.Count)
            {
                bulkSize = DataHolder.Data.Count - startIndex;
            }

            // if item no is a sequential number running from 1-n
            // then here we could run from the first item in the result and set it to 1,
            // and add 1 sequentially to the resut
            result = DataHolder.Data.GetRange(startIndex, bulkSize);

            return startIndex + bulkSize;
        }
    }
}
