using DateRangePrinter.Exceptions;
using System;

namespace DateRangePrinter
{
    public class DateRangeService : IDateRangeService
    {
        public string PrintDateRange(DateTime fromDateTime, DateTime toDateTime)
        {
            if (fromDateTime >= toDateTime)
            {
                throw new InvalidDateRangeException();
            }

            string toDateTimeText = toDateTime.ToString("dd/MM/yyyy");
            if (fromDateTime.Month == toDateTime.Month && fromDateTime.Year == toDateTime.Year)
            {
                return $"{fromDateTime.ToString("dd")} - {toDateTimeText}";
            }
            if (fromDateTime.Year == toDateTime.Year)
            {
                return $"{fromDateTime.ToString("dd/MM")} - {toDateTimeText}";
            }
            return $"{fromDateTime.ToString("dd/MM/yyyy")} - {toDateTimeText}";
        }
    }
}