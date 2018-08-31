using System;
using System.Globalization;

namespace DateRangePrinter
{
    public class InputArgumentsService : IInputArgumentsService
    {
        private const string DATE_FORMAT = "dd/MM/yyyy"; // eventually it could be moved to config file

        private const string INVALID_INPUT_ARGUMENTS_COUNT_MESSAGE = "Invalid input arguments count";
        private const string INVALID_FIRST_DATE_FORMAT_MESSAGE = "First date has invalid format";
        private const string INVALID_SECOND_DATE_FORMAT_MESSAGE = "Second date has invalid format";
        private const string SECOND_DATE_IS_NOT_LATER_MESSAGE = "Second date should be later than first one";

        public bool TryParseInputArguments(string[] args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage)
        {
            fromDateTime = new DateTime();
            toDateTime = new DateTime();
            errorMessage = null;

            if (args.Length < 2) // if more than 2, others will be ignored
            {
                errorMessage = INVALID_INPUT_ARGUMENTS_COUNT_MESSAGE;
                return false;
            }

            if (!DateTime.TryParseExact(args[0], DATE_FORMAT, CultureInfo.CurrentCulture, DateTimeStyles.None, out fromDateTime))
            {
                errorMessage = INVALID_FIRST_DATE_FORMAT_MESSAGE;
                return false;
            }

            if (!DateTime.TryParseExact(args[1], DATE_FORMAT, CultureInfo.CurrentCulture, DateTimeStyles.None, out toDateTime))
            {
                errorMessage = INVALID_SECOND_DATE_FORMAT_MESSAGE;
                return false;
            }

            if (fromDateTime >= toDateTime)
            {
                errorMessage = SECOND_DATE_IS_NOT_LATER_MESSAGE;
                return false;
            }

            return true;
        }
    }
}