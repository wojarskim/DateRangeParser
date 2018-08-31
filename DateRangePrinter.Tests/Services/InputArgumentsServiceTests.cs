using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace DateRangePrinter.Tests.Services
{
    [TestClass]
    public class InputArgumentsServiceTests
    {
        private InputArgumentsService inputArgumentsService;

        [TestInitialize]
        public void Initialize()
        {
            inputArgumentsService = new InputArgumentsService();
        }

        [TestMethod]
        public void NorvegianCultureInputTest()
        {
            string[] args = new[] { "01.01.2017", "05.01.2017" };
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");

            var result = inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2017, 1, 1), fromDateTime);
            Assert.AreEqual(new DateTime(2017, 1, 5), toDateTime);
        }

        [TestMethod]
        public void PolishCultureInputTest()
        {
            string[] args = new[] { "01-01-2017", "05-01-2017" };
            CultureInfo.CurrentCulture = new CultureInfo("pl-PL");

            var result = inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
            Assert.IsTrue(result);
            Assert.AreEqual(new DateTime(2017, 1, 1), fromDateTime);
            Assert.AreEqual(new DateTime(2017, 1, 5), toDateTime);
        }

        [TestMethod]
        public void InvalidCultureInputTest()
        {
            string[] args = new[] { "01-01-2017", "05-01-2017" };
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");

            var result = inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
            Assert.IsFalse(result);
            Assert.IsNotNull(errorMessage);
        }

        [TestMethod]
        public void InvalidArgumentsCountTest()
        {
            string[] args = new[] { "01.01.2017" };
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");

            var result = inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
            Assert.IsFalse(result);
            Assert.IsNotNull(errorMessage);
        }

        [TestMethod]
        public void InvalidFirstDateTest()
        {
            string[] args = new[] { "1.1.2017", "05.01.2017" };
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");

            var result = inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
            Assert.IsFalse(result);
            Assert.IsNotNull(errorMessage);
        }

        [TestMethod]
        public void InvalidSecondDateTest()
        {
            string[] args = new[] { "01.01.2017", "32.01.2017" };
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");

            var result = inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
            Assert.IsFalse(result);
            Assert.IsNotNull(errorMessage);
        }

        [TestMethod]
        public void InvalidDateRangeTest()
        {
            string[] args = new[] { "01.01.2017", "05.01.2016" };
            CultureInfo.CurrentCulture = new CultureInfo("nb-NO");

            var result = inputArgumentsService.TryParseInputArguments(args, out DateTime fromDateTime, out DateTime toDateTime, out string errorMessage);
            Assert.IsFalse(result);
            Assert.IsNotNull(errorMessage);
        }
    }
}