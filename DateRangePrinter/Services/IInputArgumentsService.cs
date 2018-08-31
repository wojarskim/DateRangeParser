using System;

namespace DateRangePrinter
{
    public interface IInputArgumentsService
    {
        bool TryParseInputArguments(string[] args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
    }
}