using System;

namespace DateRangePrinter
{
    public class DateRangeConsolePrinter : IDateRangePrinter
    {
        private readonly IInputArgumentsService _inputArgumentsService;
        private readonly IDateRangeService _dateRangeService;

        public DateRangeConsolePrinter(
            IInputArgumentsService inputArgumentsService,
            IDateRangeService dateRangeService)
        {
            _inputArgumentsService = inputArgumentsService;
            _dateRangeService = dateRangeService;
        }

        public void Run(string[] args)
        {
            Console.WriteLine(_inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage)
                ? _dateRangeService.PrintDateRange(fromDateTime, toDateTime)
                : errorMessage
            );
        }
    }
}