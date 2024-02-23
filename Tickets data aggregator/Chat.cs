using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_data_aggregator
{
    public class DateConverter
    {
        public static string ConvertToMMDDYYYY(string inputDate)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(inputDate, new string[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "M/d/yyyy", "MM/d/yyyy", "M/dd/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate.ToString("MM/dd/yyyy");
            }
            else
            {
                return "Invalid date format";
            }
        }

    }
}
