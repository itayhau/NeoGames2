using CoreProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject
{
    public interface IDataFetcher
    {
        // this will also return the last position for sequential requestss
        int GetBulkFromGivenDateTime(DateTime startFrom, int bulkSize, out List<PurchaseInfo> result);

        // Since the API should continue, there is no sense in using a date time here
        // if the user wants a different date then he should use the GetBulkFromGivenDateTime
        // otherwise it makes more sense to continue from the last point
        // assuming multiple customers will be using this app
        // will use last-position index to allow requests to continue from the last result
        int ContinueToNextBulk(int startFromPosition, int bulkSize, out List<PurchaseInfo> result);

        bool CheckIfPositionExist(int position);

        bool CheckIfStartFromDateExist(DateTime startFrom);

    }
}
