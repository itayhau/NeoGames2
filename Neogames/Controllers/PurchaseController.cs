using BL;
using CoreProject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Neogames.Controllers
{
    public class PurchaseController : ApiController
    {

        private MainDataFetcher _mainDataFetcher = new MainDataFetcher();

        /// <summary>
        /// Get the purchase data from start date in the bulk size
        /// returning position for sequential request
        /// could also consider using the row index as a return value 
        /// 
        ///  Demo url: http://localhost:[Port]/api/purchase/getfromdate?startDate=20191126T140931Z&bulkSize=5
        ///  moving +2 hours forward due to time zone
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="bulkSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/purchase/getfromdate")]
        public IHttpActionResult StartFromDate([FromUri]string startDate, [FromUri]int bulkSize)
        {
            try
            {
                // need to validate parameters before continue ...
                if (bulkSize <= 0)
                    return BadRequest("bulk size must be greater euqal than 1");

                var startDateDT = Utilities.BuildDateTimeFromYAFormat(startDate);

                if (!_mainDataFetcher.CheckIfStartFromDateExist(startDateDT))
                    //return Content(HttpStatusCode.NoContent, "no items in this position");
                    return Ok(new { message = "no items from this date" });

                int position = _mainDataFetcher.GetBulk(startDateDT, bulkSize, out List<PurchaseInfo> result);

                return Ok(new { data = result, position, message = "use the position in the sequential request" });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); // +also write to log file

                // consider which error to send to customer
                // choose between bad-request and internal-error
                return BadRequest("Something went wrong ... check the parameter you send. please contact support");
            }

        }

        /// <summary>
        /// Continue to get the next bulk from last position
        /// Each continue request will resolve the last position which should be used in the sequential requests
        /// 
        /// Since the API should continue, there is no sense in using a date time here
        /// if the user wants a different date then he should use the GetBulkFromGivenDateTime
        /// otherwise it makes more sense to continue from the last point
        /// assuming multiple customers will be using this app- so they will be using position parameter
        /// could also consider using the row index as a position parameter
        /// 
        ///  Demo url: http://localhost:[Port]/api/purchase/continue?bulkSize=5&position=[position from last request]
        /// </summary>
        /// <param name="bulkSize"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/purchase/continue")]
        public IHttpActionResult Continue([FromUri]int bulkSize, [FromUri]int position)
        {
            try
            {
                // need to validate parameters before continue ...
                if (bulkSize <= 0)
                    return BadRequest("bulk size must be greater euqal than 1");
                if (position <= 0)
                    return BadRequest("position size must be greater euqal than 0");

                if (!_mainDataFetcher.CheckIfPositionExist(position))
                    //return Content(HttpStatusCode.NoContent, "no items in this position");
                    return Ok(new { message = "no items in this position" });

                int newPosition = _mainDataFetcher.ContinueToNextBulk(position, bulkSize, out List<PurchaseInfo> result);

                return Ok(new { result, position = newPosition });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); // +also write to log file

                // consider which error to send to customer
                // choose between bad-request and internal-error
                return BadRequest("Something went wrong ... check the parameter you send. please contact support");
            }

        }
    }
}
