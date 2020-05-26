using CoreProject;
using DALSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MainDataFetcher
    {
        private IDataFetcher _dataFetcher;

        public MainDataFetcher()
        {
            // should be read from configuration
            // or perhaps send as an argument to the ctor
            _dataFetcher = new SimulatorDataFetcher();
        }

        public int GetBulk(DateTime startFrom, int bulkSize, out List<PurchaseInfo> result)
        {
            return _dataFetcher.GetBulkFromGivenDateTime(startFrom, bulkSize, out result);
        }

        // Since the API should continue, there is no sense in using a date time here
        // if the user wants a different date then he should use the GetBulkFromGivenDateTime
        // otherwise it makes more sense to continue from the last position
        // could also consider using the row index as a return value
        public int ContinueToNextBulk(int startFromPosition, int bulkSize, out List<PurchaseInfo> result)
        {
            return _dataFetcher.ContinueToNextBulk(startFromPosition, bulkSize, out result);
        }

        public bool CheckIfPositionExist(int position)
        {
            return _dataFetcher.CheckIfPositionExist(position);
        }

        public bool CheckIfStartFromDateExist(DateTime startFrom)
        {
            return _dataFetcher.CheckIfStartFromDateExist(startFrom);
        }
    }
}
