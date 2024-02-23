using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_data_aggregator
{
    internal class TicketProcesor
    {
        public List<string> output = new List<string>();
        public void ProcessText(string[] data)
        {
           StringBuilder myStringBuilder = new StringBuilder();
            foreach (string line in data)
            {
                switch (line)
                {
                    case string x when x.StartsWith("Title:"):
                        myStringBuilder.Append(ProcesTitle(line));
                        break;
                    case string x when x.StartsWith("Date:"):
                        myStringBuilder.Append(ProcesDate(line));
                        break;
                    case string x when x.StartsWith("Time:"):
                        myStringBuilder.Append(ProcesTime(line));
                        break;
                    case string x when x.Length == 0:
                        if (myStringBuilder.Length > 0) { output.Add(myStringBuilder.ToString()); }
                        myStringBuilder.Clear();
                        break;
                }
            }
        }
        string ProcesTime(string line)
        {
            return $" {ConvertTo24Hour(line.Substring(6))}";
        }

        string ProcesDate(string line)
        {
            return $" {ConvertToMMDDYYYY(line.Substring(6))} |";
        }

        string ProcesTitle(string line)
        {
            return line.Substring(7).PadRight(40) + "|";
        }
        public static string ConvertToMMDDYYYY(string inputDate)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(inputDate, new string[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "M/d/yyyy", "MM/d/yyyy", "M/dd/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate.ToString("MM/dd/yyyy").Replace(".", "/");
            }
            else
            {
                return "Invalid date format";
            }
        }
        private static string ConvertTo24Hour(string time)
        {
            DateTime parsedTime;
            if (DateTime.TryParseExact(time, "h:mm tt", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedTime))
            {
                return parsedTime.ToString("HH:mm");
            }
            else
            {
                return time;
            }
        }
    }

}
