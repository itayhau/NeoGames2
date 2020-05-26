using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreProject
{
    public static class Utilities
    {
        /// <summary>
        /// Convert a UTC Date String of format yyyyMMddTHHmmZ into a Local Date
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime BuildDateTimeFromYAFormat(string dateString)
        {
            Regex r = new Regex(@"^\d{4}\d{2}\d{2}T\d{2}\d{2}\d{2}Z$");
            if (!r.IsMatch(dateString))
            {
                throw new FormatException(
                    string.Format("{0} is not the correct format. Should be yyyyMMddTHHmmssZ", dateString));
            }

            // in israel will add 2 hours forward +2
            DateTime dt = DateTime.ParseExact(dateString, "yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

            return dt;
        }
    }
}
