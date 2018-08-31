using DateRangePrinter.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace DateRangePrinter.Tests.Services
{
    [TestClass]
    public class DateRangeServiceTests
    {
        DateRangeService dateRangeService;

        [TestInitialize]
        public void Initialize()
        {
            dateRangeService = new DateRangeService();
        }

        [TestMethod]
        public void PrintDateRangeDifferentDaysTest()
        {
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");
            var result = dateRangeService.PrintDateRange(new DateTime(2017, 1, 1), new DateTime(2017, 1, 5));
            Assert.AreEqual("01 - 05.01.2017", result);
        }

        [TestMethod]
        public void PrintDateRangeDifferentMonthsTest()
        {
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");
            var result = dateRangeService.PrintDateRange(new DateTime(2017, 1, 1), new DateTime(2017, 2, 5));
            Assert.AreEqual("01.01 - 05.02.2017", result);
        }

        [TestMethod]
        public void PrintDateRangeDifferentYearsTest()
        {
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");
            var result = dateRangeService.PrintDateRange(new DateTime(2016, 1, 1), new DateTime(2017, 1, 5));
            Assert.AreEqual("01.01.2016 - 05.01.2017", result);
        }

        [TestMethod]
        public void PrintDateRangePolishCultureTest()
        {
            CultureInfo.CurrentCulture = new CultureInfo("pl-PL");
            var result = dateRangeService.PrintDateRange(new DateTime(2017, 1, 1), new DateTime(2017, 1, 5));
            Assert.AreEqual("01 - 05-01-2017", result);
        }

        [ExpectedException(typeof(InvalidDateRangeException))]
        [TestMethod]
        public void PrintDateRangeInvalidRangeTest()
        {
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");
            var result = dateRangeService.PrintDateRange(new DateTime(2018, 1, 1), new DateTime(2017, 1, 5));
        }
    }
}