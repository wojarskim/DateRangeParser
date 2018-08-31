using System;

namespace DateRangePrinter
{
    public interface IDateRangeService
    {
        string PrintDateRange(DateTime fromDateTime, DateTime toDateTime);
    }
}
